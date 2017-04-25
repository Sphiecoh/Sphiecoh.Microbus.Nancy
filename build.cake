var target          = Argument("target", "Default");
var configuration   = Argument<string>("configuration", "Release");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////
var isLocalBuild        = !AppVeyor.IsRunningOnAppVeyor;
var buildArtifacts      = Directory("./artifacts/packages");

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() =>
{
     var settings = new DotNetCoreBuildSettings
     {
         Configuration = "Release"
     };
	DotNetCoreBuild("Sphiecoh.Microbus.Nancy.sln",settings); 
   
});

Task("RunTests")
    .Does(() =>
{
	DotNetCoreTest("./test/Sphiecoh.Microbus.Nancy.Tests/Sphiecoh.Microbus.Nancy.Tests.csproj");
	
});

Task("Pack")
    .IsDependentOn("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
{
    var settings = new DotNetCorePackSettings
    {
        Configuration = configuration,
        OutputDirectory = buildArtifacts,
    };
     if(!isLocalBuild)
    {
        settings.VersionSuffix = "build" + AppVeyor.Environment.Build.Number.ToString().PadLeft(3,'0');
    }
   var projects = GetFiles("./src/**/*.csproj");
    foreach(var project in projects)
  {
       DotNetCorePack(project.GetDirectory().FullPath, settings);
   
  }
    
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories(new DirectoryPath[] { buildArtifacts });
});

Task("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreRestoreSettings
    {
        Sources = new [] { "https://api.nuget.org/v3/index.json" }
    };

    DotNetCoreRestore("Sphiecoh.Microbus.Nancy.sln", settings);
  
});

Task("Default")
  .IsDependentOn("Build")
  .IsDependentOn("RunTests")
  .IsDependentOn("Pack");

RunTarget(target);

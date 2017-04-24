
[![Build status](https://ci.appveyor.com/api/projects/status/1dkne7irva7vr8d8?svg=true)](https://ci.appveyor.com/project/sphiecoh/sphiecoh-microbus-nancy)
# Sphiecoh.Microbus.Nancy
A small library to with using NancyFx and [MicroBus](https://github.com/Lavinski/Enexure.MicroBus) mediator for .NET using the default Nancy container.
```
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            var builder = new BusBuilder();
            builder.RegisterHandlers(Assembly.GetEntryAssembly());
            container.RegisterMicroBus(builder);
        }
 ```
 This will look for Handlers in the current assembly.

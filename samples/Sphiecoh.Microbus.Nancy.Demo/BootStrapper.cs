using Enexure.MicroBus;
using Nancy;
using Nancy.TinyIoc;
using System.Reflection;

namespace Sphiecoh.Microbus.Nancy.Demo
{
    public class BootStrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            var builder = new BusBuilder();
            builder.RegisterHandlers(Assembly.GetEntryAssembly());
            container.RegisterMicroBus(builder);
        }
    }
}

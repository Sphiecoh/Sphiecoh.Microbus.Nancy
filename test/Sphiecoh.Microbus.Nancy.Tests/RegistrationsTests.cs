using Enexure.MicroBus;
using Nancy.TinyIoc;
using System;
using System.Reflection;
using Xunit;

namespace Sphiecoh.Microbus.Nancy.Tests
{
    public class RegistrationsTests
    {
        TinyIoCContainer container;
        public RegistrationsTests()
        {
            container = new TinyIoCContainer();
        }
        [Fact]
        public void DefaultInterfaceShouldBeRegistered()
        {
            container.RegisterMicroBus(new BusBuilder());
            Assert.NotNull(container.Resolve<IMicroBus>());
            Assert.NotNull(container.Resolve<IMicroMediator>());
            Assert.NotNull(container.Resolve<IOuterPipelineDetector>());
            Assert.NotNull(container.Resolve<IPipelineRunBuilder>());

        }
        [Fact]
        public void Can_ResolveGlobalHandlers()
        {
            var builder = new BusBuilder();
            builder.RegisterGlobalHandler<TestLoggingHandler>();
            container.RegisterMicroBus(builder);
            Assert.NotNull(container.Resolve<TestLoggingHandler>());
        }
        [Fact]
        public void Can_ResolveHandlers()
        {
            var builder = new BusBuilder();
            builder.RegisterCommandHandler<Command,TestCommandHandler>();
            container.RegisterMicroBus(builder);
            Assert.True(container.Resolve<IPipelineBuilder>().GetPipeline(typeof(Command)).HandlerTypes.Count > 0);
        }
    }
}

using Enexure.MicroBus;
using Nancy.TinyIoc;

namespace Sphiecoh.Microbus.Nancy
{
    public static class TinyIoCContainerExtension
    {
        public static void RegisterMicroBus(this TinyIoCContainer container , BusBuilder busBuilder)
        {
            RegisterMicroBus(container,busBuilder, new BusSettings());
        }
        public static void RegisterMicroBus(this TinyIoCContainer container, BusBuilder busBuilder, BusSettings busSettings)
        {
            container.Register(busSettings);
            var pipelineBuilder = new PipelineBuilder(busBuilder);
            pipelineBuilder.Validate();
            RegisterHandlersWithContainer(container, busBuilder);
            container.Register<IPipelineBuilder>(pipelineBuilder);
            container.Register<IOuterPipelineDetector, OuterPipelineDetector>();
            container.Register<IPipelineRunBuilder, PipelineRunBuilder>();
            container.Register(typeof(IDependencyScope), new TinyIoCDependencyScope(container));
            container.Register(typeof(IDependencyResolver), new TinyIoCDependencyResolver(container));
            container.Register<IMicroBus,MicroBus>();
            container.Register<IMicroMediator,MicroMediator>();
            container.Register<IOuterPipelineDetertorUpdater, OuterPipelineDetector>();


        }
        private static void RegisterHandlersWithContainer(TinyIoCContainer container, BusBuilder busBuilder)
        {
            foreach (var globalHandlerRegistration in busBuilder.GlobalHandlerRegistrations)
            {
                container.Register(globalHandlerRegistration.HandlerType);
                foreach (var dependency in globalHandlerRegistration.Dependencies)
                {
                    container.Register(dependency);
                }
            }
            foreach (var registration in busBuilder.MessageHandlerRegistrations)
            {
                container.Register(registration.HandlerType);

                foreach (var dependency in registration.Dependencies)
                {
                    container.Register(dependency);
                }
            }
        }
    }
}

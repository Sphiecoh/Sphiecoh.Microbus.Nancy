using Enexure.MicroBus;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sphiecoh.Microbus.Nancy
{
    class TinyIoCDependencyResolver : IDependencyResolver
    {
        private TinyIoCContainer container;
        public TinyIoCDependencyResolver(TinyIoCContainer container)
        {
            this.container = container;
        }
       
        public IDependencyScope BeginScope()
        {
            return new TinyIoCDependencyScope(container);
        }
    }
}

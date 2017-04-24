using Enexure.MicroBus;
using Nancy.TinyIoc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sphiecoh.Microbus.Nancy
{
    class TinyIoCDependencyScope : TinyIoCDependencyResolver, IDependencyScope
    {
        private TinyIoCContainer container;
        public TinyIoCDependencyScope(TinyIoCContainer container):base(container)
        {
            this.container = container;
        }
       
        public void Dispose()
        {
           
        }

        public object GetService(Type serviceType)
        {
           return container.Resolve(serviceType);
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)GetServices(typeof(T));
        }
    }
}

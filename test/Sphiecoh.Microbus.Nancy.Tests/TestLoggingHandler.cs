using Enexure.MicroBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sphiecoh.Microbus.Nancy.Tests
{
    class TestLoggingHandler : IDelegatingHandler
    {
        public Task<object> Handle(INextHandler next, object message)
        {
            System.Diagnostics.Debug.WriteLine("Method invoked");
            return next.Handle(message);
        }
    }
}

using Enexure.MicroBus;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sphiecoh.Microbus.Nancy.Demo
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IMicroMediator mediator)
        {
            Get("/",_ => {
                mediator.SendAsync(new PingCommand { Time = DateTime.Now });
                return "Ping message sent";
            });
        }
    }
}

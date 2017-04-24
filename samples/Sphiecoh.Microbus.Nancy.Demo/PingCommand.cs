using Enexure.MicroBus;
using System;

namespace Sphiecoh.Microbus.Nancy.Demo
{
    public class PingCommand : ICommand
    {
        public DateTime Time { get; set; }
    }
}

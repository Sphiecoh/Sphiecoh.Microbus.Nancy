using Enexure.MicroBus;
using System.Threading.Tasks;

namespace Sphiecoh.Microbus.Nancy.Demo
{
    public class PingHandler : ICommandHandler<PingCommand>
    {
        public Task Handle(PingCommand command)
        {
            return Task.FromResult(0);
        }
    }
}

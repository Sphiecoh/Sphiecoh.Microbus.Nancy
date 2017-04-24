using Enexure.MicroBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sphiecoh.Microbus.Nancy.Tests
{
    class TestCommandHandler : ICommandHandler<Command>
    {
        public Task Handle(Command command)
        {
            return Task.FromResult(0);
        }
    }
    class TestQueryHandler : IQueryHandler<Query, Unit>
    {
        public Task<Unit> Handle(Query query)
        {
            return Task.FromResult(Unit.Unit);
        }
    }
    class Command : ICommand
    {

    }
    class Query : IQuery<Query,Unit>
    {

    }
}

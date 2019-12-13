using System;
using System.Linq;
using Dolittle.Commands;
using Dolittle.Commands.Coordination;
using Dolittle.Commands.Handling;
using Domain.Accounts;

namespace Domain.TestData
{
    public class AddTestData : ICommand
    {
        
    }

    public class CommandHandler : ICanHandleCommands
    {
        readonly ICommandCoordinator _commandCoordinator;

        public CommandHandler(ICommandCoordinator commandCoordinator)
        {
            _commandCoordinator = commandCoordinator;
        }
        
        public void Handle(AddTestData testData)
        {
            foreach (var i in Enumerable.Range(0,1000))
            {
                var command = new OpenDebitAccount()
                {
                    Name = Guid.NewGuid().ToString(),
                    CustomerId = Guid.NewGuid()
                };
                _commandCoordinator.Handle(command);
            }
        }
    }
}
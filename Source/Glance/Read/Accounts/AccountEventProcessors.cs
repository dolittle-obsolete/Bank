using Dolittle.Events.Processing;
using Dolittle.Logging;
using Events.MyBC1.Accounts;

namespace Read.Accounts
{
    public class AccountEventProcessors : ICanProcessEvents
    {
        private readonly ILogger _logger;

        public AccountEventProcessors(ILogger logger)
        {
            _logger = logger;
        }

        [EventProcessor("4e5746d0-417e-4410-94a8-3ed198e6177c")]
        public void Process(AccountOpened @event)
        {
            _logger.Information($"Account was opened for {@event.Owner}");
        }        
    }
}
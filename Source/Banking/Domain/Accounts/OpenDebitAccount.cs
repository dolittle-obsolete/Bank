using Concepts.Accounts;
using Dolittle.Commands;

namespace Domain.Accounts
{
    public class OpenDebitAccount : ICommand
    {
        public CustomerId CustomerId { get; set; }
        public string Name { get; set; }
    }
}
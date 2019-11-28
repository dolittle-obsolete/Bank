using System;
using Dolittle.ReadModels;

namespace Read.Accounts
{
    public class Account : IReadModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
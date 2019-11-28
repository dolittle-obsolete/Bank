using System;
using System.Collections.Generic;
using System.Threading;
using Dolittle.Artifacts;
using Dolittle.DependencyInversion;
using Dolittle.Domain;
using Dolittle.Execution;
using Dolittle.Runtime.Commands;
using Dolittle.Runtime.Commands.Coordination;

namespace Decisions.Accounts
{
    public class Reactions : IReactions
    {
        private readonly ArtifactId Artifact = Guid.Parse("b2e0e8c1-36c8-412b-ab14-300e22f74132");
        private readonly ICommandContextManager _commandContextManager;
        private readonly IExecutionContextManager _executionContextManager;
        private readonly IContainer _container;

        public Reactions(
            IExecutionContextManager executionContextManager,
            ICommandContextManager commandContextManager,
            IContainer container)
        {
            _executionContextManager = executionContextManager;
            _commandContextManager = commandContextManager;
            _container = container;
        }

        public void AggregateRoot<T>(Action<IAggregateOf<T>> callback)
            where T : class, IAggregateRoot
        {
            var thread = new Thread(() =>
            {
                Thread.Sleep(500);
                var commandRequest = new CommandRequest(
                    _executionContextManager.Current.CorrelationId,
                    Artifact,
                    ArtifactGeneration.First,
                    new Dictionary<string, object>()
                );

                using (_commandContextManager.EstablishForCommand(commandRequest))
                {
                    var aggregate = _container.Get<IAggregateOf<T>>();
                    callback(aggregate);
                }
            });

            thread.Start();
        }
    }
}

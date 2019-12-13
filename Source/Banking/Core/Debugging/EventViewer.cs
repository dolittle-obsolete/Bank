using System.Collections.Generic;
using System.Linq;
using Dolittle.Artifacts;
using Dolittle.PropertyBags;
using Dolittle.Runtime.Events;
using Dolittle.Runtime.Events.Store;
using Microsoft.AspNetCore.Mvc;

namespace Core.Debugging
{
    [Route("debugging/events")]
    public class EventViewer : ControllerBase
    {
        readonly IEventStore _eventStore;
        readonly IArtifactTypeMap _artifacts;

        public EventViewer(IEventStore eventStore, IArtifactTypeMap artifacts)
        {
            _eventStore = eventStore;
            _artifacts = artifacts;
        }

        [HttpGet]
        public IEnumerable<EventViewerEvent> All()
        {
            return _eventStore.FetchAllCommitsAfter(0).SelectMany(_ => _.Events).Select(_ => new EventViewerEvent {
                Id = _.Id,
                Type = _artifacts.GetTypeFor(_.Metadata.Artifact).Name,
                Data = _.Event,
            });
        }
    }

    public class EventViewerEvent
    {
        public EventId Id { get; set; }
        public string Type { get; set; }
        public PropertyBag Data { get; set; }
    }
}
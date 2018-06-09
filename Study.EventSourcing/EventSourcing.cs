using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;

namespace Study.EventSourcing
{
    public class EventSourcing
    {
        public async Task Replay(IBus bus, List<Event.Event> events)
        {
            foreach (var @event in events)
                await bus.Publish(@event);
        }
    }
}
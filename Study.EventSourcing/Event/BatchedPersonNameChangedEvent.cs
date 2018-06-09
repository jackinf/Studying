using System.Collections.Generic;

namespace Study.EventSourcing.Event
{
    public class BatchedPersonNameChangedEvent
    {
        public List<PersonNameChangedEvent> Events { get; set; } = new List<PersonNameChangedEvent>();
    }
}
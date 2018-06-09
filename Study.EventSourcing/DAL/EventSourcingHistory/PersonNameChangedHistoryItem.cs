using System;
using Newtonsoft.Json;
using SQLite;
using Study.EventSourcing.Event;

namespace Study.EventSourcing.DAL.EventSourcingHistory
{
    public class PersonNameChangedHistoryItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Payload { get; set; }
        public DateTime UpdatedOn { get; set; }

        public PersonNameChanged GetEvent() => JsonConvert.DeserializeObject<PersonNameChanged>(Payload);

        public static PersonNameChangedHistoryItem FromEvent(PersonNameChanged @event)
            => new PersonNameChangedHistoryItem
            {
                UpdatedOn = DateTime.UtcNow,
                Payload = JsonConvert.SerializeObject(@event)
            };
    }
}
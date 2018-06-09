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

        public PersonNameChangedEvent GetEvent() => JsonConvert.DeserializeObject<PersonNameChangedEvent>(Payload);
    }
}
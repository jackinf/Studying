namespace Study.EventSourcing.Event
{
    public class PersonNameChangedEvent : Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
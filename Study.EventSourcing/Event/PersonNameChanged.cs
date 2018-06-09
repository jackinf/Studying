namespace Study.EventSourcing.Event
{
    public class PersonNameChanged : Event
    {
        public string Name { get; set; }
    }
}
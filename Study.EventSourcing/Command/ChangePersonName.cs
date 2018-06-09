namespace Study.EventSourcing.Command
{
    public class ChangePersonName
    {
        public int Id { get; set; }
        public string NewName { get; set; }
    }
}
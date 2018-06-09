namespace Study.EventSourcing.Command
{
    public class ChangePersonNameCommand
    {
        public int Id { get; set; }
        public string NewName { get; set; }
    }
}
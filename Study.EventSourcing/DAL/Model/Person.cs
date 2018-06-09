using SQLite;

namespace Study.EventSourcing.DAL
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [Unique]
        public string Keyword { get; set; }
    }
}
using Study.EventSourcing.DAL.EventSourcingHistory;

namespace Study.EventSourcing.DAL.Repository
{
    public class PersonRepository
    {
        private readonly SqliteDbContext _context;

        public PersonRepository(SqliteDbContext context)
        {
            _context = context;
        }

        public int Insert(Person person) => _context.Db.Insert(person);
        public void Update(Person person) => _context.Db.Update(person);
        public Person Get(int id) => _context.Db.Table<Person>().FirstOrDefault(x => x.Id == id);
        public Person Find(string keyword) => _context.Db.Table<Person>().FirstOrDefault(x => x.Keyword == keyword);
    }
}
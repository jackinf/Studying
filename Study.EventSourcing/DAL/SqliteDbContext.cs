using SQLite;
using Study.EventSourcing.DAL.EventSourcingHistory;

namespace Study.EventSourcing.DAL
{
    public class SqliteDbContext
    {
        public SQLiteConnection Db { get; }

        public SqliteDbContext()
        {
            Db = new SQLiteConnection("MyData.db");
        }

        public void CreateTables()
        {
            Db.CreateTable<Person>();
            Db.CreateTable<PersonNameChangedHistoryItem>();
        }
    }
}
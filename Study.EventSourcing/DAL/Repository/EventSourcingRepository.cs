using Study.EventSourcing.DAL.EventSourcingHistory;

namespace Study.EventSourcing.DAL.Repository
{
    public class EventSourcingRepository
    {
        private readonly SqliteDbContext _context;

        public EventSourcingRepository(SqliteDbContext context)
        {
            _context = context;
        }

        public void AddHistoryItem(PersonNameChangedHistoryItem @event) => _context.Db.Insert(@event);
    }
}
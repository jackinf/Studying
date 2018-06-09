using System.Collections.Generic;
using System.Linq;
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

        public List<PersonNameChangedHistoryItem> GetHistoryItems() 
            => _context.Db.Table<PersonNameChangedHistoryItem>().OrderBy(x => x.UpdatedOn).ToList();
        public void AddHistoryItem(PersonNameChangedHistoryItem @event) => _context.Db.Insert(@event);
    }
}
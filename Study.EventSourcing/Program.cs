using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Study.EventSourcing.Command;
using Study.EventSourcing.DAL;
using Study.EventSourcing.DAL.Model;
using Study.EventSourcing.DAL.Repository;
using Study.EventSourcing.Event;

namespace Study.EventSourcing
{
    class Program
    {
        private const string KeywordDummy = "dummy";

        static async Task Main(string[] args)
        {
            var context = new SqliteDbContext();
            context.CreateTables();
            var bus = BusConfigurator.CreateBus();
            await bus.StartAsync();

            // Create or get dummy person
            var personRepository = new PersonRepository(context);
            var person = personRepository.Find(KeywordDummy);
            if (person == null)
            {
                personRepository.Insert(new Person {Name = "John", Keyword = KeywordDummy });
                person = personRepository.Find(KeywordDummy);
            }

            // Replay history
            var historyItems = new EventSourcingRepository(context).GetHistoryItems();
            var events = historyItems?.Select(x => x.GetEvent()).ToList() ?? new List<PersonNameChangedEvent>();
            await bus.Publish(new BatchedPersonNameChangedEvent { Events = events });
            //foreach (var personNameChangedEvent in events)
            //    await bus.Publish(personNameChangedEvent);

            while (true)
            {
                Console.WriteLine("Enter new name");
                var newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                    break;
                await bus.Publish(new ChangePersonNameCommand {Id = person.Id, NewName = newName});
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await bus.StopAsync();
        }
    }
}

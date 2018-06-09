using System;
using System.Threading.Tasks;
using MassTransit;
using Study.EventSourcing.Command;
using Study.EventSourcing.DAL;
using Study.EventSourcing.DAL.Repository;

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

            var personRepository = new PersonRepository(context);
            var person = personRepository.Find(KeywordDummy);
            if (person == null)
            {
                personRepository.Insert(new Person {Name = "John", Keyword = KeywordDummy });
                person = personRepository.Find(KeywordDummy);
            }

            while (true)
            {
                Console.WriteLine("Enter new name");
                var newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                    break;
                await bus.Publish(new ChangePersonName {Id = person.Id, NewName = newName});
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            await bus.StopAsync();
        }
    }
}

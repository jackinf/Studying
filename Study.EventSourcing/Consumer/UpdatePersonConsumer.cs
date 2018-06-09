using System;
using System.Threading.Tasks;
using MassTransit;
using Study.EventSourcing.Command;
using Study.EventSourcing.DAL;
using Study.EventSourcing.DAL.EventSourcingHistory;
using Study.EventSourcing.DAL.Repository;
using Study.EventSourcing.Event;

namespace Study.EventSourcing.Consumer
{
    public class UpdatePersonConsumer : IConsumer<ChangePersonName>, IConsumer<PersonNameChanged>
    {
        /*
         * Commands
         */

        public async Task Consume(ConsumeContext<ChangePersonName> context)
        {
            await Console.Out.WriteLineAsync($"Updating person with id {context.Message.Id} to new name {context.Message.NewName}");

            // db operation
            var personRepository = new PersonRepository(new SqliteDbContext());
            var person = personRepository.Get(context.Message.Id);
            person.Name = context.Message.NewName;
            personRepository.Update(person);
        }

        /*
         * Events
         */

        public async Task Consume(ConsumeContext<PersonNameChanged> context)
        {
            var historyRepository = new EventSourcingRepository(new SqliteDbContext());
            var item = PersonNameChangedHistoryItem.FromEvent(context.Message);
            historyRepository.AddHistoryItem(item);

            await Task.CompletedTask;
        }
    }
}
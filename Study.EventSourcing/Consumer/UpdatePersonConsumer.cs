using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using Newtonsoft.Json;
using Study.EventSourcing.Command;
using Study.EventSourcing.DAL;
using Study.EventSourcing.DAL.EventSourcingHistory;
using Study.EventSourcing.DAL.Repository;
using Study.EventSourcing.Event;

namespace Study.EventSourcing.Consumer
{
    public class UpdatePersonConsumer : 
        IConsumer<ChangePersonNameCommand>,
        IConsumer<BatchedPersonNameChangedEvent>
    {
        private readonly object _lock = new object();
         
        /*
         * Commands
         */

        public async Task Consume(ConsumeContext<ChangePersonNameCommand> context)
        {
            PersonNameChangedHistoryItem FromCommandToHistoryItem(PersonNameChangedEvent eventInner)
                => new PersonNameChangedHistoryItem { UpdatedOn = DateTime.UtcNow, Payload = JsonConvert.SerializeObject(eventInner) };

            PersonNameChangedEvent FromCommandToEvent(ChangePersonNameCommand command)
                => new PersonNameChangedEvent { Id = command.Id, Name = command.NewName };

            // store history item
            var historyRepository = new EventSourcingRepository(new SqliteDbContext());
            var @event = FromCommandToEvent(context.Message);
            var item = FromCommandToHistoryItem(@event);
            historyRepository.AddHistoryItem(item);

            await context.Publish(new BatchedPersonNameChangedEvent { Events = new List<PersonNameChangedEvent> { @event } });
        }

        /*
         * Events
         */

        public async Task Consume(ConsumeContext<BatchedPersonNameChangedEvent> context)
        {
            foreach (var personNameChangedEvent in context.Message.Events)
            {
                await Console.Out.WriteLineAsync($"Updating person with id {personNameChangedEvent.Id} to new name {personNameChangedEvent.Name}");

                // db operation
                var personRepository = new PersonRepository(new SqliteDbContext());
                var person = personRepository.Get(personNameChangedEvent.Id);
                person.Name = personNameChangedEvent.Name;
                lock (_lock)
                    personRepository.Update(person);
            }
        }
    }
}
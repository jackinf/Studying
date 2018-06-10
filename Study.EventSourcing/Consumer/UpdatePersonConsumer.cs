using System;
using System.Collections.Generic;
using System.Threading;
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
        IConsumer<BatchedPersonNameChangedEvent>,
        IConsumer<PersonNameChangedEvent>
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

            await context.Publish(@event);
        }

        /*
         * Events
         */

        public async Task Consume(ConsumeContext<BatchedPersonNameChangedEvent> context)
        {
            foreach (var personNameChangedEvent in context.Message.Events)
                await OnPersonNameChangedEvent(personNameChangedEvent);
        }

        public async Task Consume(ConsumeContext<PersonNameChangedEvent> context)
        {
            await OnPersonNameChangedEvent(context.Message);
        }

        private async Task OnPersonNameChangedEvent(PersonNameChangedEvent personNameChangedEvent)
        {
            Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
            await Console.Out.WriteLineAsync($"Updating person with id {personNameChangedEvent.Id} to new name {personNameChangedEvent.Name}");
            lock (_lock)
            {
                // db operation
                var personRepository = new PersonRepository(new SqliteDbContext());
                var person = personRepository.Get(personNameChangedEvent.Id);
                person.Name = personNameChangedEvent.Name;
                personRepository.Update(person);
            }

        }
    }
}
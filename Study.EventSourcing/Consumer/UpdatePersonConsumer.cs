using System;
using System.Threading.Tasks;
using MassTransit;
using Study.EventSourcing.Command;
using Study.EventSourcing.DAL;
using Study.EventSourcing.DAL.Repository;

namespace Study.EventSourcing.Consumer
{
    public class UpdatePersonConsumer : IConsumer<ChangePersonName>
    {
        public async Task Consume(ConsumeContext<ChangePersonName> context)
        {
            await Console.Out.WriteLineAsync($"Updating person with id {context.Message.Id} to new name {context.Message.NewName}");

            var personRepository = new PersonRepository(new SqliteDbContext());
            var person = personRepository.Get(context.Message.Id);
            person.Name = context.Message.NewName;
            personRepository.Update(person);
        }
    }
}
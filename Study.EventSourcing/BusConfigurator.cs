using System;
using MassTransit;
using Study.EventSourcing.Consumer;

namespace Study.EventSourcing
{
    public class BusConfigurator
    {
        public static IBusControl CreateBus()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri("rabbitmq://localhost"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint(host, "person_queue", ep => ep.Consumer<UpdatePersonConsumer>());
            });
            return bus;
        }
    }
}
using Akka.Actor;
using Study.AkkaNet.Interview.Web.Core.Messaging;

namespace Study.AkkaNet.Interview.Web.Baskets
{
    public class BasketsActor : ReceiveActor
    {
        public IActorRef ProductActor { get; }

        public BasketsActor(IActorRef productActor)
        {
            ProductActor = productActor;

            ReceiveAny(message =>
            {
                switch (message)
                {
                    case MessageWithCustomerId envelope:
                        var child = Context.Child(envelope.CustomerId.ToString());
                        if (child is Nobody)
                            child = Context.ActorOf(BasketActor.Props(ProductActor), envelope.CustomerId.ToString());
                        child.Forward(envelope);
                        break;
                }
            });
        }

        public static Props Props(IActorRef productsActor)
        {
            return Akka.Actor.Props.Create(() => new BasketsActor(productsActor));
        }
    }
}
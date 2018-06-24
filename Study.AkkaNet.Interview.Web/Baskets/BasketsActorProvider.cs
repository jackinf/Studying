using Akka.Actor;
using Study.AkkaNet.Interview.Web.Products;

namespace Study.AkkaNet.Interview.Web.Baskets
{
    public class BasketsActorProvider
    {
        private IActorRef BasketsActorInstance { get; }

        public BasketsActorProvider(ActorSystem actorSystem, ProductsActorProvider provider)
        {
            var productsActor = provider.Get();
            BasketsActorInstance = actorSystem.ActorOf(BasketsActor.Props(productsActor), "baskets");
        }

        public IActorRef Get() => BasketsActorInstance;
    }
}
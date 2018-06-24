using Akka.Actor;

namespace Study.AkkaNet.Interview.Web.Products
{
    public class ProductsActorProvider
    {
        private readonly IActorRef _productsActor;

        public ProductsActorProvider(ActorSystem actorSystem)
        {
            var sampleData = SampleData.Get();
            _productsActor = actorSystem.ActorOf(Props.Create<ProductsActor>(sampleData), "products");
        }

        public IActorRef Get() => _productsActor;
    }
}
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.Logging;

namespace Study.AkkaNet.Interview.Web.Baskets.Routes
{
    public class GetBasket
    {
        private readonly ILogger<GetBasket> _logger;
        private IActorRef _basketActor;

        public GetBasket(BasketsActorProvider provider, ILogger<GetBasket> logger)
        {
            _logger = logger;
            _basketActor = provider.Get();
        }

        public async Task<Basket> Execute(int customerId)
        {
            _logger.LogInformation($"Getting basket with customer id of {customerId}.");
            return await _basketActor.Ask<Basket>(new BasketActor.GetBasket(customerId));
        }
    }
}
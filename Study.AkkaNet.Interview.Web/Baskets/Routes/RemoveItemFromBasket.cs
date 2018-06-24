using System;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Study.AkkaNet.Interview.Web.Baskets.Routes
{
    public class RemoveItemFromBasket
    {
        private readonly ILogger<RemoveItemFromBasket> _logger;
        private readonly IActorRef _basketActor;

        public RemoveItemFromBasket(BasketsActorProvider provider, ILogger<RemoveItemFromBasket> logger)
        {
            _logger = logger;
            _basketActor = provider.Get();
        }

        public async Task<IActionResult> Execute(int customerId, Guid basketItemId)
        {
            _logger.LogInformation($"Removing item {basketItemId} from basket of customer {customerId}");
            var result = await _basketActor.Ask<BasketActor.BasketEvent>(
                new BasketActor.RemoveItemFromBasket(customerId, basketItemId));

            switch (result)
            {
                case BasketActor.ItemRemoved _:
                    return new OkResult();
                case BasketActor.ItemNotFound _:
                    return new NotFoundResult();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Study.AkkaNet.Interview.Web.Baskets.Routes
{
    public class AddItemToBasket
    {
        private readonly ILogger<AddItemToBasket> _logger;
        private readonly IActorRef _basketActor;

        public AddItemToBasket(BasketsActorProvider provider, ILogger<AddItemToBasket> logger)
        {
            _logger = logger;
            _basketActor = provider.Get();
        }

        public async Task<IActionResult> Execute(int customerId, int productId, int amount)
        {
            _logger.LogInformation($"Adding {amount} of product '{productId}' to basket for customer '{customerId}'");
            var result = await _basketActor.Ask<BasketActor.BasketEvent>(
                new BasketActor.AddItemToBasket(customerId, productId, amount)
            );

            switch (result)
            {
                case BasketActor.ItemAdded itemAddedResult:
                    return new CreatedResult($"/api/baskets/{customerId}/", itemAddedResult.BasketItemId);
                case BasketActor.ProductNotFound _:
                case BasketActor.NotInStock _:
                    return new BadRequestResult();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Study.AkkaNet.Interview.Web.Baskets.Routes.Dto;

namespace Study.AkkaNet.Interview.Web.Baskets.Routes
{
    [Route("/baskets")]
    public class BasketApiController
    {
        private GetBasket GetBasket { get; }
        private AddItemToBasket AddItemToBasket { get; }
        private RemoveItemFromBasket RemoveItemFromBasket { get; }

        public BasketApiController(GetBasket getBasket, AddItemToBasket addItemToBasket, RemoveItemFromBasket removeItemFromBasket)
        {
            GetBasket = getBasket;
            AddItemToBasket = addItemToBasket;
            RemoveItemFromBasket = removeItemFromBasket;
        }

        [HttpGet("{customerId}")]
        public async Task<Basket> Get(int customerId) 
            => await GetBasket.Execute(customerId);

        [HttpPut("{customerId}/items")]
        public async Task<IActionResult> PutItem(int customerId, [FromBody] AddItem item) 
            => await AddItemToBasket.Execute(customerId, item.ProductId, item.Amount);

        [HttpDelete("{customerId}/items/{basketItemId}")]
        public async Task<IActionResult> DeleteItem(int customerId, Guid basketItemId) 
            => await RemoveItemFromBasket.Execute(customerId, basketItemId);
    }
}
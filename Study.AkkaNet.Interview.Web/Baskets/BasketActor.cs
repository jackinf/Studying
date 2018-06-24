using System;
using System.Threading.Tasks;
using Akka.Actor;
using Study.AkkaNet.Interview.Web.Products;

namespace Study.AkkaNet.Interview.Web.Baskets
{
    public partial class BasketActor : ReceiveActor
    {
        public Basket BasketState { get; set; } = new Basket();
        public IActorRef ProductsActorRef { get; }

        public BasketActor(IActorRef productsActor)
        {
            ProductsActorRef = productsActor;

            Receive<GetBasket>(_ => Sender.Tell(BasketState));
            ReceiveAsync<AddItemToBasket>(m => AddItemToBasketAction(m).PipeTo(Sender), m => m.Amount > 0);
            Receive<RemoveItemFromBasket>(m => Sender.Tell(RemoveItemToBasketAction(m)));
        }

        public static Props Props(IActorRef productActor) => Akka.Actor.Props.Create(() => new BasketActor(productActor));

        private async Task<BasketEvent> AddItemToBasketAction(AddItemToBasket message)
        {
            var productActorResult = await this.ProductsActorRef.Ask<ProductsActor.ProductEvent>(
                new ProductsActor.UpdateStock(message.ProductId, -message.Amount)
            );

            switch (productActorResult)
            {
                case ProductsActor.StockUpdated _:
                    {
                        var product = ((ProductsActor.StockUpdated)productActorResult).Product;
                        return AddToBasket(product, message.Amount) as ItemAdded;
                    }

                case ProductsActor.ProductNotFound _:
                    return new ProductNotFound();
                case ProductsActor.InsufficientStock _:
                    return new NotInStock();
                default:
                    throw new NotImplementedException($"Unknown response: {productActorResult.GetType().ToString()}");
            }
        }

        private BasketEvent RemoveItemToBasketAction(RemoveItemFromBasket message)
        {
            var basketItem = BasketState.Items.Find(item => item.Id == message.BasketItemId);
            switch (basketItem)
            {
                case BasketItem _:
                    BasketState.Items.Remove(basketItem);
                    return new ItemRemoved();
                default:
                    return new ItemNotFound();
            }
        }

        private ItemAdded AddToBasket(Product productToAdd, int amount)
        {
            var existingBasketItemWithProduct = BasketState.Items.Find(item => item.ProductId == productToAdd.Id);
            switch (existingBasketItemWithProduct)
            {
                case BasketItem _:
                    // Add to existing basket item
                    existingBasketItemWithProduct.Amount += amount;
                    return new ItemAdded(basketItemId: existingBasketItemWithProduct.Id);
                default:
                    // Create a new basket item
                    var basketItemId = Guid.NewGuid();
                    this.BasketState.Items.Add(new BasketItem
                    {
                        Id = basketItemId,
                        ProductId = productToAdd.Id,
                        Title = productToAdd.Title,
                        Brand = productToAdd.Brand,
                        PricePerUnit = productToAdd.PricePerUnit,
                        Amount = amount
                    });

                    return new ItemAdded(basketItemId);
            }
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Akka.Actor;

namespace Study.AkkaNet.Interview.Web.Products
{
    public partial class ProductsActor : ReceiveActor
    {
        public IList<Product> Products { get; }

        public ProductsActor(IList<Product> products)
        {
            Products = products;
            Receive<GetAllProducts>(_ => Sender.Tell(new ReadOnlyCollection<Product>(Products)));
        }

        public ProductEvent UpdateStockAction(UpdateStock message)
        {
            var product = Products.FirstOrDefault(p => p.Id == message.ProductId);
            if (product == null)
                return new ProductNotFound();

            var newAmountChanged = product.InStock + message.AmountChanged;
            if (newAmountChanged < 0)
                return new InsufficientStock();

            product.InStock = newAmountChanged;
            return new StockUpdated(product);
        }
    }
}
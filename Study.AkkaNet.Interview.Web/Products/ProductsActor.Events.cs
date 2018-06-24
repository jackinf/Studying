namespace Study.AkkaNet.Interview.Web.Products
{
    public partial class ProductsActor
    {
        public abstract class ProductEvent { }

        public class ProductFound : ProductEvent
        {
            public Product Product { get; }

            public ProductFound(Product product)
            {
                Product = product;
            }
        }

        public class ProductNotFound : ProductEvent { }

        public class StockUpdated : ProductEvent
        {
            public Product Product { get; }

            public StockUpdated(Product product)
            {
                Product = product;
            }
        }

        public class InsufficientStock : ProductEvent { }
    }
}
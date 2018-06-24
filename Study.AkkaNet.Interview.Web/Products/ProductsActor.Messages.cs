namespace Study.AkkaNet.Interview.Web.Products
{
    public partial class ProductsActor
    {
        public class GetAllProducts { }

        public class UpdateStock
        {
            public int ProductId { get; }
            public int AmountChanged { get; }

            public UpdateStock(int productId = 0, int amountChanged = 0)
            {
                ProductId = productId;
                AmountChanged = amountChanged;
            }
        }
    }
}
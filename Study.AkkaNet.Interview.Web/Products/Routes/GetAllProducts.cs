using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using Microsoft.Extensions.Logging;

namespace Study.AkkaNet.Interview.Web.Products.Routes
{
    public class GetAllProducts
    {
        private readonly ILogger<GetAllProducts> _logger;
        private readonly IActorRef _productsActor;

        public GetAllProducts(ProductActorProvider provider, ILogger<GetAllProducts> logger)
        {
            _logger = logger;
            _productsActor = provider.Get();
        }
        
        public async Task<IEnumerable<Product>> Execute()
        {
            _logger.LogInformation("Requesting all products");
            return await _productsActor.Ask<IEnumerable<Product>>(new ProductsActor.GetAllProducts());
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Study.AkkaNet.Interview.Web.Products.Routes
{
    public class ProductApiController : Controller
    {
        public GetAllProducts GetAllProducts { get; }

        public ProductApiController(GetAllProducts getAllProducts)
        {
            GetAllProducts = getAllProducts;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get() => await this.GetAllProducts.Execute();
    }
}
using Microsoft.Extensions.DependencyInjection;

namespace Study.AkkaNet.Interview.Web.Products
{
    public static class Services
    {
        public static void AddProductServices(this IServiceCollection services)
        {
            services.AddSingleton<ProductsActorProvider>();
            services.AddSingleton<Routes.GetAllProducts>();
        }
    }
}
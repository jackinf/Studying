using System.Collections.Generic;
using Akka.Actor;
using Akka.TestKit.NUnit3;
using NUnit.Framework;
using Study.AkkaNet.Interview.Web.Products;

namespace Study.AkkaNet.Interview.Web.Tests.Products
{
    public class ProductActorTests : TestKit
    {
        private IEnumerable<Product> Products { get; } = GetProductData();

        [Test]
        public void Return_All_Products()
        {
            var actorUnderTest = ActorOf(Props.Create<ProductsActor>(Products));
            actorUnderTest.Tell(new ProductsActor.GetAllProducts());
            var result = ExpectMsg<IEnumerable<Product>>();
            Assert.AreEqual(this.Products, result);
        }

        private static IEnumerable<Product> GetProductData()
        {
            return new List<Product> {
                new Product {
                    Id = 1000,
                    Title = "Product 1",
                    InStock = 1
                },
                new Product {
                    Id = 1001,
                    Title = "Product 2",
                    InStock = 2
                }
            };
        }
    }
}
using System.Collections.Generic;

namespace Study.AkkaNet.Interview.Web.Baskets
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
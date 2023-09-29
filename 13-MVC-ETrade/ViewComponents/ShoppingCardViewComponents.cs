using _13_MVC_ETrade.Models.Entities;
using _13_MVC_ETrade.Models.VMs;
using Microsoft.AspNetCore.Mvc;

namespace _13_MVC_ETrade.ViewComponents
{
    public class ShoppingCardViewComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartItems = new List<Product>
            {
                new Product(){CategoryId=1,Description="Kahve",Name="Türk Kahvesi",Price=50,Stock=20,ProductImage=""},
                new Product(){CategoryId=1,Description="Kahve",Name="Türk Kahvesi",Price=50,Stock=20,ProductImage = ""}
            };

            var model = new ShoppingCartVM
            {
                CartItems = cartItems,
                Price = CalculatePrice(cartItems)
            };
            return View(model);
        }
        private double CalculatePrice(List<Product> cartItems)
        {
            double totalPrice = 0;
            foreach (var item in cartItems)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
    }
}

using _13_MVC_ETrade.Models.Entities;

namespace _13_MVC_ETrade.Models.VMs
{
    public class ShoppingCartVM
    {
        public List<Product> CartItems { get; set; } //Sepetin içindeki ürünler
        public double Price { get; set; } //Ürün fiyat
    }
}

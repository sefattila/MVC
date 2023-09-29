using _13_MVC_ETrade.Models.Entities;

namespace _13_MVC_ETrade.Models.VMs
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}

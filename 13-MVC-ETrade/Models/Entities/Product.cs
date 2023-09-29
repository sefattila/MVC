namespace _13_MVC_ETrade.Models.Entities
{
    public class Product:BaseEntity.BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
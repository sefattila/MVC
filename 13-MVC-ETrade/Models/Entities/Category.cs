using _13_MVC_ETrade.Models.Entities.BaseEntity;
using System.Diagnostics;

namespace _13_MVC_ETrade.Models.Entities
{
    public class Category :BaseEntity.BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
using _13_MVC_ETrade.Models.Entities.Enums;

namespace _13_MVC_ETrade.Models.Entities.BaseEntity
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; } = Status.Active;
    }
}

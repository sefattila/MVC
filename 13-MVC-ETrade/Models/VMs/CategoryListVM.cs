using _13_MVC_ETrade.Models.Entities.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _13_MVC_ETrade.Models.VMs
{
    public class CategoryListVM
    {
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        [DisplayName("Eklenme Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Güncellenme Tarihi")]
        public DateTime? UpdateDate { get; set; }
        [DisplayName("Silinme Tarihi")]
        public DateTime? DeletedDate { get; set; }
        [DisplayName("Durum")]
        public Status Status { get; set; }
    }
}

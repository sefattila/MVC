using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _14_MVC_Identity.Models.VMs
{
    public class UserListVM
    {
        public string Id { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [DisplayName("Soyad")] 
        public string LastName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}

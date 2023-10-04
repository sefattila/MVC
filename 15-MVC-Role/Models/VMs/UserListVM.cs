using System.ComponentModel;

namespace _15_MVC_Role.Models.VMs
{
    public class UserListVM
    {
        public string Id { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
    }
}

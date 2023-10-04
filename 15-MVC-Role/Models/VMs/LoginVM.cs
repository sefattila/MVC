using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace _15_MVC_Role.Models.VMs
{
    public class LoginVM
    {
        [DisplayName("Kullanıcı Adı")]
        [Microsoft.Build.Framework.Required]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        [System.ComponentModel.DataAnnotations.Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

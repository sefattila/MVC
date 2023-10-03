using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _14_MVC_Identity.Models.VMs
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

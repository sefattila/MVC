using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace _14_MVC_Identity.Models.VMs
{
    public class UserEditVM
    {
        public string Id { get; set; }
        [DisplayName("Kullanıcı Adı")]
        [Required]
        public string UserName { get; set; }

        [DisplayName("Adı")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Soyadı")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Telefon")]
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}

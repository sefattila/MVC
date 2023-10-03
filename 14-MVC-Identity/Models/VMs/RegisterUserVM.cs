using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _14_MVC_Identity.Models.VMs
{
    public class RegisterUserVM
    {
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

        [DisplayName("Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Max 10 Min 3", MinimumLength = 3)]
        public string Password { get; set; }

        [DisplayName("Tekrar Şifre")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen Şifreler Uyumlu Olmalıdır")]
        [StringLength(10, ErrorMessage = "Max 10 Min 3", MinimumLength = 3)]
        public string ConfirmPassword { get; set; }
    }
}

using _07_MVC_Validation.ValidationClasses;
using System.ComponentModel.DataAnnotations;

namespace _07_MVC_Validation.Classes
{
    public class SystemUser
    {
        [Required(ErrorMessage ="Kullanıcı adı boş olamaz")]
        [StringLength(10,ErrorMessage ="Kullanıcı adi en az 3 en fazla 10 karakter",MinimumLength =2)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="T.C Kimlik Numarası Boş Geçilemez")]
        [IdentificationNumberValidation(ErrorMessage ="Geçersiz")]
        public long IdentificationNumber { get; set; }
        [Required(ErrorMessage ="Boş Olamaz")]
        [Range(0,100,ErrorMessage ="0-100 arası olmalı")]
        public int Score { get; set; }
        [Required(ErrorMessage ="Boş Olamaz")]
        [EmailAddress(ErrorMessage ="Doğru değil")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Boş Olamaz")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Boş Olamaz")]
        [Compare("Password",ErrorMessage ="Şifreler Aynı Değil")]
        public string PasswordConfirm { get; set; }
    }
}

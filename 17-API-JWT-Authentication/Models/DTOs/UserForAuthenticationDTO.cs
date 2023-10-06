using System.ComponentModel.DataAnnotations;

namespace _17_API_JWT_Authentication.Models.DTOs
{
    public class UserForAuthenticationDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

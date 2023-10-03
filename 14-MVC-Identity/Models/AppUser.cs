using Microsoft.AspNetCore.Identity;

namespace _14_MVC_Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

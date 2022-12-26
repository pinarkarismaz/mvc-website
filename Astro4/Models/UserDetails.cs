using Microsoft.AspNetCore.Identity;
namespace Astro4.Models
{
    public class UserDetails: IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}

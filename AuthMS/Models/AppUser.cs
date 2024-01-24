using Microsoft.AspNetCore.Identity;

namespace AuthMS.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}

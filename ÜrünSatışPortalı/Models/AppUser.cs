using Microsoft.AspNetCore.Identity;

namespace ÜrünSatışPortalı.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}

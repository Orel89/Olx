using Microsoft.AspNetCore.Identity;

namespace OlxInfrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } = null!;
    }
}

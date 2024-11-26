using Microsoft.AspNetCore.Identity;

namespace Entites.TableModels.Membership
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

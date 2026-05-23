using Microsoft.AspNetCore.Identity;

namespace CoffeShop.Models.User
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}

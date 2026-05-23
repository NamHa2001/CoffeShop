using CoffeShop.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Data
{
    public class AuthenDbContext : IdentityDbContext<User>
    {
        public AuthenDbContext(DbContextOptions<AuthenDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed 3 roles: Admin, Editor, User
            var adminRoleId = "1";
            var editorRoleId = "2";
            var userRoleId = "3";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = editorRoleId, Name = "Editor", NormalizedName = "EDITOR" },
                new IdentityRole { Id = userRoleId, Name = "User", NormalizedName = "USER" }
            );
        }
    }
}

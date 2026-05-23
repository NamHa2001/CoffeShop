using CoffeShop.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var vmList = new List<UserRolesVM>();
            foreach (var user in users)
            {
                vmList.Add(new UserRolesVM
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            return View(vmList);
        }

        [HttpGet]
        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.UserId = userId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return View("NotFound");

            ViewBag.UserName = user.UserName;
            var model = new List<ManageUserRolesVM>();
            foreach (var role in _roleManager.Roles)
            {
                model.Add(new ManageUserRolesVM
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Selected = await _userManager.IsInRoleAsync(user, role.Name!)
                });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesVM> model, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return View("NotFound");

            var existingRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existingRoles);
            await _userManager.AddToRolesAsync(user, model.Where(r => r.Selected).Select(r => r.RoleName!));
            return RedirectToAction("Index");
        }
    }
}

using Core.Models;
using DogMVC.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser user = new ()
            {

                FullName = "Riad Hamidov",
                UserName = "Admin",

            };

            await _userManager.CreateAsync(user, "Admin123@");
            await _userManager.AddToRoleAsync(user, "BabatAdmin");
            return Ok("Admin yarandi blet");
        }

        public async Task<IActionResult> CreateRoles()
        {
            IdentityRole role = new IdentityRole("BabatAdmin");
            IdentityRole role2 = new IdentityRole("OrtaAdmin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("rollar artig yaranib!");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM adminLoginVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser user = await _userManager.FindByNameAsync(adminLoginVM.UserName);

            if(user == null)
            {
                ModelState.AddModelError("", "Usernam or password in wrong");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, adminLoginVM.Password, adminLoginVM.IsPersistent, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is in validddd !!!!!!!");
                return View();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}

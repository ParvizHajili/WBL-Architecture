using Entites.Dtos;
using Entites.TableModels.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new();
                applicationUser = await _userManager.FindByEmailAsync(dto.Email);

                if (applicationUser is null)
                {
                    ViewBag.Message = "Email ve ya şifre yanlişdir";
                    goto end;
                }
                var result = await _signInManager.PasswordSignInAsync(applicationUser, dto.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                }
            }
            end:
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new()
                {
                    FirstName = dto.Name,
                    LastName = dto.LastName,
                    UserName = dto.UserName,
                    Email = dto.Email,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(applicationUser, dto.Password);

                if (!result.Succeeded)
                {
                    ViewBag.Message = "Xəta baş verdi";

                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.Code, item.Description);
                    }

                    return View(dto);
                }

                return RedirectToAction("Login");
            }
            return View();
        }
    }
}

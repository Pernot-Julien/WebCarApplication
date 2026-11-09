using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebCarApplication.Models.ViewModels;

namespace WebCarApplication.Controllers
{
    public class CompteController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CompteController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            return RedirectToAction("/");
        }
        [HttpPost]
        [HttpPost]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }

    var user = new IdentityUser
    {
        UserName = model.Email,
        Email = model.Email
    };

    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return RedirectToAction(nameof(Login));
    }

    foreach (var error in result.Errors)
    {
        ModelState.AddModelError("", error.Description);
    }

    return View(model);
}
    }
}

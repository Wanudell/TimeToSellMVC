using Identity.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using TimeToSell.Data.Entity;
using TimeToSell.Data.ViewModels;
using TimeToSell.MVC.Models;

namespace TimeToSell.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            return View(new IndexViewModel { Email = user.Email });
        }

        [Authorize(Roles = "Basic")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromServices] RoleManager<IdentityRole<Guid>> roleManager, RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            User appUser = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = GetIdentityErrors(result.Errors);

                ModelState.AddModelError(string.Empty, errors);
                return View(model);
            }

            if (!(await roleManager.RoleExistsAsync("Basic")))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>("Basic"));
            }

            result = await _userManager.AddToRoleAsync(appUser, "Basic");

            if (!result.Succeeded)
            {
                var errors = GetIdentityErrors(result.Errors);

                ModelState.AddModelError(string.Empty, errors);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromServices] SignInManager<User> signInManager, LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Email yada şifre yanlıştır");

                return View();
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email yada şifre yanlıştır");

                return View();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> SignOut([FromServices] SignInManager<User> signInManager)
        {
            await signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetIdentityErrors(IEnumerable<IdentityError> identityErrors)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var error in identityErrors)
            {
                stringBuilder.Append(error.Description);
                stringBuilder.Append("****");
            }

            return stringBuilder.ToString();
        }
    }
}
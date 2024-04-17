using CrudLoginSignup.Models.user;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrudLoginSignup.Controllers
{
    public class userController:Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public userController(UserManager<User> userManager,SignInManager<User>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Register(Register u) {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = u.Name,
                    UserName = u.Name,
                    Password=u.Password,
                    Email=u.Email,
                    PhoneNumber = u.PhoneNumber
                };
                try
                {

                    var result = await userManager.CreateAsync(user, u.Password!);
                    if (result.Succeeded)
                    {
                      
                        return RedirectToAction("Index", "Home");
                    }
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception appropriately
                 //   Debug.WriteLine($"An error occurred during user creation: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred during user creation.");
                }
            }
            return View();
        }

        public IActionResult Login() {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(Login u)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    u.Name!,
                    u.Password!,
                    false,
                    false
                           );
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "incorrect login attempt");
                return View(u);
            }
            return View(u);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
           return  RedirectToAction("Index", "Home");
        }
    }
}

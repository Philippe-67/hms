using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewHMS.DTO;
using NewHMS.Repositories;

namespace NewHMS.Controllers

    {
        public class UserAuthenticationController : Controller
        {
          //  public IActionResult Index()
            private readonly IUserAuthenticationService _authService;
            public UserAuthenticationController(IUserAuthenticationService authService)
            {
                this._authService = authService;
            }

            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Login(LoginModel model)
            {
                if (!ModelState.IsValid)
                    return View(model);
                var result = await _authService.LoginAsync(model);
                if (result.StatusCode == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["msg"] = result.Message;
                    return RedirectToAction(nameof(Login));
                }
            }

            public IActionResult Registration()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Registration(RegistrationModel model)
            {
                if (!ModelState.IsValid) { return View(model); }
                //model.Role = "user";
                var result = await this._authService.RegisterAsync(model);
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Registration));
            }

            [Authorize]
            public async Task<IActionResult> Logout()
            {
                await this._authService.LogoutAsync();
                return RedirectToAction(nameof(Login));
            }
        }
    }


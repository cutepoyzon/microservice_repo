using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Mango.Web.Models.Dto;
using Mango.Web.Services.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ServiceResponseDto? serviceResponseDto = await _authService.LoginAsync(obj);
            if (serviceResponseDto != null && serviceResponseDto.IsSuccess)
            {
                LoginResponseDto? loginResponseDto = JsonConvert
                    .DeserializeObject<LoginResponseDto?>(Convert.ToString(serviceResponseDto.Result));
                await SignInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
                TempData["success"] = "Login successful.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = serviceResponseDto?.Message;
                return View(obj);
            }
            //else
            //{
            //    ModelState.AddModelError("CustomError", serviceResponseDto.Message);
            //    return View(obj);
            //}
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = StaticDetails.AdminRole,
                    Value = StaticDetails.AdminRole
                },
                new SelectListItem
                {
                    Text = StaticDetails.CustomerRole,
                    Value = StaticDetails.CustomerRole
                }
            };
            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            ServiceResponseDto? result = await _authService.RegisterAsync(obj);
            ServiceResponseDto? assignRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = StaticDetails.CustomerRole;
                }
                assignRole = await _authService.AssignRoleAsync(obj);
                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration successful.";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result?.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = StaticDetails.AdminRole,
                    Value = StaticDetails.AdminRole
                },
                new SelectListItem
                {
                    Text = StaticDetails.CustomerRole,
                    Value = StaticDetails.CustomerRole
                }
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();   
            _tokenProvider.ClearToken();
            return RedirectToAction("Index","Home");
        }

        private async Task SignInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Name).Value));

            identity.AddClaim(new Claim(ClaimTypes.Name,
               jwt.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
               jwt.Claims.FirstOrDefault(x => x.Type == "role").Value));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}

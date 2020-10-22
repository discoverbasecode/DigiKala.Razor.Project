using System.Collections.Generic;
using System.Security.Claims;
using DigiKala.Razor.Common.AesHelper;
using DigiKala.Razor.Domain.Dtos;
using DigiKala.Razor.Domain.Entities;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [TempData]
        public string SuccessMessage { get; set; }
        public DtoLogin DtoLogin { get; set; }

        public void OnGet()
        {

        }
        public IActionResult OnPost(DtoLogin dtoLogin)
        {

            if (ModelState.IsValid)
            {
                string hashpass = HashHelper.MD5Encoding(dtoLogin.Password);
                User user = _unitOfWork.AccountsService.LoginUser(dtoLogin.Mobile, hashpass);
                if (user!=null)
                {
                    if (user.IsActive)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim(ClaimTypes.Name , user.Mobile)
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties()
                        {
                            IsPersistent = dtoLogin.RememberMe
                        };
                        HttpContext.SignInAsync(principal, properties);
                        if (user.Role.Name == "کاربر")
                        {
                            return RedirectToPage("/Dashboard/Panel");
                        }
                        else
                        {
                            return RedirectToPage("/Dashboard/Panel");
                        }
                    }
                    else
                    {
                        return RedirectToPage("/Accounts/ActiveAccount");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password","مشخصات کاربری صحیح نمی باشد");
                }
            }






            return Page();
        }
    }
}

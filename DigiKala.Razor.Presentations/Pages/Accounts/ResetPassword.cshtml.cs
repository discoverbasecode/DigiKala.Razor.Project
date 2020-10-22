using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Domain.Dtos;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Accounts
{
    public class ResetPasswordModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmsHelper _smsHelper;
        public ResetPasswordModel(IUnitOfWork unitOfWork, SmsHelper smsHelper)
        {
            _unitOfWork = unitOfWork;
            _smsHelper = smsHelper;
        }
        [TempData]
        public string ErrorMessage { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        public DtoResetPassword DtoResetPassword { get; set; }



        public void OnGet()
        {
        }
        public IActionResult OnPost(DtoResetPassword dtoResetPassword)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.AccountsService.RestPassword(dtoResetPassword.ActiveCode,dtoResetPassword.Password))
                {
                    SuccessMessage = "بازنشانی کلمه عبور با موفقیت انجام گردید لطفا به صفحه ورود هدایت خواهید شد";
                    return RedirectToPage("/Accounts/Login");
                }
                else
                {
                    ModelState.AddModelError("Password","کد تائید شما اشتباه می باشد");
                }
                
            }
            return Page();
        }
    }
}

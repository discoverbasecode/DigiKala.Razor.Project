using System;
using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Domain.Dtos;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Accounts
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmsHelper _smsHelper;
        [TempData]
        public string SuccessMessage { get; set; }
        public DtoForgotPassword DtoForgotPassword { get; set; }
        public ForgotPasswordModel(IUnitOfWork unitOfWork, SmsHelper smsHelper)
        {
            _unitOfWork = unitOfWork;
            _smsHelper = smsHelper;
        }
      
        
        public void OnGet()
        {
        }

        public IActionResult OnPost(DtoForgotPassword dtoForgotPassword)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.AccountsService.ExistMobileNumber(dtoForgotPassword.Mobile))
                {
                    _smsHelper.smsSender(dtoForgotPassword.Mobile, "کد فعالسازی جهت بازنشانی کلمه عبور" + Environment.NewLine + _unitOfWork.AccountsService.GetUserActiveCode(dtoForgotPassword.Mobile) +  "می باشد");
                    SuccessMessage = "کدفعالسازی جهت بازنشانی کلمه عبور به تلفن همراه " + dtoForgotPassword.Mobile + "ارسال گردید";
                    return RedirectToPage("/Accounts/ResetPassword");
                }
            }

            return Page();
        }
    }
}

using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Common.AesHelper;
using DigiKala.Razor.Common.CodeHelper;
using DigiKala.Razor.Common.ConvensionHelper;
using DigiKala.Razor.Domain.Dtos;
using DigiKala.Razor.Domain.Entities;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using NToastNotify;

namespace DigiKala.Razor.Presentations.Pages.Accounts
{
    public class AccountModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmsHelper _smsHelper;
        private readonly IToastNotification _toastNotification;
        [TempData]
        public string ErrorMessage { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        public DtoRegister DtoRegister { get; set; }
        public AccountModel(IUnitOfWork unitOfWork, SmsHelper smsHelper, IToastNotification toastNotification)
        {
            _unitOfWork = unitOfWork;
            _smsHelper = smsHelper;
            _toastNotification = toastNotification;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(DtoRegister dtoRegister)
        {

            if (ModelState.IsValid)
            {
                if (_unitOfWork.AccountsService.ExistMobileNumber(dtoRegister.Mobile))
                {
                    // Go To Login
                }
                else
                {
                    User user = new User()
                    {
                        Mobile = dtoRegister.Mobile,
                        ActiveCode = CodeHelper.ActiveCode(),
                        Code = null,
                        Date = DateConvertorHelper.ToShamsi(DateTime.Now),
                        FullName = null,
                        IsActive = false,
                        Password = HashHelper.MD5Encoding(dtoRegister.Password),
                        RoleId = _unitOfWork.AccountsService.GetMaxRole(),
                    };
                    _unitOfWork.AccountsService.AddUser(user);
                    _unitOfWork.Save();
                    _unitOfWork.Dispose();
                    SuccessMessage = $" کد فعالسازی به تلفن همراه " + dtoRegister.Mobile + "ارسال گردید";
                    _smsHelper.smsSender(dtoRegister.Mobile, " به فروشگاه خوش آمدید " + Environment.NewLine + " کد فعالسازی شما : " + user.ActiveCode + "  می باشد ");
                    return RedirectToPage("/Accounts/ActiveAccount");
                }
            }
            return Page();
        }


    }
}

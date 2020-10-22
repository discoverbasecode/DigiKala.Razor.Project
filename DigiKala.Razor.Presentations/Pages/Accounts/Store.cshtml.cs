using System;
using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Common.AesHelper;
using DigiKala.Razor.Common.CodeHelper;
using DigiKala.Razor.Common.ConvensionHelper;
using DigiKala.Razor.Domain.Dtos;
using DigiKala.Razor.Domain.Entities;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Accounts
{
    public class StoreModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmsHelper _smsHelper;
        public StoreModel(IUnitOfWork unitOfWork, SmsHelper smsHelper)
        {
            _unitOfWork = unitOfWork;
            _smsHelper = smsHelper;
        }
        [TempData]
        public string ErrorMessage { get; set; }
        [TempData]
        public string SuccessMessage { get; set; }
        public DtoStoreRegister DtoStoreRegister { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(DtoStoreRegister dtoStoreRegister)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.AccountsService.ExistMailAddress(dtoStoreRegister.Mail))
                {
                    ErrorMessage = "جهت ساخت فروشگاه نمیتوانید از این امیل استفاده کنید";
                }
                else
                {
                    int userId = 0;

                    if (_unitOfWork.AccountsService.ExistMobileNumber(dtoStoreRegister.Mobile))
                    {
                        _unitOfWork.AccountsService.UpdateUserRole(dtoStoreRegister.Mobile);
                        userId = _unitOfWork.AccountsService.GetUserId(dtoStoreRegister.Mobile);
                    }
                    else
                    {
                        User user = new User()
                        {
                            ActiveCode = CodeHelper.ActiveCode(),
                            Code = null,
                            IsActive = false,
                            FullName = null,
                            Mobile = dtoStoreRegister.Mobile,
                            Password = HashHelper.MD5Encoding(dtoStoreRegister.Password),
                            RoleId = _unitOfWork.AccountsService.GetStoreRole(),
                            Date = DateConvertorHelper.ToShamsi(DateTime.Now)
                        };
                        _unitOfWork.AccountsService.AddUser(user);
                        _unitOfWork.Save();
                        _unitOfWork.Dispose();
                        userId = user.Id;
                    }
                    Store store = new Store()
                    {
                        Address = null,
                        Desc = null,
                        Logo = null,
                        Mail = dtoStoreRegister.Mail,
                        MailActivate = false,
                        MobileActivate = false,
                        Tel = null,
                        UserId = userId,
                        Name = null,
                        MailActivateCode = CodeHelper.ActiveCode()
                    };
                    _unitOfWork.AccountsService.AddStore(store);
                    _unitOfWork.Save();
                    _unitOfWork.Dispose();
                    return RedirectToPage("/Accounts/Login");
                }
            }

            return Page();
        }
    }
}

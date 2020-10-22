using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Domain.Dtos;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Accounts
{
    public class ActiveAccountModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmsHelper _smsHelper;
        [TempData]
        public string SuccessMessage { get; set; }
        public DtoActivate DtoActivate { get; set; }
        public ActiveAccountModel(IUnitOfWork unitOfWork, SmsHelper smsHelper)
        {
            _unitOfWork = unitOfWork;
            _smsHelper = smsHelper;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(DtoActivate dtoActivate)
        {
            if (ModelState.IsValid)
            {
                if (_unitOfWork.AccountsService.ActivateUser(dtoActivate.ActiveCode))
                {
                    SuccessMessage = "حساب کاربری با موفقیت فعال گردید";

                    return RedirectToPage("/Accounts/Login");
                }
                else
                {
                    ModelState.AddModelError("ActiveCode", "کد فعالسازی شما معتبر می باشد");
                }
            }



            return Page();
        }
    }
}

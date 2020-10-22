using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Dashboard
{
    [Authorize]
    public class PanelModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SmsHelper _smsHelper;

        public PanelModel(IUnitOfWork unitOfWork, SmsHelper smsHelper)
        {
            _unitOfWork = unitOfWork;
            _smsHelper = smsHelper;
        }
        public void OnGet()
        {
        }
    }
}

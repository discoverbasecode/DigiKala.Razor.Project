using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigiKala.Razor.Presentations.Pages.Dashboard
{
    [Authorize]
    public class UserProfileModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

using DigiKala.Razor.Services.Infrastructure;

namespace DigiKala.Razor.Services.ScopeHelper
{
    public class PanelLayOutScope
    { 
        private readonly IUnitOfWork _unitOfWork;
        public PanelLayOutScope(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetUserRoleName(string userName)
        {
         return _unitOfWork.UserService.GetUserRoleName(userName);

        }
    }
}
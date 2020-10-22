using System;
using DigiKala.Razor.Services.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DigiKala.Razor.Services.AttributeHelper
{
    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int _permessionId;
        private IUserService _userService;
        public RoleAttribute(int permessionId)
        {
            _permessionId = permessionId;
        }
        public RoleAttribute(int permessionId, IUserService userService)
        {
            _permessionId = permessionId;
            _userService = userService;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string userName = context.HttpContext.User.Identity.Name;
                _userService = (IUserService) context.HttpContext.RequestServices.GetService(typeof(IUserService));
                int roleId = _userService.GetUserRole(userName);
                if (!_userService.ExistPermission(_permessionId,roleId))
                {
                    context.Result = new RedirectResult("/Accounts/Login");
                }
            }
            else
            {
                context.Result = new RedirectResult("Accounts/Login");
            }
        }
    }
}
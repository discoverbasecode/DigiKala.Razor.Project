﻿using System.Linq;
using DigiKala.Razor.Data.DataBaseContext;
using DigiKala.Razor.Services.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace DigiKala.Razor.Services.Services
{
    public class UserService:IUserService
    {
        private DigiKalaContext _context;
        public UserService(DigiKalaContext context)
        {
            _context = context;
        }
        public bool ExistPermission(int permissionId, int roleId)
        {
            return _context.RolePermissions.Any(e => e.PermissionId == permissionId && e.RoleId == roleId);
        }
        public int GetUserRole(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.Mobile != null && u.Mobile == userName).RoleId;
        }

        public string GetUserRoleName(string userName)
        {
            return _context.Users.Include(u=>u.Role).FirstOrDefault(u => u.Mobile != null && u.Mobile == userName).Role.Name;
        }
    }
}
using System.Linq;
using DigiKala.Razor.Common.AesHelper;
using DigiKala.Razor.Common.CodeHelper;
using DigiKala.Razor.Data.DataBaseContext;
using DigiKala.Razor.Domain.Entities;
using DigiKala.Razor.Services.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace DigiKala.Razor.Services.Services
{
    public class AccountsService:IAccountsService
    {
        protected readonly DigiKalaContext Context;
        public AccountsService(DigiKalaContext context)
        {
            Context = context;
        }
        public bool ExistMobileNumber(string mobileNumber)
        {
            return Context.Users.Any(u => u.Mobile == mobileNumber);
        }
        public void AddUser(User user)
        {
            Context.Add(user);
            Context.SaveChanges();
        }
        public int GetMaxRole()
        {
            return Context.Roles.Max(r => r.Id);
        }
        public bool ActivateUser(string code)
        {
            User user = Context.Users.FirstOrDefault(u => u.IsActive == false && u.ActiveCode == code);
            if (user != null)
            {
                user.IsActive = true;
                user.Code = CodeHelper.ActiveCode();
                Context.SaveChanges();
                return true;
            }
            return false;
        }
        public User LoginUser(string mobileNumber, string password)
        {
            return Context.Users.Include(u => u.Role).FirstOrDefault(u => u.Mobile == mobileNumber && u.Password == password);
        }
        public bool RestPassword(string activeCode, string password)
        {
            User user = Context.Users.FirstOrDefault(u => u.ActiveCode == activeCode);
            if (user != null)
            {
                user.Password = HashHelper.MD5Encoding(password);
                user.ActiveCode = CodeHelper.ActiveCode();
                Context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public string GetUserActiveCode(string mobileNumber)
        {
            return Context.Users.FirstOrDefault(u => u.Mobile == mobileNumber)?.ActiveCode;
        }
        public void AddStore(Store store)
        {
            Context.Stores.Add(store);
            Context.SaveChanges();
        }
        public void UpdateUserRole(string mobileNumber)
        {
            User user = Context.Users.FirstOrDefault(u => u.Mobile == mobileNumber);
            Role role = Context.Roles.FirstOrDefault(r => r.Name == "فروشگاه");
            if (user != null)
                if (role != null)
                    user.RoleId = role.Id;
            if (user != null) user.IsActive = false;
            Context.SaveChanges();
        }
        public int GetStoreRole()
        {
            return Context.Roles.FirstOrDefault(r => r.Name == "فروشگاه").Id;
        }
        public int GetUserId(string mobileNumber)
        {
            return Context.Users.FirstOrDefault(u => u.Mobile == mobileNumber).Id;
        }
        public bool ExistMailAddress(string mailAddress)
        {
            return Context.Stores.Any(s => s.Mail == mailAddress);
        }
    }
}
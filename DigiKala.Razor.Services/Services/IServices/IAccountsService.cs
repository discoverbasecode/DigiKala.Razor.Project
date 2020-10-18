using DigiKala.Razor.Domain.Entities;

namespace DigiKala.Razor.Services.Services.IServices
{
    public interface IAccountsService
    {
        bool ExistMobileNumber(string mobileNumber);
        void AddUser(User user);
        int GetMaxRole();
        bool ActivateUser(string code);
        User LoginUser(string mobileNumber, string password);
        bool RestPassword(string activeCode, string password);
        string GetUserActiveCode(string mobileNumber);
        void AddStore(Store store);
        void UpdateUserRole(string mobileNumber);
        int GetStoreRole();
        int GetUserId(string mobileNumber);
        bool ExistMailAddress(string mailAddress);
    }
}
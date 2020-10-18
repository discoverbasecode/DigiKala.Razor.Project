namespace DigiKala.Razor.Services.Services.IServices
{
    public interface IUserService
    {
        bool ExistPermission(int permissionId, int roleId);
        int GetUserRole(string userName);
    }
}
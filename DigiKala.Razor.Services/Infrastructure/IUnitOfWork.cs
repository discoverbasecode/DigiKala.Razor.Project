using System;
using DigiKala.Razor.Services.Services.IServices;

namespace DigiKala.Razor.Services.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {
        IUserService UserService { get; }
        IAccountsService AccountsService { get; }
        public void Save();

    }
}
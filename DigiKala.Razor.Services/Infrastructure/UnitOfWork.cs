using System;
using DigiKala.Razor.Data.DataBaseContext;
using DigiKala.Razor.Services.Services;
using DigiKala.Razor.Services.Services.IServices;

namespace DigiKala.Razor.Services.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        #region Ctor

        protected readonly DigiKalaContext _context;
        public UnitOfWork(DigiKalaContext context)
        {
            _context = context;
        }

        #endregion

        #region UoW-Config

        private IUserService _userService;
        public IUserService UserService
        {
            get
            {
                if (_userService != null) return _userService;
                _userService = new UserService(_context);
                return _userService;
            }
        }

        //*********************************************

        private IAccountsService _accountsService;
        public IAccountsService AccountsService
        {
            get
            {
                if (_accountsService != null) return _accountsService;
                _accountsService = new AccountsService(_context);
                return _accountsService;
            }
        }

        //*********************************************

        #endregion

        #region Disposable - Save
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
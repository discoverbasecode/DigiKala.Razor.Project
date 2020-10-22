using System;
using DigiKala.Common.SenderHelper;
using DigiKala.Razor.Data.DataBaseContext;
using DigiKala.Razor.Services.Infrastructure;
using DigiKala.Razor.Services.ScopeHelper;
using DigiKala.Razor.Services.Services;
using DigiKala.Razor.Services.Services.IServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NToastNotify;

namespace DigiKala.Razor.Presentations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            #region Services-Common
            services.AddRazorPages();
            services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
            {
                PositionClass = ToastPositions.TopRight,
                ProgressBar = false,
                CloseButton = true,
                NewestOnTop = false,
                PreventDuplicates = false,
                ShowDuration = 1000,
                HideDuration = 10000,
                TimeOut = 5000,
                ExtendedTimeOut = 1000,
                Debug = false,
                ShowEasing = "swing",
                HideEasing = "linear",
                ShowMethod = "fadeIn",
                HideMethod = "fadeOut",
            }, new NToastNotifyOption()
            {
                DefaultSuccessMessage = "Bienvenido a CIT",
                DefaultSuccessTitle = "|CIT|"
            });
            services.AddRazorPages().AddNToastNotifyToastr();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            #endregion

            #region Services-AddContext

            services.AddDbContext<DigiKalaContext>();

            #endregion

            #region Services-UseAuthentication

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Accounts/Login";
                options.LogoutPath = "/Accounts/LogOut";
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
            });

            #endregion

            #region Services-DIOC-Scoped-Transient-Singleton
            services.AddScoped(typeof(SmsHelper));
            services.AddScoped(typeof(PanelLayOutScope));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountsService, AccountsService>();
            #endregion


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNToastNotify();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

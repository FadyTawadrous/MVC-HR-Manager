using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Tiers.DAL.Repo.Abstraction;
using Tiers.DAL.Repo.Implementation;

namespace Tiers.DAL.Common
{
    public static class ModularDataAccessLayer
    {
        public static IServiceCollection AddBusinessInDAL(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            //    options =>
            //    {
            //        options.LoginPath = new PathString("/Account/Login");
            //        options.AccessDeniedPath = new PathString("/Account/Login");
            //    });

            //services.AddIdentityCore<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddTokenProvider<DataProtectorTokenProvider<Employee>>(TokenOptions.DefaultProvider);

            return services;
        }
    }
}

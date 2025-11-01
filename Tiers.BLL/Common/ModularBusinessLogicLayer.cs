using Tiers.BLL.AutoMapper;
using Tiers.BLL.Service.Abstraction;
using Tiers.BLL.Service.Implementation;

namespace Tiers.BLL.Common
{
    public static class ModularBusinessLogicLayer
    {
        public static IServiceCollection AddBusinessInBLL(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            return services;
        }
    }
}

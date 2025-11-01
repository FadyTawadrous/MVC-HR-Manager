using Tiers.BLL.ModelVM.Department;
using Tiers.BLL.ModelVM.Employee;
using Tiers.DAL.Entity;

namespace Tiers.BLL.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // 1- Employee mappings
            CreateMap<Employee, GetEmployeeVM>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : ""));

            CreateMap<CreateEmployeeVM, Employee>()
                .ConstructUsing(vm => new Employee(
                    vm.Name,
                    vm.Salary,
                    vm.Age,
                    vm.ImageUrl ?? string.Empty,
                    vm.DepartmentId,
                    vm.CreatedBy
                    ));

            CreateMap<Employee, UpdateEmployeeVM>().ReverseMap();

            CreateMap<Employee, DeleteEmployeeVM>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : ""));
            //CreateMap<DeleteEmployeeVM, Employee>();

            // 2- Department mappings
            CreateMap<Department, GetDepartmentVM>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees != null ? src.Employees.Count : 0));

            CreateMap<CreateDepartmentVM, Department>()
                .ConstructUsing(vm => new Department(
                    vm.Name,
                    vm.Area,
                    vm.CreatedBy
                    ));

            
            CreateMap<Department, UpdateDepartmentVM>().ReverseMap();

            CreateMap<Department, DeleteDepartmentVM>().ReverseMap();

        }

    }
}

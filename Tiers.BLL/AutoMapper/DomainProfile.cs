using Tiers.BLL.ModelVM.Department;
using Tiers.BLL.ModelVM.Employee;
using Tiers.DAL.Entity;

namespace Tiers.BLL.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Employee mappings
            CreateMap<Employee, GetEmployeeVM>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : ""));

            //CreateMap<CreateEmployeeVM, Employee>()
            //    .ForMember(dest => dest.ImageUrl, opt => opt.Ignore()); // ImageUrl set after upload

            CreateMap<Employee, UpdateEmployeeVM>()
                .ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Departments, opt => opt.Ignore());

            //CreateMap<UpdateEmployeeVM, Employee>()
            //    .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            CreateMap<Employee, DeleteEmployeeVM>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : ""));
            //CreateMap<DeleteEmployeeVM, Employee>()
            //    .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            // Department mappings
            CreateMap<Department, GetDepartmentVM>()
                .ForMember(dest => dest.EmployeeCount, opt => opt.MapFrom(src => src.Employees != null ? src.Employees.Count : 0));

            CreateMap<Department, DeleteDepartmentVM>();
            CreateMap<Department, UpdateDepartmentVM>();
            //CreateMap<CreateDepartmentVM, Department>();
            //CreateMap<UpdateDepartmentVM, Department>().ReverseMap();
        }

    }
}

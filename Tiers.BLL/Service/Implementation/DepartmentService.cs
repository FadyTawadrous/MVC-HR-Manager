using Tiers.BLL.ModelVM.Department;
using Tiers.DAL.Entity;
using Tiers.DAL.Repo.Abstraction;

namespace Tiers.BLL.Service.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepo departmentRepo, IMapper mapper)
        {
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }

        public async Task<ResponseResult<IEnumerable<GetDepartmentVM>>> GetAllAsync()
        {
            try
            {
                // Include Employees so AutoMapper can get the EmployeeCount
                var departments = await _departmentRepo.GetAllAsync(d => !d.IsDeleted, includes: d => d.Employees);
                var mappedResult = _mapper.Map<IEnumerable<GetDepartmentVM>>(departments);
                return new ResponseResult<IEnumerable<GetDepartmentVM>>(mappedResult, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<GetDepartmentVM>>(null, ex.Message, false);
            }
        }

        public async Task<ResponseResult<GetDepartmentVM>> GetByIdAsync(int id)
        {
            try
            {
                var department = await _departmentRepo.GetByIdAsync(id);
                if (department == null || department.IsDeleted)
                {
                    return new ResponseResult<GetDepartmentVM>(null, "Department not found.", false);
                }

                var mapped = _mapper.Map<GetDepartmentVM>(department);
                return new ResponseResult<GetDepartmentVM>(mapped, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<GetDepartmentVM>(null, ex.Message, false);
            }
        }

        public async Task<ResponseResult<bool>> CreateAsync(CreateDepartmentVM model)
        {
            try
            {
                var department = _mapper.Map<Department>(model);

                var result = await _departmentRepo.AddAsync(department);

                if (result)
                {
                    return new ResponseResult<bool>(true, null, true);
                }
                else
                {
                    return new ResponseResult<bool>(false, "Failed to save department.", false);
                }
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool>(false, ex.Message, false);
            }
        }

        public async Task<ResponseResult<UpdateDepartmentVM>> GetUpdateModelAsync(int id)
        {
            try
            {
                var department = await _departmentRepo.GetByIdAsync(id);
                if (department == null || department.IsDeleted)
                {
                    return new ResponseResult<UpdateDepartmentVM>(null, "Department not found.", false);
                }

                var model = _mapper.Map<UpdateDepartmentVM>(department);
                return new ResponseResult<UpdateDepartmentVM>(model, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<UpdateDepartmentVM>(null, ex.Message, false);
            }
        }

        public async Task<ResponseResult<bool>> UpdateAsync(UpdateDepartmentVM newDepartment)
        {
            try
            {
                var deptToUpdate = await _departmentRepo.GetByIdAsync(newDepartment.Id);
                if (deptToUpdate == null)
                {
                    return new ResponseResult<bool>(false, "Department not found.", false);
                }

                var department = _mapper.Map<Department>(newDepartment);

                var result = await _departmentRepo.UpdateAsync(department);

                return new ResponseResult<bool>(result, null, result);
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool>(false, ex.Message, false);
            }
        }

        public async Task<ResponseResult<DeleteDepartmentVM>> GetDeleteModelAsync(int id)
        {
            try
            {
                var department = await _departmentRepo.GetByIdAsync(id);
                if (department == null || department.IsDeleted)
                {
                    return new ResponseResult<DeleteDepartmentVM>(null, "Department not found.", false);
                }

                var model = _mapper.Map<DeleteDepartmentVM>(department);

                return new ResponseResult<DeleteDepartmentVM>(model, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<DeleteDepartmentVM>(null, ex.Message, false);
            }
        }

        public async Task<ResponseResult<bool>> DeleteAsync(DeleteDepartmentVM model)
        {
            try
            {
                var deptToDelete = await _departmentRepo.GetByIdAsync(model.Id);
                if (deptToDelete == null)
                {
                    return new ResponseResult<bool>(false, "Department not found.", false);
                }
                if (deptToDelete.Employees != null && deptToDelete.Employees.Count > 0)
                {
                    return new ResponseResult<bool>(false, "Cannot delete department with assigned employees.", false);
                }

                var toggleResult = await _departmentRepo.ToggleDeleteStatusAsync(model.Id, model.DeletedBy);

                if (!toggleResult)
                {
                    return new ResponseResult<bool>(false, "Failed to toggle delete status.", false);
                }
                return new ResponseResult<bool>(toggleResult, null, toggleResult);
            }
            catch (Exception ex)
            {
                return new ResponseResult<bool>(false, ex.Message, false);
            }
        }

    }
}

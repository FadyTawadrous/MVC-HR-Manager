using Tiers.BLL.ModelVM.Department;

namespace Tiers.BLL.Service.Abstraction
{
    public interface IDepartmentService
    {
        Task<ResponseResult<IEnumerable<GetDepartmentVM>>> GetAllAsync();
        Task<ResponseResult<GetDepartmentVM>> GetByIdAsync(int id);

        Task<ResponseResult<bool>> CreateAsync(CreateDepartmentVM model);

        Task<ResponseResult<UpdateDepartmentVM>> GetUpdateModelAsync(int id);
        Task<ResponseResult<bool>> UpdateAsync(UpdateDepartmentVM model);

        Task<ResponseResult<DeleteDepartmentVM>> GetDeleteModelAsync(int id);
        Task<ResponseResult<bool>> DeleteAsync(DeleteDepartmentVM model);

    }
}

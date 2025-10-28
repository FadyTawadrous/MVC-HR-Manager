using Tiers.BLL.ModelVM.Employee;
using Tiers.BLL.Service.Abstraction;
using Tiers.DAL.Entity;
using Tiers.DAL.Repo.Abstraction;

namespace Tiers.BLL.Service.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IDepartmentRepo _departmentRepo;

        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepo employeeRepo, IDepartmentRepo departmentRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
            _mapper = mapper;
        }
        public async Task<ResponseResult<IEnumerable<GetEmployeeVM>>> GetAllAsync()
        {
            try
            {
                var result = await _employeeRepo.GetAllAsync(e => e.IsDeleted == false);
                var mappedResult = _mapper.Map<IEnumerable<GetEmployeeVM>>(result);

                return new ResponseResult<IEnumerable<GetEmployeeVM>>(mappedResult, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<IEnumerable<GetEmployeeVM>>(null, ex.Message, false);
            }
        }

        public ResponseResult<List<GetEmployeeVM>> GetNotActiveEmployees()
        {
            try
            {
                var result = _employeeRepo.GetAll(e => e.IsDeleted == true).ToList();
                var mappedResult = result.Select(e => new GetEmployeeVM
                {
                    Id = e.Id,
                    Name = e.Name
                }).ToList();

                return new ResponseResult<List<GetEmployeeVM>>(mappedResult, null, true);
            }
            catch (Exception ex)
            {
                return new ResponseResult<List<GetEmployeeVM>>(null, ex.Message, false);
            }
        }
    }
}

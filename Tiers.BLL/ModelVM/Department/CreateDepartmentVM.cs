
namespace Tiers.BLL.ModelVM.Department
{
    public class CreateDepartmentVM
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Area { get; set; } = string.Empty;

        [Required]
        public string CreatedBy { get; set; } = string.Empty;
    }
}

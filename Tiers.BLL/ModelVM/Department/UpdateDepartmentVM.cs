
namespace Tiers.BLL.ModelVM.Department
{
    public class UpdateDepartmentVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Area { get; set; } = string.Empty;

        [Required]
        public string UpdatedBy { get; set; } = string.Empty;

    }
}

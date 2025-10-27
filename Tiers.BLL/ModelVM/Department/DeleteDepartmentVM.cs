
namespace Tiers.BLL.ModelVM.Department
{
    public class DeleteDepartmentVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Area { get; set; } = string.Empty;

        [Required]
        public string DeletedBy { get; set; } = string.Empty;

    }
}

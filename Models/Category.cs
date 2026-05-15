
namespace ActivityService.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? ColorCode { get; set; }

        public bool IsSystemDefined { get; set; } = true;

        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}


using ActivityService.DTOs.Request;

namespace ActivityService.DTOs.Common
{
    public class CategoryRequestResponse 
    {
        public string Name { get; set; } = null!;
        public string? ColorCode { get; set; }

        public bool IsSystemDefined { get; set; } = true;

        public ICollection<ActivityRequest> Activities { get; set; } = new List<ActivityRequest>();
    }
}

using ActivityService.DTOs.Request;
using ActivityService.DTOs.Response;
using ActivityService.Models;
using AutoMapper;

namespace ActivityService.Automapper
{
    public class ActivityMapper : Profile
    {
        public ActivityMapper() {

            CreateMap<ActivityRequest, Activity>();

            CreateMap<Activity, ActivityResponse>();

            CreateMap<ActivityTrackingRequest, ActivityTracking>();

            CreateMap<ActivityTracking, ActivityTrackingResponse>();
        }
    }
}

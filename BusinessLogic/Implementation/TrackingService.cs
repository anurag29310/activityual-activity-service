using ActivityService.BusinessLogic.Interface;
using ActivityService.Data;
using ActivityService.DTOs.Request;
using ActivityService.DTOs.Response;
using ActivityService.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.BusinessLogic.Implementation
{
    public class TrackingService : ITrackingService
    {
        private readonly ActivityDbContext _context;

        public TrackingService(ActivityDbContext context)
        {
            _context = context;
        }

        public async Task<ActivityTrackingResponse> AddUserTrackingDataAsync(
            ActivityTrackingRequest request)
        {
            var entity = new ActivityTracking
            {
                Id = Guid.NewGuid(),
                ActivityId = request.ActivityId,
                UserId = request.UserId,
                Date = request.Date,
                Status = request.Status,
                ActualCount = request.ActualCount,
                Notes = request.Notes
            };

            _context.Trackings.Add(entity);

            await _context.SaveChangesAsync();

            return MapToResponse(entity);
        }

        public async Task<List<ActivityTrackingResponse>> AddBulkTrackingDataAsync(
            List<ActivityTrackingRequest> requests)
        {
            var entities = requests.Select(request => new ActivityTracking
            {
                Id = Guid.NewGuid(),
                ActivityId = request.ActivityId,
                UserId = request.UserId,
                Date = request.Date,
                Status = request.Status,
                ActualCount = request.ActualCount,
                Notes = request.Notes
            }).ToList();

            _context.Trackings.AddRange(entities);

            await _context.SaveChangesAsync();

            return entities.Select(MapToResponse).ToList();
        }

        public async Task<List<ActivityTrackingResponse>> GetAllUserTrackingDataAsync()
        {
            var data = await _context.Trackings.ToListAsync();

            return data.Select(MapToResponse).ToList();
        }

        public async Task<ActivityTrackingResponse?> GetUserTrackingDataByIdAsync(Guid id)
        {
            var entity = await _context.Trackings.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return null;

            return MapToResponse(entity);
        }

        public async Task<bool> DeleteUserTrackingDataByIdAsync(Guid id)
        {
            var entity = await _context.Trackings.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return false;

            _context.Trackings.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        private static ActivityTrackingResponse MapToResponse(ActivityTracking entity)
        {
            return new ActivityTrackingResponse
            {
                ActivityId = entity.ActivityId,
                UserId = entity.UserId,
                Date = entity.Date,
                Status = entity.Status,
                ActualCount = entity.ActualCount,
                Notes = entity.Notes
            };
        }
    }
}

using ActivityService.BusinessLogic.Interface;
using ActivityService.Data;
using ActivityService.DTOs.Request;
using ActivityService.DTOs.Response;
using ActivityService.Messaging;
using ActivityService.Models;
using AutoMapper;
using Common.Shared.Event.Events;
using Microsoft.EntityFrameworkCore;
using System;

namespace ActivityService.BusinessLogic.Implementation
{
    public class TrackingService : ITrackingService
    {
        private readonly IMapper _mapper;
        private readonly ActivityDbContext _context;
        private readonly RabbitMqPublisher _publisher;

        public TrackingService(IMapper mapper, ActivityDbContext context, RabbitMqPublisher publisher)
        {
            _mapper = mapper;
            _context = context;
            _publisher = publisher;
        }

        public async Task<string> AddUserTrackingDataAsync(
            ActivityTrackingRequest request)
        {

            try
            {
                var mappTracking = _mapper.Map<ActivityTracking>(request);

                _context.Trackings.Add(mappTracking);

                await _context.SaveChangesAsync();

                var userActivity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == request.ActivityId);

                var trackingEvent = new ActivityCompletedEvent
                {
                    UserId = mappTracking.UserId,
                    ActivityId = mappTracking.ActivityId,
                    Status = mappTracking.Status.ToString(),
                    ActivityTitle = userActivity.Title,
                    Notes = userActivity.Notes,
                    CompletedAt = DateTime.UtcNow
                };
                await _publisher.Publish(trackingEvent, "activity-completed");

                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
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
            var mappTracking = _mapper.Map<List<ActivityTrackingResponse>>(data);

            return mappTracking;
        }

        public async Task<ActivityTrackingResponse?> GetUserTrackingDataByIdAsync(Guid id)
        {
            var entity = await _context.Trackings.FirstOrDefaultAsync(x => x.Id == id);

            var mappTracking = _mapper.Map<ActivityTrackingResponse>(entity);

            if (entity == null)
                return null;

            return mappTracking;
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

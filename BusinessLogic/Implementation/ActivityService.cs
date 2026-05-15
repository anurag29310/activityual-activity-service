using ActivityService.BusinessLogic.Interface;
using ActivityService.Data;
using ActivityService.DTOs.Request;
using ActivityService.DTOs.Response;
using ActivityService.Messaging;
using ActivityService.Models;
using AutoMapper;
using Common.Shared.Event.Events;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.BusinessLogic.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly ActivityDbContext _context;
        private readonly IMapper _mapper;
        private readonly RabbitMqPublisher _publisher;
        public ActivityService(IConfiguration config, ActivityDbContext context, IMapper mapper, RabbitMqPublisher publisher)
        {
            _context = context;
            _mapper = mapper;
            _publisher = publisher;
        }

        public async Task<List<Activity>> GetUserActivityAsync()
        {
            try
            {
                return await _context.Activities.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> CreateUserActivityAsync(ActivityRequest activity)
        {
            try
            {
                if(activity == null)
                {
                    throw new ArgumentNullException(nameof(activity));
                }
                var mappActivity = _mapper.Map<Activity>(activity);
                _context.Activities.Add(mappActivity);
                await _context.SaveChangesAsync();
                return "Success"; ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActivityResponse> GetUserActivityByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var guidId))
                {
                    return null; // Or handle invalid ID as needed
                }

                var userActivity = await _context.Activities.FirstOrDefaultAsync(x => x.Id == guidId);

                var mappActivity = _mapper.Map<ActivityResponse>(userActivity);

                return mappActivity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateUserAcitivityByIdAsync(ActivityRequest activity)
        {
            try
            {
                var userActivityById = await _context.Activities.FirstOrDefaultAsync(x => x.Id == activity.UserId);

                if (userActivityById == null)
                {
                }
                var mappActivity = _mapper.Map<Activity>(activity);

                _context.Activities.Update(mappActivity);
                await _context.SaveChangesAsync();
                return "Success";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> DeleteUserAcitivityByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out var guidId))
                {
                    return null; // Or handle invalid ID as needed
                }

                var userActivityById = await _context.Activities.FirstOrDefaultAsync(x => x.Id == guidId);

                if (userActivityById == null)
                {
                    return string.Empty;
                }

                var delete = await _context.Activities.Where(x => x.Id == guidId).ExecuteDeleteAsync();

                return id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task CompleteActivity()
        {
            // Save to DB first

            var activityEvent = new ActivityCompletedEvent
            {
                UserId = Guid.NewGuid(),
                ActivityType = "Running",
                Calories = 200,
                CompletedAt = DateTime.UtcNow
            };

           await _publisher.Publish(activityEvent, "activity-completed");
        }

    }
}

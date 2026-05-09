using ActivityService.Models;
using IdentityService.BusinessLogic.Interface;
using IdentityService.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityService.BusinessLogic.Implementation
{
    public class ActivityService : IActivityService
    {
        private readonly ActivityDbContext _context;

        public ActivityService(IConfiguration config, ActivityDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserActivity>> GetUserActivityAsync()
        {
            return await _context.Activities.ToListAsync();
        }

        public async Task<UserActivity> CreateUserActivityAsync(UserActivity activity)
        {
            activity.Id = Guid.NewGuid();
            activity.CreatedAt = DateTime.UtcNow;

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<UserActivity> GetUserActivityByIdAsync(string id)
        {
            if (!Guid.TryParse(id, out var guidId))
            {
                return null; // Or handle invalid ID as needed
            }

            var userActivityById = await _context.Activities.FirstOrDefaultAsync(x => x.Id == guidId);

            return userActivityById;
        }

        public async Task<UserActivity> UpdateUserAcitivityByIdAsync(UserActivity activity)
        {
            var userActivityById = await _context.Activities.FirstOrDefaultAsync(x => x.Id == activity.Id);

            if (userActivityById == null)
            {
            }
            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();
            return activity;
        }

        public async Task<string> DeleteUserAcitivityByIdAsync(string id)
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

    }
}

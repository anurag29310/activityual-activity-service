using ActivityService.BusinessLogic.Interface;
using ActivityService.Data;
using ActivityService.DTOs.Response;
using ActivityService.Models.Enums;
using Microsoft.EntityFrameworkCore;

public class AnalyticService : IAnalyticService
{
    private readonly ActivityDbContext _context;

    public AnalyticService(ActivityDbContext context)
    {
        _context = context;
    }

    public async Task<AnalyticsSummaryResponse> GetSummaryAsync()
    {
        var totalActivities = await _context.Trackings.CountAsync();

        var completedActivities = await _context.Trackings
            .CountAsync(x => x.Status == ActivityStatus.Completed);

        var missedActivities = await _context.Trackings
            .CountAsync(x => x.Status == ActivityStatus.Missed);

        return new AnalyticsSummaryResponse
        {
            TotalActivities = totalActivities,
            CompletedCount = completedActivities,
            MissedCount = missedActivities
        };
    }

    public async Task<List<AnalyticStreakResponse>> GetStreaksAsync()
    {
        var data = await _context.Trackings
            .Where(x => x.Status == ActivityStatus.Completed)
            .GroupBy(x => x.ActivityId)
            .Select(x => new AnalyticStreakResponse
            {
                ActivityId = x.Key,
                CurrentStreak = x.Count()
            })
            .ToListAsync();

        return data;
    }

    public async Task<AnalysticConsistencyResponse> GetConsistencyAsync()
    {
        var total = await _context.Trackings.CountAsync();

        var completed = await _context.Trackings
            .CountAsync(x => x.Status == ActivityStatus.Completed);

        var percentage = total == 0
            ? 0
            : (double)completed / total * 100;

        return new AnalysticConsistencyResponse
        {
            TotalTracked = total,
            CompletedTracked = completed,
            ConsistencyPercentage = (int)Math.Round(percentage, 2)
        };
    }

    public async Task<List<AnalyticMissedActivityResponse>> GetMissedAsync()
    {
        var data = await _context.Trackings
            .Where(x => x.Status == ActivityStatus.Missed)
            .Select(x => new AnalyticMissedActivityResponse
            {
                ActivityId = x.ActivityId,
                UserId = x.UserId ,
                Date = x.Date,
                Notes = x.Notes
            })
            .ToListAsync();

        return data;
    }
}
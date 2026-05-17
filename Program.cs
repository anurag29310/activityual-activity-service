using ActivityService.Messaging;
using ActivityService.Data;
using Microsoft.EntityFrameworkCore;
using ActivityService.BusinessLogic.Implementation;
using ActivityService.BusinessLogic.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton<RabbitMqPublisher>();
builder.Services.AddScoped<IActivityService, ActivityService.BusinessLogic.Implementation.ActivityService>();
builder.Services.AddScoped<ITrackingService, TrackingService>();

builder.Services.AddDbContext<ActivityDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddHealthChecks();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<ActivityDbContext>();

    dbContext.Database.Migrate();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

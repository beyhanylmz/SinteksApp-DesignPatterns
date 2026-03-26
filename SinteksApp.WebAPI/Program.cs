using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi;
using Quartz;
using Serilog;
using SinteksApp.Application;
using SinteksApp.Infrastructure.Jobs;
using SinteksApp.Persistence;
using SinteksApp.WebAPI.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuartz(q =>
{
    var jobKey = new JobKey("employee-monthly-sales-job");

    q.AddJob<EmployeeMonthlySalesJob>(opts => opts
        .WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("employee-monthly-sales-job-trigger")
        .WithCronSchedule("0 0 2 5 * ?")); // her ayın 5'i saat 02:00 UTC
});

builder.Services.AddQuartzHostedService(options =>
{
    options.WaitForJobsToComplete = true;
});

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationLayer();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sinteks API",
        Version = "v1",
        Description = "Sinteks API .NET 10"
    });
});

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
    //app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
using PandologicAssignment.Providers;
using PandologicAssignment.Providers.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IJobsDataProvider, JobsDataProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
    

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");


app.Run();

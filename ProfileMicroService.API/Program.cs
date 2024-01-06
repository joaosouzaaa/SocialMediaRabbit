using ProfileMicroService.API.Constants.CorsConstants;
using ProfileMicroService.API.DependencyInjection;
using ProfileMicroService.API.Middlewares;
using ProfileMicroService.API.Settings.MigrationSettings;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CorsPoliciesNamesConstants.CorsPolicy);
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();
app.UseMiddleware<NotificationMiddleware>();

app.Run();

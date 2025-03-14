using Microsoft.EntityFrameworkCore;
using Rira.Api.GRPC;
using Rira.Application.Interfaces.Context;
using Rira.Application.Interfaces.Facade;
using Rira.Application.Services.PersonServices.Facade;
using Rira.Persistance.SqlServer.Context;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection")
                       ?? throw new InvalidOperationException("Connection string 'DbConnection' not found.");

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddGrpc();

builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IPersonFacade, PersonFacade>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

Log.Logger = new LoggerConfiguration()
    .WriteTo.DatadogLogs("a9ef7c051f9c550def96386c85f3a1c2")
    .MinimumLevel.Error()
    .CreateLogger();

builder.Host.UseSerilog(); 

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<DataBaseContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "An error occurred while migrating the database.");
    }
}
app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGrpcService<PeopleService>();
});

app.Run();

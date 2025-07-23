using Catfact.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection(); //nie wiem czy to potrzebne dodatkowe przekierowanie z protokolu https

app.UseInfrastructure();
//app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.Run();

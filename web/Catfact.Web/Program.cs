using Catfact.Web.Components;
using Catfact.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<ICatService, CatService>((serviceProvider ,client) =>
{
    var config = serviceProvider.GetRequiredService<IConfiguration>();
    var baseAddress = config["BaseAddress"];
    client.BaseAddress = new Uri(baseAddress);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
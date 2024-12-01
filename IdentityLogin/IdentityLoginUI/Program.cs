using Microsoft.Identity.Client;
using IdentityLoginUI.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IPublicClientApplication>(sp => PublicClientApplicationBuilder.Create("3b7a4c26-a477-4280-a767-09bf66252414")
    .WithAuthority(AzureCloudInstance.AzurePublic, "d21fa47e-7e6d-49d1-ac9a-a6ae58d5befd")
    .WithRedirectUri("http://localhost:5193/")
    .Build());

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapRazorPages();

app.Run();
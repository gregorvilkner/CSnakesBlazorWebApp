using CSnakes.Runtime;
using CSnakes.Runtime.Locators;
using CSnakesBlazorWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

var pythonHomePath = Path.Join(AppContext.BaseDirectory, "python");
var pythonVEnvPath = Path.Join(AppContext.BaseDirectory, "python", ".venv");

// Add services to the container.
builder.Services
    .WithPython()
    .WithHome(pythonHomePath)
    .FromFolder(pythonVEnvPath, "3.12")
    .WithVirtualEnvironment(pythonVEnvPath);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

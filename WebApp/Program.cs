using Microsoft.Extensions.Options;
using WebApp.Services.Forecast;
using WebApp.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection(ApiSettings.Section));

builder.Services.AddHttpClient("", (services, client) =>
{
    var settings = services.GetRequiredService<IOptions<ApiSettings>>().Value;
    client.BaseAddress = new Uri(settings.Url!);
});

builder.Services.AddTransient<IForecastService, ForecastService>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using sqlapp.Services;
using Microsoft.FeatureManagement;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Endpoint=https://azureapp.azconfig.io;Id=+6vq-lh-s0:H4qcqckQ9bkTmTbErQum;Secret=7nNmkYDyilpMDNm6B9ixUpCFT5S7j5PArubu2JWFYE8=";

builder.Host.ConfigureAppConfiguration(app =>
{
    app.AddAzureAppConfiguration(options => 
        options.Connect(connectionString).UseFeatureFlags()
    );
});

builder.Services.AddTransient<IProductServices, ProductServices>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

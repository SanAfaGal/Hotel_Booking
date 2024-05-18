using Hotel_Booking.Client.Pages;
using Hotel_Booking.Components;
using Hotel_Booking.Context;
using Hotel_Booking.Services;
using ImplRepository;
using Microsoft.Data.SqlClient;
using Repository;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

/* --- Add services to the container --- */
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

/* --- Add connection to SQL SERVER --- */
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(builder.Configuration.GetConnectionString("CONNECTION_SQL")));
builder.Services.AddSingleton<DapperContext>();

/* --- Register HttpClient --- */
builder.Services.AddHttpClient();

/* --- Register controllers --- */
builder.Services.AddControllers();

/* --- Register services --- */
builder.Services.AddScoped<ICustomerService, ImplCustomerService>();

/* --- Register repositories --- */
builder.Services.AddScoped<ICustomerRepository, ImplCustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/* --- Register routing --- */
app.UseRouting();

/* --- Register the mapping of controllers --- */
app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Hotel_Booking.Client._Imports).Assembly);

app.Run();

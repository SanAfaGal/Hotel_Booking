using Hotel_Booking.Client.Pages;
using Hotel_Booking.Components;
using Hotel_Booking.Context;
using Hotel_Booking.ImplService;
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

/* --- Add services to the container  --- */
builder.Services.AddControllers();

/* --- Register the repository and the service  --- */
builder.Services.AddScoped<ICustomerRepository, ImplCustomerRepository>();
builder.Services.AddScoped<ICustomerService, ImplCustomerService>();

builder.Services.AddScoped<IRoomRepository, ImplRoomRepository>();
builder.Services.AddScoped<IRoomService, ImplRoomService>();

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

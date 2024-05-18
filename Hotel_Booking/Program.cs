using Hotel_Booking.Client.Pages;
using Hotel_Booking.Components;
using Hotel_Booking.Context;
using Hotel_Booking.Services;
using ImplRepository;
using Microsoft.Data.SqlClient;
using Repository;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add connection to SQL SERVER.
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(builder.Configuration.GetConnectionString("CONNECTION_SQL")));
builder.Services.AddSingleton<DapperContext>();

// Añade el registro de HttpClient
builder.Services.AddHttpClient();

builder.Services.AddControllers();

// Registra tus servicios
builder.Services.AddScoped<ICustomerService, ImplCustomerService>();

// Registrar repositorios
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

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Hotel_Booking.Client._Imports).Assembly);

app.Run();

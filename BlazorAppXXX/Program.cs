using BlazorAppXXX.Data;
using BlazorAppXXX.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextFactory<MyContext>(opt => opt.UseSqlite("Data Source=demoDB"));

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<EmployeeService>();

var app = builder.Build();


using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MyContext>();

try
{
    context.Database.Migrate();

    if (context.Employees.Any())
    {
        context.Employees.AddRange(new[] {
            new Employee { Id = 1, Name = "One"},
            new Employee { Id = 2, Name = "Two"},
        });
        context.SaveChanges();
    }

}
catch { }



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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

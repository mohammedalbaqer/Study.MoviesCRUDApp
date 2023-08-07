using Microsoft.EntityFrameworkCore;
using NToastNotify;
using Study.MoviesCRUDApp.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Connect to the database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SqliteDbConnection")));
// Add NToastNotify services
builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass = ToastPositions.TopRight,
    PreventDuplicates = true,
    CloseButton = true
}); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

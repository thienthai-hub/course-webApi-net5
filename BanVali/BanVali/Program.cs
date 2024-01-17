using BanVali.Models.FE;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QlbanVaLiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=ADMIN-PC\\MSSQLSERVER2022;Initial Catalog=QLBanVaLi;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")));

var builder1 = WebApplication.CreateBuilder(args);

// Add services to the container.
builder1.Services.AddControllersWithViews();

builder1.Services.AddDbContext<QlbanVaLiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data Source=ADMIN-PC;Initial Catalog=QuanLySach;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False")));


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

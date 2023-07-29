using DoktorKlinik.Business;
using DoktorKlinik.Business.Interface_Service;
using DoktorKlinik.Business.Service;
using DoktorKlinik.DataAccess;
using DoktorKlinik.Domain.User;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
Trace.Listeners.Add(new TextWriterTraceListener("error-logs.txt"));
Trace.AutoFlush = true;

builder.Services.AddControllersWithViews();
var context = builder.Configuration.GetConnectionString("Klnik");
builder.Services.AddDbContext<TourContext>(p =>
{
    p.UseSqlServer(context);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie();
builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientInfo, PatientInfoService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorComment, DoctorCommentService>();
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<IAppointment, AppointmentService>();
builder.Services.AddScoped<IAppointmentGet, AppointmentGetService>();
builder.Services.AddIdentity<KlinikUser, KlinikRole>()
    .AddUserManager<UserMangerSing>()   
    .AddEntityFrameworkStores<TourContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

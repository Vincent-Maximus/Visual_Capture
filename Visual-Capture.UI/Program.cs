using Microsoft.EntityFrameworkCore;
using Visual_Capture.BLL.Entities;
using Visual_Capture.Contracts.DTO;
using Visual_Capture.Contracts.Interfaces;
using Visual_Capture.DAL.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


String connectionString = builder.Configuration.GetConnectionString("VisualCaptureDB");
builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddScoped<IManagerDal<CategoryDTO>, CategoryManagerDal>();
builder.Services.AddScoped<IManagerDal<PhotographerDTO>, PhotographerManagerDal>();
builder.Services.AddScoped<IManagerDal<CustomerDTO>, CustomerManagerDal>();
builder.Services.AddScoped<IManagerDal<TypeReservationDTO>, TypeReservationManagerDal>();
builder.Services.AddScoped<IManagerDal<ReservationDTO>, ReservationManagerDal>();
builder.Services.AddScoped<IManagerDal<ReservationPhotographerDTO>, ReservationPhotographerDAL>();
// builder.Services.AddScoped<ReservationDal>();

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
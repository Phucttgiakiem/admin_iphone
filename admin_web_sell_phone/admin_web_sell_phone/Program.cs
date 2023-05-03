using admin_web_sell_phone.DataAccess;
using admin_web_sell_phone.Service;
using admin_web_sell_phone.Service.implamentation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ISanphamService, SanphamService>();
builder.Services.AddScoped<IThuonghieuService, ThuonghieuService>();
builder.Services.AddScoped<IKhachhangService, KhachhangService>();
builder.Services.AddScoped<INhanvienService,NhanvienService>();
builder.Services.AddScoped <INhacungcapService, NhacungcapService>();
builder.Services.AddScoped <IPhieunhapService, PhieunhapService>();
builder.Services.AddScoped<IChitietphieunhapService, ChitietphieunhapService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  //  app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sanpham}/{action=Index}/{id?}");

app.Run();

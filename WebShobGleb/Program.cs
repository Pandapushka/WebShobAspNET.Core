using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using OnlineShopDB;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

var builder = WebApplication.CreateBuilder(args);

// ����������� � ���� ������
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop")));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop")));

// ��������� Identity (���������� ������ ���� ���)
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

// ��������� ��������� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // ����� ����� ������
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ��������� �������������� � �����������
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

// ��������� ����
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromHours(24);
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/Logout";
    options.Cookie = new CookieBuilder
    {
        IsEssential = true
    };
});

// ���������� ������������ � �������������
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// ����������� ������������
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IProductsRepository, ProductRepository>();
builder.Services.AddTransient<ILikeRepository, LikeRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IUserManager, UserManager>();

// ����������� ��������
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IRoleService, RoleService>();

var app = builder.Build();

// ������������� ����� � �������������
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, roleManager);
}

// ��������� ��������� HTTP-��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // �������� UseAuthentication ����� UseAuthorization
app.UseAuthorization();

// �������� ������������� ������
app.UseSession();

// ������� ��� Area
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// ������� �� ���������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
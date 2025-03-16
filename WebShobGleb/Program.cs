using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;
using OnlineShopDB.Repository;
using OnlineShopDB;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

var builder = WebApplication.CreateBuilder(args);

// Подключение к базе данных
builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop")));

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop")));

// Настройка Identity (вызывается только один раз)
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

// Добавляем поддержку сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Время жизни сессии
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Настройка аутентификации и авторизации
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

// Настройка куки
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

// Добавление контроллеров и представлений
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// Регистрация репозиториев
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IProductsRepository, ProductRepository>();
builder.Services.AddTransient<ILikeRepository, LikeRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IUserManager, UserManager>();

// Регистрация сервисов
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IRoleService, RoleService>();

var app = builder.Build();

// Инициализация ролей и пользователей
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, roleManager);
}

// Настройка конвейера HTTP-запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Добавьте UseAuthentication перед UseAuthorization
app.UseAuthorization();

// Включаем использование сессий
app.UseSession();

// Маршрут для Area
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// Маршрут по умолчанию
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
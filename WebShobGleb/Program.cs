using Microsoft.EntityFrameworkCore;
using OnlineShopDB;
using OnlineShopDB.Repository;
using WebShobGleb.Repository;
using WebShobGleb.Servises;

var builder = WebApplication.CreateBuilder(args);

//подключение к бд
builder.Services.AddDbContext<DataBaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("online_shop")));


// Добавление репозиториев
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<IProductsRepository, ProductRepository>();
builder.Services.AddTransient<ILikeRepository, LikeRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IRolesRepository ,RolesRepository>();
builder.Services.AddTransient<IUserManager, UserManager>();

// Добавление сервисов
builder.Services.AddTransient<IOrderService, OrderService>();




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


// Маршрут для Area
app.MapControllerRoute(
    name: "areaRoute",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();

using CoreCodeFirst_2.Models.ContextClasses;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Eger Lazyloading'i aktifleştirmek istiyorsanız .Net Core'da ilgili Domain Entity'lerin icerisine ilişkiler property'ler icin virtual yazmak yetmez...Üzerine EntityFrameworkCore.Proxies kütüphanesini indirmeniz gerekir...Ondan sonra da asagıdaki UseLazyLoadingProxies() metodunu cagırmanız gerekir...
builder.Services.AddDbContext<MyContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")).UseLazyLoadingProxies());


builder.Services.AddControllersWithViews();






WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=CategoryList}/{id?}");

app.Run();

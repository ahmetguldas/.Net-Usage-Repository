using CORE_Usage_Repository.Models;
using CORE_Usage_Repository.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//AddTransient = Her servis isteðinde yeni bir instance oluþturulur. Transient servisinden üretilir.
//Herhangi bir yerden IProductRepository cagrildigindan ProductRepository den bir ornek gonder.
builder.Services.AddTransient<IProductRepository, EfProductRepository>();
//builder.Services.AddTransient<IProductRepository, ProductRepository>();



builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-83MGC3L\\SQLEXPRESS;Database=Data1;Trusted_Connection=True;");//@"Server=Mssql/deneme" / gibi ozel karekterleri kullanmak istiyorsak @ isaretini kullaniriz.
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

SeedData.Seed(app); //

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

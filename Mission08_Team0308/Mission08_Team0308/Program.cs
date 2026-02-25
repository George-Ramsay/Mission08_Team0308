using Microsoft.EntityFrameworkCore;
using Mission08_Assignment.Data;
using Mission08_Assignment.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Register DbContext and connect to SQLite
builder.Services.AddDbContext<QuadrantsContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("QuadrantsConnection")
    )
);

// Register Repository Pattern for dependency injection
builder.Services.AddScoped<IQuadrantsRepository, EFQuadrantsRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
using majed_asp_mvc.Data;
using majed_asp_mvc.Interfaces;
using majed_asp_mvc.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ÇáÊÍßã Ýí ÇáÌáÓÇÊ Ýí ÊÓÌíá ÇáÏÎæá
builder.Services.AddSession(builder =>
{
    builder.IdleTimeout = TimeSpan.FromMinutes(15);
    builder.Cookie.HttpOnly = true;
    builder.Cookie.IsEssential = true;
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options
.UseSqlServer(connectionString));


builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();

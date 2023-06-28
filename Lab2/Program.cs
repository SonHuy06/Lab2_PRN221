using Lab2.Business.Repository;
using Lab2.Business.IRepository;
using Lab2.DataAccess.Models;
using Lab2.Hubs;
using Lab2.Business.Mapping;
using Lab2.Business.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IProductRepository, ProductRepository>()
    .AddDbContext<NorthwindContext>(opt =>
    builder.Configuration.GetConnectionString("MyStore"));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<CartService>();


builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(IProductRepository));

builder.Services.AddSignalR();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

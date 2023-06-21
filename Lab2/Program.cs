using Lab2.Business.Repository;
using Lab2.Business.IRepository;
using Lab2.DataAccess.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddTransient<IProductRepository, ProductRepository>()
    .AddDbContext<NorthwindContext>(opt =>
    builder.Configuration.GetConnectionString("NorthwindConStr"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

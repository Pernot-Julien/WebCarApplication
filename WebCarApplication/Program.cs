using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebCarApplication.Data;
using WebCarApplication.Models.Repositories;
using WebCarApplication.Models.Repositories.Interfaces;
using WebCarApplication.Models.Services;
using WebCarApplication.Models.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IVoitureRepository, VoitureRepository>();
builder.Services.AddScoped<IVoitureService, VoitureService>();
builder.Services.AddScoped<IMarqueRepository, MarqueRepository>();
builder.Services.AddScoped<IMarqueService, MarqueService>();
builder.Services.AddScoped<IModeleRepository, ModeleRepository>();
builder.Services.AddScoped<IModeleService, ModeleService>();
builder.Services.AddScoped<IFinitionRepository, FinitionRepository>();
builder.Services.AddScoped<IFinitionService, FinitionService>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();
builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IReparationRepository, ReparationRepository>();
builder.Services.AddScoped<IReparationService, ReparationService>();
builder.Services.AddScoped<IModeleFinitionService, ModeleFinitionService>();
builder.Services.AddScoped<IModeleFinitionRepository, ModeleFinitionRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

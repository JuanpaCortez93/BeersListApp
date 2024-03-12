using BeersList.Data;
using BeersList.Data.DTOs.BreweriesDTO;
using BeersList.Data.MappingProfiles;
using BeersList.Models;
using BeersList.Repositories.BreweriesRepo;
using BeersList.Services.BreweriesServs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Entity Framework - DB Connection
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));

//Services
builder.Services.AddKeyedScoped<IBreweriesService<BreweriesGetDTO, BreweriesPostDTO, BreweriesPutDTO>, BreweriesServices>("BreweriesService");

//Repository
builder.Services.AddKeyedScoped<IBreweriesRepository, BreweriesRepository>("BreweriesRepository");

//Add Mapping Profiles
builder.Services.AddAutoMapper(typeof(BreweriesMappingProfile));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Breweries}/{action=Index}/{id?}");

app.Run();

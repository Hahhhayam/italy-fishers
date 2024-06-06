using DAL;
using DAL.Entity;
using DAL.Repo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ItalyFishersContext>();
builder.Services.AddTransient<IRepository<Person>, PersonRepository
    >();
builder.Services.AddTransient<IRepository<Reservation>, ReservationRepository>();
builder.Services.AddTransient<IRepository<Status>, StatusRepository>();
builder.Services.AddTransient<IRepository<Watersource>, WatersourceRepository>();
builder.Services.AddTransient<IRepository<WatersourceType>, WatersourceTypeRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
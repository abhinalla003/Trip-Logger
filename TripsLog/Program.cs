using Microsoft.EntityFrameworkCore;
using TripsLog.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// EF Core Configuration
builder.Services.AddDbContext<TripsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TripsDatabaseString")));

// Session State Configuration (Optional, if you plan to use session state)
builder.Services.AddDistributedMemoryCache(); // For development purposes
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // For example, 30 minutes
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

// Session Middleware (Optional, if you're using session state)
app.UseSession(); // Place this between UseRouting and UseEndpoints

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trips}/{action=Index}/{id?}");

app.Run();

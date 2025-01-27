//####################### 16 th JAN code ####################################

//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.EntityFrameworkCore;
//using Scholarly.DAL;
//using Scholarly.Models;
//using Microsoft.AspNetCore.Identity;

//var builder = WebApplication.CreateBuilder(args);

//Load configuration from appsettings.json
//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//Add services to the container
//builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("local_db")
//        ?? throw new InvalidOperationException("Connection string 'local_db' not found.")));

//Register IPasswordHasher<user> service
//builder.Services.AddScoped<IPasswordHasher<user>, PasswordHasher<user>>();

//Add Blazor services
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Login";
//        options.AccessDeniedPath = "/Login";
//    });

//var app = builder.Build();

//Configure the HTTP request pipeline
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.Run();

////####################### 16 th JAN code 2nd time ####################################
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.EntityFrameworkCore;
//using Scholarly.DAL;
//using Scholarly.Models;
//using Microsoft.AspNetCore.Identity;

//var builder = WebApplication.CreateBuilder(args);

//// Load configuration from appsettings.json
//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

//// Add services to the container
//builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<DatabaseContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("local_db")
//        ?? throw new InvalidOperationException("Connection string 'local_db' not found.")));

//// Register IPasswordHasher<user> service
//builder.Services.AddScoped<IPasswordHasher<user>, PasswordHasher<user>>();

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Login";
//        options.AccessDeniedPath = "/Login";
//    });

//var app = builder.Build();

//// Configure the HTTP request pipeline
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


//############################# 17 th JAN ####################################
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Scholarly.DAL;
using Scholarly.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure DatabaseContext with connection string
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("local_db")
        ?? throw new InvalidOperationException("Connection string 'local_db' not found.")
    )
);

// Register IPasswordHasher<user> service for password hashing
builder.Services.AddScoped<IPasswordHasher<user>, PasswordHasher<user>>();

// Configure Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Redirect to Login page if not authenticated
        options.AccessDeniedPath = "/Login"; // Redirect to Login page if access is denied
    });

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use error handling middleware
    app.UseHsts(); // Use HSTS in production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles(); // Serve static files
app.UseRouting(); // Enable routing middleware
app.UseAuthentication(); // Enable authentication
app.UseAuthorization(); // Enable authorization

// Configure default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

/*using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Scholarly.DAL;
using Scholarly.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container
builder.Services.AddControllersWithViews();

// Configure DatabaseContext with connection string
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("local_db")
        ?? throw new InvalidOperationException("Connection string 'local_db' not found.")
    )
);

// Register IPasswordHasher<user> service for password hashing
builder.Services.AddScoped<IPasswordHasher<user>, PasswordHasher<user>>();

// Configure Cookie Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Redirect to Login page if not authenticated
        options.AccessDeniedPath = "/Login"; // Redirect to Login page if access is denied
    });

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use error handling middleware
    app.UseHsts(); // Use HSTS in production
}

app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.UseStaticFiles(); // Serve static files
app.UseRouting(); // Enable routing middleware
app.UseAuthentication(); // Enable authentication
app.UseAuthorization(); // Enable authorization

// Configure default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
*/






using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
#region Additional namespace
using ChinookLibrary;
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//given
//supplied database connection due to the fact that we create this 
//webapp to use Individual Accounts
//code retrives the connection strin from appsettings.json

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//added
// code retrives the chinook connection string
var connectionStringChinook = builder.Configuration.GetConnectionString("ChinookDB");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

//added
//code the logic to add our class library services to IServiceCollection 
//one could do the registration code here in Program.cs
//However,every time a service class is added, you would be changing this file
//the implementation of the Dbcontent and AddTransient(..) code in this example
// will be done in an extension method to IserviceCollection

builder.Services.ChinookDependencies(options =>
    options.UseSqlServer(connectionStringChinook));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

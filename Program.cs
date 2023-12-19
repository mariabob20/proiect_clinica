using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using proiect_clinica.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Programari");
    options.Conventions.AuthorizeFolder("/Servicii");
    options.Conventions.AllowAnonymousToPage("/Servicii/Index");
    options.Conventions.AllowAnonymousToPage("/Servicii/Details");
    options.Conventions.AuthorizeFolder("/Angajati");
    options.Conventions.AllowAnonymousToPage("/Angajati/Index");
    options.Conventions.AllowAnonymousToPage("/Angajati/Details");
    options.Conventions.AuthorizeFolder("/Clienti", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Calificari", "AdminPolicy");

});

// Adaugã DbContext pentru proiect_clinica
builder.Services.AddDbContext<proiect_clinicaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiect_clinicaContext") ?? throw new InvalidOperationException("Connection string 'proiect_clinicaContext' not found.")));

// Adaugã DbContext pentru Identity
builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("proiect_clinicaContext") ?? throw new InvalidOperationException("Connectionstring 'proiect_clinicaContext' not found.")));

// Adaugã serviciile Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");

        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();


app.Run();

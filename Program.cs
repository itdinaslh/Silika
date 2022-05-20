using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Silika.Data;
using Silika.Repository;
using Silika.Services;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var services = builder.Services;

// Add CoRS
services.AddCors();

services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDB"));
});

// add service to DI Container
{
    services.AddScoped<IJenisWrRepo, JenisWrService>();
    services.AddScoped<IJenisKendaraanRepo, JenisKendaraanService>();
    services.AddScoped<IJenisTpsRepo, JenisTpsService>();
    services.AddScoped<IJenisPencemaranRepo, JenisPencemaranService>();
    services.AddScoped<INilaiPencemaranRepo, NilaiPencemaranService>();
    services.AddScoped<IMerkKendaraan, MerkKendaraanService>();
}

services.AddAuthentication(options => {
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})

.AddCookie(options => {
    options.LoginPath = "/login";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.SlidingExpiration = false;
    options.AccessDeniedPath = "/account/denied";
})

.AddOpenIdConnect(options => {
    options.ClientId = "silika";
    options.ClientSecret = "silikadlhsecret2022";

    options.RequireHttpsMetadata = false;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.SaveTokens = true;

    // Use the authorization code flow.
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;

    // retrieve the identity provider's configuration and spare you from setting
    // the different endpoints URIs or the token validation parameters explicitly.
    options.Authority = "https://localhost:6001/";

    options.Scope.Add("email");
    options.Scope.Add("roles");
    // options.Scope.Add("profile");

    // Disable the built-in JWT claims mapping feature.
    options.MapInboundClaims = false;

    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";    
});

services.AddHttpClient();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// app.UseForwardedHeaders(new ForwardedHeadersOptions
// {
//     ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
// });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();

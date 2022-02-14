using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SalesWS.Models.Common;
using SalesWS.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

const string myCors = "MyCORS";
var builder = WebApplication.CreateBuilder(args);
var appSettingsSection = builder.Configuration.GetSection("AppSettings");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myCors,
                       builder =>
                       {
                           builder.WithHeaders("*");
                           builder.WithOrigins("*");
                           builder.WithMethods("*");
                       });
});

builder.Services.Configure<AppSettings>(appSettingsSection);
//jwt

var appSettings = appSettingsSection.Get<AppSettings>();//transform json section to .net Object to use it
var key = Encoding.ASCII.GetBytes(appSettings.SecretJWT);
builder.Services.AddAuthentication(d =>
{
   d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer( d =>
{
    d.RequireHttpsMetadata = false;
    d.SaveToken = true;
    d.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});



builder.Services.AddScoped<IUserService, UserService>();

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

app.UseCors(myCors);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseAuthentication();

app.Run();

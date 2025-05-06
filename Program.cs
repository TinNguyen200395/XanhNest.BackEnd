using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Facebook;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using XanhNest.BackEndServer.Application.Configurations;
using XanhNest.BackEndServer.Data;
using Microsoft.AspNetCore.Identity;
using XanhNest.BackEndServer.Data.Entities;
using XanhNest.BackEndServer.Application.Settings;

var builder = WebApplication.CreateBuilder(args);

// ========================== Cấu hình dịch vụ ==========================

// Cấu hình Entity Framework Core với PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
// Cấu hình setting cho xanhNest
var configSection = builder.Configuration.GetSection("XanhNest");
var setting = configSection.Get<XanhNestSetting>();
XanhNestSetting.Instance = setting;
builder.Services.AddSingleton(setting);

// Cấu hình Identity để quản lý user và roles
builder.Services.AddIdentity<User, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Thêm dịch vụ điều khiển API
builder.Services.AddControllers();

// Cấu hình Swagger để tạo tài liệu API tự động
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký các repository và service
builder.Services.AddRepositories();
builder.Services.AddServices();

// Cấu hình Authentication với JWT, Google, và Facebook
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
})
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
})
.AddFacebook(facebookOptions =>
{
    facebookOptions.AppId = builder.Configuration["Authentication:Facebook:AppId"];
    facebookOptions.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin() // Cho phép mọi domain truy cập API
            .AllowAnyMethod() // Cho phép mọi phương thức (GET, POST, PUT, DELETE)
            .AllowAnyHeader()); // Cho phép mọi header
});

var app = builder.Build();

// Thêm dòng này vào trước `app.UseAuthorization();`
app.UseCors("AllowAllOrigins");
// ========================== Cấu hình pipeline xử lý HTTP requests ==========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Kích hoạt hệ thống xác thực
app.UseAuthorization();  // Kích hoạt hệ thống phân quyền

app.MapControllers();

app.Run();
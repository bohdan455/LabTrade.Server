using BLL.Services.Interfaces;
using BLL.Services.Realizations.Jwt;
using BLL.Services.Realizations.Lab;
using DataAccess;
using DataAccess.Entities.Money;
using DataAccess.Entities.User;
using DataAccess.Repositories.Interfaces;
using DataAccess.Repositories.Realizations.Lab;
using DataAccess.Repositories.Realizations.Money;
using DataAccess.Repositories.Realizations.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void ConfigureAppSecurity(this WebApplicationBuilder builder)
        {
            var config = builder.Configuration;
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
            builder.Services.AddAuthorization();
            builder.Services.AddIdentity<Seller,IdentityRole>(options =>
            {
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<LabTradeDbContext>();
        }
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenService,JwtTokenService>();
            services.AddTransient<ILabFileService,LabFileService>();
            services.AddTransient<ILabWorkService,LabWorkService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ILabFileRepository,LabFileRepository>();
            services.AddTransient<ILabWorkRepository,LabWorkRepository>();
            services.AddTransient<IUniversityRepository,UniversityRepository>();
            services.AddTransient<ITransactionRepository,TransactionRepository>();
            services.AddTransient<ISellerRepository,SellerRepository>();
            return services;
        }
    }
}

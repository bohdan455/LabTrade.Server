using BLL.Services.Interfaces;
using BLL.Services.Realizations.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        }
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenService,JwtTokenService>();
            return services;
        }
    }
}

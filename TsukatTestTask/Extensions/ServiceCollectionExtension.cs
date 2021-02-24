using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TsukatTestTask.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserContext>(options => options.UseSqlServer(connectionString));
        }
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>(provider =>
               new UnitOfWork(provider.GetRequiredService<UserContext>()));
        }

        public static void GetSettings(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagment"));
        }

        public static void AddAuthentication(this IServiceCollection services,
            IConfiguration Configuration)
        {
            services.GetSettings(Configuration);
            var token = Configuration.GetSection("tokenManagment").Get<TokenManagement>();
            var secret = Encoding.ASCII.GetBytes(token.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}

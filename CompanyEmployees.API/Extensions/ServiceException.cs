﻿using System.Text;
using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service;
using Service.Contracts;

namespace CompanyEmployees.Extensions
{
    public static class ServiceException
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureRepositoryManager( this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

       public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
		services.AddDbContext<RepositoryContext>(opts => opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("CompanyEmployees")));


        public static void ConfigureIdentity(this IServiceCollection services)
	{
		var builder = services.AddIdentity<User, IdentityRole>(o =>
			{
				o.Password.RequireDigit = true;
				o.Password.RequireLowercase = true;
				o.Password.RequireUppercase = true;
				o.Password.RequireNonAlphanumeric = false;
				o.Password.RequiredLength = 10;
				o.User.RequireUniqueEmail = true;
			})
			.AddEntityFrameworkStores<RepositoryContext>()
			.AddDefaultTokenProviders();
	}

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
     {
       var jwtSettings = configuration.GetSection("JwtSettings"); 
      // var secretKey = Environment.GetEnvironmentVariable("SECRET");
       
       services.AddAuthentication(opt =>
       {
              opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
              opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddJwtBearer(options =>
       {
        options.TokenValidationParameters = new TokenValidationParameters {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtSettings["validIssuer"],
                     ValidAudience = jwtSettings["validAudience"],
                     IssuerSigningKey = new
                     SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]))
              };
}); }

    }
}

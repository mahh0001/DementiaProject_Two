﻿using System.Text;
using AutoMapper;
using DementiaProject_Two.DataContexts;
using DementiaProject_Two.Models;
using DementiaProject_Two.Models.DataTransferObjects;
using DementiaProject_Two.Models.User;
using DementiaProject_Two.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DementiaProject_Two
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().AddEnvironmentVariables().
                                                       AddJsonFile(env.ContentRootPath + "/appsettings.json").
                                                       Build();
        }
        public IConfiguration Configuration { get; private set; }
        
        public void ConfigureServices(IServiceCollection services)
        {    
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<Tokens>(Configuration.GetSection("Tokens"));

            services.AddTransient<MatchmakingApi>();


            //services.AddDbContext<UserInformationContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("UserInfoConnection"))); //SKal måske slettes

            services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                                            .AddEntityFrameworkStores<IdentityContext>();

            services.AddDbContext<IdentityContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DementiaConnection")));

            //The password will have no preconditions for requirements
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
            });
            
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Tokens").Get<Tokens>().Key);

            services.AddAuthentication();

            //services.AddAuthentication(x =>
            //{
             
            //})
            //.AddCookie()
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Mapper.Initialize(config => 
            {
                config.CreateMap<UserInformationModel, UserModel>();
                config.CreateMap<UserModel, UserInformationModel>();
                config.CreateMap<UserModel, UserInfoDTO>();
                config.CreateMap<UserInfoDTO, UserModel>();
            });
            
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}

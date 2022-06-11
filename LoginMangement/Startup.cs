using LoginMangement.Model;
using LoginMangement.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMangement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // For Entity Framework  
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            // For Identity  
            services.AddIdentity<ApplicationUser, ApplicationRole>();           
             
            var authenticationProviderKey = "TestKey";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = authenticationProviderKey;
                
            })
            .AddJwtBearer(authenticationProviderKey, o =>
                {
                    var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                    o.SaveToken = true;
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });

            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            ////Identity Part
            //services.AddIdentity<ApplicationUser,ApplicationRole>();

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ////services.AddDbContext<ApplicationDbContext>(options =>
            //// options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            ////services.AddIdentity<ApplicationUser, ApplicationRole>()
            ////    .AddEntityFrameworkStores<ApplicationDbContext>()
            ////    .AddDefaultTokenProviders();
            //services.AddMvc();
            //var authenticationProviderKey = "TestKey";
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = authenticationProviderKey;
            //    //x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})//JWT Bearer
            //    .AddJwtBearer(authenticationProviderKey, o =>
            //    {
            //        var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
            //        o.SaveToken = true;
            //        o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = Configuration["JWT:Issuer"],
            //            ValidAudience = Configuration["JWT:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(key)
            //        };
            //    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
            app.UseMvcWithDefaultRoute();
           

            app.UseAuthentication();
           
           
        }
    }
}

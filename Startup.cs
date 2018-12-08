using System;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using bookshop.Core;
using bookshop.Models;
using bookshop.Persistance;
using bookshop.Repositories;
using bookshop.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace bookshop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfigYey = configuration;
        }

        public IConfiguration Configuration { get; }

        public static IConfiguration StaticConfigYey{get; private set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddHttpContextAccessor();

            services.AddSession( options => { options.IdleTimeout = TimeSpan.FromSeconds(10);
                                              options.Cookie.HttpOnly = true; });

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                             .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); 


            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));

            services.AddAutoMapper();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBookInstRepo, BookInstRepo>();

            services.AddScoped<IWriterRepo, WriterRepo>();

            services.AddScoped<IBookDefRepo, BookDefRepo>();            

            services.AddScoped<IBookInstResourceClientValidator, BookInstResourceClientValidator>();

            services.AddScoped<IBookDefResCliValidator, BookDefResCliValidator>();

            services.AddScoped<IMiscRepo, MiscRepo>();

            services.AddScoped<IPhotoRepo, PhotoRepo>();

            services.AddScoped<IUserRepo, UserRepo>();

            services.AddScoped<ISignupValidator, SignupValidator>();

            services.AddScoped<ITokenGenetator, TokenGenerator>();
            
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<BookDbContext>( a => a.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                            ValidIssuer = "http://localhost:5001",
                            ValidAudience = "http://localhost:5001",
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenKey").GetValue<string>("Default")))
                        };
            });

            services.AddSwaggerGen(c =>{ c.SwaggerDoc("v1", new Info { Title = "BookShop API", Version = "v1" });});

            services.AddAuthorization(options => options.AddPolicy("EditorialAuth", policy => policy.RequireClaim("Editorial","Full") ));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSession();

            app.UseSwagger();

            app.UseSwaggerUI(a => {a.SwaggerEndpoint("/swagger/v1/swagger.json", "BookShop API V1"); a.RoutePrefix = "swaggerPage"; });

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

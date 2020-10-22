using System;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ERPNet.Helpers;
using ERPNet.Services;

namespace ERPNet
{
    public class Startup
    {
        public Startup ( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices ( IServiceCollection services )
        {
           
            // configure dbContext with SQL server db
            services.AddDbContext<ERPNetContext> ( options =>
                      options.UseSqlServer ( Configuration.GetConnectionString ( "ERPNetContext" ) ) );

            services.AddCors ( options =>
            {
                options.AddPolicy ( "AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins ( "http://localhost:4200" );
                        builder.SetIsOriginAllowedToAllowWildcardSubdomains ()
                        .AllowAnyHeader ()
                        .AllowAnyMethod ()
                        .AllowCredentials ();

                    } );
            } );

            services.AddControllers ();

            services.AddAutoMapper ( AppDomain.CurrentDomain.GetAssemblies () );

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection ( "AppSettings" );
            services.Configure<AppSettings> ( appSettingsSection );

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings> ();
            var key = Encoding.ASCII.GetBytes ( appSettings.Secret );

            // ADD Login JSON Web Token
            services.AddAuthentication ( x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer ( options =>
               {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey ( key ),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               } );

            // scope DI for application services
            services.AddScoped<IUserService, UserService> ();
            services.AddScoped<PeopleRepository> ();
            services.AddScoped<CustomerRepository> ();
            services.AddScoped<EmployeeRepository> ();
            services.AddScoped<AddressesRepository> ();
            services.AddScoped<MovementsRepository> ();
            services.AddScoped<OrderRepository> ();
            services.AddScoped<OrderProductRepository> ();
            services.AddScoped<ProductRepository> ();
            services.AddScoped<StoragesRepository> ();
            services.AddScoped<WarehouseRepository> ();
    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if(env.IsDevelopment ())
            {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseCors ( "AllowSpecificOrigin" );

            app.UseAuthentication ();

            app.UseAuthorization ();

            app.UseEndpoints ( endpoints =>
              {
                  endpoints.MapControllers ();
              } );
        }
    }
}

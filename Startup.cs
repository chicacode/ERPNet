using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ERPNet.Data;
using ERPNet.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddControllers ();

            // ADD Login JSON Web Token
            services.AddAuthentication ( JwtBearerDefaults.AuthenticationScheme )
               .AddJwtBearer ( options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey ( Encoding.UTF8.GetBytes ( Configuration["Jwt:Key"] ) )
                   };
               } );

            // configure dbContext with SQL server db
            services.AddDbContext<ERPNetContext> ( options =>
                      options.UseSqlServer ( Configuration.GetConnectionString ( "ERPNetContext" ) ) );

            // scope
            services.AddScoped<PeopleRepository> ();
            services.AddScoped<CustomerRepository> ();
            services.AddScoped<EmployeeRepository> ();
            services.AddScoped<AddressesRepository> ();
            services.AddScoped<CategoriesRepository> ();
            services.AddScoped<MovementsRepository> ();
            services.AddScoped<OrderRepository> ();
            services.AddScoped<OrderProductRepository> ();
            services.AddScoped<ProductRepository> ();
            services.AddScoped<StoragesRepository> ();
            services.AddScoped<WarehouseRepository> ();


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

            app.UseAuthentication ();

            app.UseCors ( "AllowSpecificOrigin" );

            app.UseAuthorization ();

            app.UseEndpoints ( endpoints =>
              {
                  endpoints.MapControllers ();
              } );
        }
    }
}

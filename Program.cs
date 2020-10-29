using System;

using ERPNet.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ERPNet
{
    public class Program
    {
        public static void Main ( string[] args )
        {
            var host = CreateHostBuilder ( args ).Build ();

            CreateDbIfNotExists ( host );

            host.Run ();
        }

        // Creaci�n de la Base de datos
        private static void CreateDbIfNotExists ( IHost host )
        {
            using(var scope = host.Services.CreateScope ())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ERPNetContext> ();
                    context.Database.EnsureCreated ();
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>> ();
                    logger.LogError ( ex, "An error occurred creating the DB." );
                }
            }
        }

        public static IHostBuilder CreateHostBuilder ( string[] args ) =>
            Host.CreateDefaultBuilder ( args )
                .ConfigureWebHostDefaults ( webBuilder =>
                  {
                      webBuilder.UseStartup<Startup> ()
                      .UseSetting ( WebHostDefaults.DetailedErrorsKey, "true" );
                  } );
    }
}

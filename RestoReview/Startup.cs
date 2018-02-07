using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RestoReview
{
    //bevat twee zeer belangrijke methods
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // dit wordt maar 1x aangeroepen
        // hierin configureren we de services (duh)
        public void ConfigureServices(IServiceCollection services)
        {
            // een singleton gaat ervoor zorgen dat er maar 1 implementor is van de service tijdens de run van het programma 
            services.AddSingleton<IGroeter, Groeter>();

            // Bij AddTransient: elke keer er een implementor gevraagd wordt, wordt een nieuwe instantie gemaakt
            // services.AddTransient()
            
            // Bij AddScoped: Wordt 1 implementor per request voorzien - zeer interessant voor web (vb DBContext)
            // services.AddScoped()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // deze method wordt maar 1X gerund!
        // hier ook onze eigen IConfiguration toegevoegd
        // op zich vreemd dat hij deze automatisch herkent. Dit is omdat dit reeds geïmplementeerd zit
        // de parameters(IapplicationBuilder, IHostingENvironment en Iconfiguration 
        // zijn default services die door ASP.NET voorzien worden
        // we vervangen ze
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGroeter groeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //dit is een middleware die een async delegate meekrijgt
            //Belangrijk voor webapplicaties is belangrijk dat async gewerkt wordt
            app.Run(async (context) =>
            {
                //var groet = configuration["Groet"]; 
                var groet = groeter.GroetVanDeDag();
                await context.Response.WriteAsync(groet);
            });
        }
    }

    
}

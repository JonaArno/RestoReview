using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace RestoReview
{
    public class Program
    {
        //dit start het programma
        //we gaan bij de opstart argumenten meegeven, die gebruikt worden om de host te bouwen en te beïnvloeden
        public static void Main(string[] args)
        {
            //een webhost is eigenlijk je webserver
            BuildWebHost(args).Run();
        }

        //je staat volledig vrij je eigen webhostbuilder te bouwen
        //CreateDefaultBuilder gaat:
        //1) Kestrel gebruiken als webserver
        //2) Integratie met IIS voorzien
        //3) Logging is voorzien
        //4) Een IConfiguration service wordt beschikbaar gesteld
        //  - JSON file (appsettings.json)
        //  - User secrets
        //  - Environment variabelen 
        //  - CL arguments
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //de klasse die voorzien wordt als startupklasse (Startup standaard voorzien)
                .UseStartup<Startup>()
                .Build();
    }
}

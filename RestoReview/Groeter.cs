using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RestoReview
{
    public class Groeter:IGroeter
    {
        public string Groet { get; }

        public Groeter(IConfiguration configuration)
        {
            Groet = configuration["Groet"] + " (uit de Groeter service)";
        }

        public string GroetVanDeDag() => Groet;
    }
}

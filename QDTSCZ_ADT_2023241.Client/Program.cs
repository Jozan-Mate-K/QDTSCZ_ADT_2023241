using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Threading;
using System.Xml.Linq;
using Instrument = QDTSCZ_ADT_2023241.Models.Instrument;

namespace QDTSCZ_ADT_2023241.Client
{
    static class Extension
    {
        public static void ToProcess<T>(this IEnumerable<T> query, string headline)
        {
            Console.WriteLine($"\n:: {headline} ::\n");

            foreach (var item in query)
                Console.WriteLine("\t" + item);

            Console.WriteLine("\n\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Thread.Sleep(5000);
            RestService restService = new RestService("http://localhost:5030");

            var instrument = new Instrument()
            {
                Name = "test",
                Description = "test",
                BandId = 1,
                ManufacturerId = 1,
                Type = instrumentTypeEnum.STRINGS
            };
            


            Instrument instr = restService.Get<Instrument>(1, "Instrument");
            Console.WriteLine($"{instr.Name} ez jött meg");
            
            restService.Post<Instrument>(instrument , "Instrument");



        }
    }
}

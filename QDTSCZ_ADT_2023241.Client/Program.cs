using Newtonsoft.Json;
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

            var manufacturer = new Manufacturer() { 
                Name = "Test",
            };

            var band = new Band()
            {
                Name = "Test",
                Balance = 1,
            };

            var instrument = new Instrument()
            {
                Name = "Test",

                Type = instrumentTypeEnum.STRINGS
            };

            //POST testing

            restService.Post<Manufacturer>(manufacturer, "Manufacturer");
            restService.Post<Band>(band, "Band");
            restService.Post<Instrument>(instrument, "Instrument");



            //GET testing

            ICollection<Instrument> ilist = restService.Get<Instrument>("Instrument"); 
            ICollection<Band> blist = restService.Get<Band>("Band"); 
            ICollection<Manufacturer> mlist = restService.Get<Manufacturer>("Manufacturer"); 

            foreach (var item in ilist)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            foreach (var item in blist)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
            foreach (var item in mlist)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();

            Instrument instr = restService.Get<Instrument>(1, "Instrument");
            Console.WriteLine($"{instr.Name}, {instr.Band.Name}, {instr.Manufacturer.Name} ez jött meg");


            Band ban = restService.Get<Band>(1, "Band");
            Console.WriteLine($"{band.Name} ez jött meg");


            Manufacturer manu = restService.Get<Manufacturer>(1, "Manufacturer");
            Console.WriteLine($"{manu.Name} ez jött meg");

            //PUT testing

            ban.Balance = 200;
            restService.Put<Band>(ban, "Band");
            ban = restService.Get<Band>(1, "Band");
            Console.WriteLine($"{ban.Balance} ez jött meg");

            manu.Name = "Test";
            restService.Put<Manufacturer>(manu, "Manufacturer");
            manu = restService.Get<Manufacturer>(1, "Manufacturer");
            Console.WriteLine($"{manu.Name} ez jött meg");

            instr.Band = ban;
            //instr.BandId = band.Id;
            restService.Put<Instrument>(instr, "Instrument");
            instr = restService.Get<Instrument>(1, "Instrument");

            Console.WriteLine($"{instr.Name}, {instr.Band.Name}, {instr.Manufacturer.Name} ez jött meg");




            Console.Read();
        }
    }
}

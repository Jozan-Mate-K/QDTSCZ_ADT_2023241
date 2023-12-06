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
            Console.WriteLine( "POST TESTING" );

            restService.Post<Manufacturer>(manufacturer, "Manufacturer");
            restService.Post<Band>(band, "Band");
            restService.Post<Instrument>(instrument, "Instrument");
            Console.WriteLine();


            //GETALL testing
            Console.WriteLine("GETALL TESTING");

            ICollection<Instrument> ilist = restService.Get<Instrument>("Instrument");
            ICollection<Instrument> imanulist = restService.Get<ICollection<Instrument>>(1, "NonCrud/intrumentsByManufacturer");
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

            Console.WriteLine("NON-CRUD");
            foreach (var item in imanulist)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();



            //GET TESTING
            Console.WriteLine("GET TESTING");


            Instrument instr = restService.Get<Instrument>(1, "Instrument");
            Console.WriteLine(instr.ToString());

            Band ban = restService.Get<Band>(1, "Band");
            Console.WriteLine(band.ToString());


            Manufacturer manu = restService.Get<Manufacturer>(1, "Manufacturer");
            Console.WriteLine(manu.ToString());

            Console.WriteLine();
            Console.WriteLine("NON-CRUD GET");

            Manufacturer m = restService.Get<Manufacturer>(1, "NonCrud/manufacturer");
            Console.WriteLine(m.ToString());

            Band b = restService.Get<Band>(1, "NonCrud/band");
            Console.WriteLine(b.ToString());

            Console.WriteLine();

            //PUT testing
            Console.WriteLine("PUT TESTING");


            ban.Balance = 200;
            restService.Put<Band>(ban, "Band");
            ban = restService.Get<Band>(1, "Band");
            Console.WriteLine(ban.ToString());

            manu.Name = "Test123";
            restService.Put<Manufacturer>(manu, "Manufacturer");
            manu = restService.Get<Manufacturer>(1, "Manufacturer");
            Console.WriteLine(manu.ToString());

            instr.Band = ban;
            //instr.BandId = band.Id;
            restService.Put<Instrument>(instr, "Instrument");
            instr = restService.Get<Instrument>(1, "Instrument");
            Console.WriteLine($"{instr.Name}, {instr.Band.Name} bal = {instr.Band.Balance}, {instr.Manufacturer.Name} arrived");


            Console.WriteLine();


            //DELETE Testing
            Console.WriteLine("DELETE TESTING");

            restService.Delete(manu.Id, "Manufacturer");
            restService.Delete(ban.Id, "Band");
            restService.Delete(instr.Id, "Instrument");

            ilist = restService.Get<Instrument>("Instrument");
            blist = restService.Get<Band>("Band");
            mlist = restService.Get<Manufacturer>("Manufacturer");

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
            foreach (var item in imanulist)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();


            Console.Read();
        }
    }
}

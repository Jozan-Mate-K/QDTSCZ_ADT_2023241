
using Microsoft.EntityFrameworkCore;
using QDTSCZ_ADT_2023241.Models;
using System.Runtime.InteropServices;

namespace QDTSCZ_ADT_2023241.Repository
{
    public class Context: DbContext
    {
        public Context() 
        { 
            Database.EnsureCreated();
        }

        public DbSet<Instrument> Instruments;
        public DbSet<Manufacturer> Manufacturers;
        public DbSet<Band> Bands;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Add "Db" connection
            optionsBuilder.UseInMemoryDatabase("instrumentDb");
            // Add lazy loading
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Manufacturer m1 = new Manufacturer { Id = 1, Name = "Cort" };
            Manufacturer m2 = new Manufacturer { Id = 2, Name = "Ibanez" };
            Manufacturer m3 = new Manufacturer { Id = 3, Name = "Moog" };
            Manufacturer m4 = new Manufacturer { Id = 4, Name = "Yamaha" };
            Manufacturer m5 = new Manufacturer { Id = 5, Name = "Tama" };
            Manufacturer m6 = new Manufacturer { Id = 6, Name = "Roland" };
            Manufacturer m7 = new Manufacturer { Id = 7, Name = "Fender" };

            Band b1 = new Band { Id = 1, Name = "Thee Oh Sees", Balance= 1 };
            Band b2 = new Band { Id = 2, Name = "Wand", Balance = 4000 };
            Band b3 = new Band { Id = 3, Name = "MGMT", Balance = 11111 };
            Band b4 = new Band { Id = 4, Name = "Tame Impala", Balance = 69420 };
            Band b5 = new Band { Id = 5, Name = "King Gizzard and the Lizard Wizard", Balance = 80085 };
            Band b6 = new Band { Id = 6, Name = "Bragolin", Balance = 1 };

            Instrument i1 = new Instrument { Id = 1, Type = instrumentTypeEnum.STRINGS, Name = "ActionBass 210", ManufacturerId = m1.Id, BandId = b1.Id };
            Instrument i2 = new Instrument { Id = 2, Type = instrumentTypeEnum.PERCUSSION, Name = "Rythm Mate", ManufacturerId = m5.Id, BandId = b2.Id };
            Instrument i3 = new Instrument { Id = 3, Type = instrumentTypeEnum.WIND, Name = "YFL 272", ManufacturerId = m4.Id, BandId = b5.Id };
            Instrument i4 = new Instrument { Id = 4, Type = instrumentTypeEnum.SYNTH, Name = "Mother", ManufacturerId = m3.Id, BandId = b3.Id };
            Instrument i5 = new Instrument { Id = 5, Type = instrumentTypeEnum.STRINGS, Name = "Telecaster Modified", ManufacturerId = m7.Id, BandId = b1.Id };
            Instrument i6 = new Instrument { Id = 6, Type = instrumentTypeEnum.SYNTH, Name = "TR-808", ManufacturerId = m6.Id, BandId = b6.Id };
            Instrument i7 = new Instrument { Id = 7, Type = instrumentTypeEnum.STRINGS, Name = "PIA3761-XB", ManufacturerId = m2.Id, BandId = b4.Id };

            modelBuilder.Entity<Instrument>(entity =>
            {
                //entity.HasKey(m => m.Id);

                entity.HasOne<Manufacturer>(m => m.Manufacturer)
                      .WithMany(m => m.Instruments)
                      .HasForeignKey(m => m.ManufacturerId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne<Band>(b => b.Band)
                      .WithMany(m => m.RequiredInstruments)
                      .HasForeignKey(m => m.BandId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasData(i1, i2, i3, i4, i5, i6, i7);

            });
            modelBuilder.Entity<Manufacturer>().HasData(m1, m2, m3, m4, m5, m6, m7);
            modelBuilder.Entity<Band>().HasData(b1, b2, b3, b4, b5, b6);

            base.OnModelCreating(modelBuilder);
        }

    }
}
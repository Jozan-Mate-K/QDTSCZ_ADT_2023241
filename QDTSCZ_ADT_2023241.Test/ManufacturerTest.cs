using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Test
{
    public class ManufacturerTests
    {
        private Mock<IManufacturerRepository> repository;
        private IManufacturerLogic logic;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<IManufacturerRepository>();

            var manufacturers = new List<Manufacturer>() {
                new Manufacturer {
                    Id = 1,
                    Name = "MockManufacturer1"
                },
                new Manufacturer {
                    Id = 2,
                    Name = "MockManufacturer2"
                },
                new Manufacturer {
                    Id = 3,
                    Name = "MockManufacturer3"
                },
                new Manufacturer {
                    Id = 4,
                    Name = "MockManufacturer4"
                },
            };
                        
            var instruments = new List<Instrument>() {
                new Instrument {
                    Id = 1,
                    Name = "MockInstrument1",
                    Type = instrumentTypeEnum.PERCUSSION,
                    ManufacturerId = 1,
                    Manufacturer = manufacturers.Find(m => m.Id == 1),
                    Year = 2023
                },new Instrument {
                    Id = 2,
                    Name = "MockInstrument2",
                    Type = instrumentTypeEnum.STRINGS,
                    ManufacturerId = 2,
                    Manufacturer = manufacturers.Find(m => m.Id == 2),
                    Year = 2023
                },new Instrument {
                    Id = 3,
                    Name = "MockInstrument3",
                    Type = instrumentTypeEnum.WIND,
                    ManufacturerId = 3,
                    Manufacturer = manufacturers.Find(m => m.Id == 3),

                    Year = 2023
                },new Instrument {
                    Id = 4,
                    Name = "MockInstrument4",
                    Type = instrumentTypeEnum.SYNTH,
                    ManufacturerId = 4,
                    Manufacturer = manufacturers.Find(m => m.Id == 4),
                    Year = 2023
                },
            };

            manufacturers.ForEach(m => m.Instruments.Add(instruments.Find(i => i.Id == m.Id)));

            repository.Setup((m) => m.Entities).Returns(manufacturers);
            repository.Setup((m) => m.GetAll()).Returns(() => manufacturers.AsQueryable());
            repository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => manufacturers.Find(e => e.Id == 1));
            logic = new ManufacturerLogic(repository.Object);
        }

        [Test]
        public void CreateTest()
        {
            Manufacturer manu = new Manufacturer() { Name = "" };
            Assert.Throws<ArgumentNullException>(() => logic.AddNew(manu));
        }

        [Test]
        public void GetInstrumentsByManufacturerTest()
        {
            Assert.That(logic.Get(1).Id, Is.EqualTo(1));
            Assert.That(logic.GetInstrumentsByManufacturers(1).First(), Is.TypeOf<Instrument>());
            Assert.That(logic.GetInstrumentsByManufacturers(1).First().Id, Is.EqualTo(1));
        }

        [Test]
        public void GetTest()
        {
            Assert.That(logic.GetAll().Count(), Is.EqualTo(4));
        }
    }
}

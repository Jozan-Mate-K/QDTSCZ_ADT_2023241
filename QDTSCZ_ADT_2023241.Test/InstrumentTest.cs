using Moq;
using NUnit.Framework;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;
using System.Xml.Linq;

namespace QDTSCZ_ADT_2023241.Test
{
    public class InstrumentTests
    {

        private Mock<IInstrumentRepository> iRepository;
        private Mock<IManufacturerRepository> mRepository;
        private Mock<IBandRepository> bRepository;
        private IInstrumentLogic logic;

        [SetUp]
        public void Setup()
        {
            iRepository = new Mock<IInstrumentRepository>();

            var instruments = new List<Instrument>() {
                new Instrument {
                    Id = 1,
                    Name = "MockInstrument1",
                    Type = instrumentTypeEnum.PERCUSSION,
                    ManufacturerId = 1,
                    Manufacturer = new Manufacturer()
                    {
                        Id = 1,
                        Name = "MockManufacturer1"
                    },
                    Year = 2023
                },new Instrument {
                    Id = 2,
                    Name = "MockInstrument2",
                    Type = instrumentTypeEnum.STRINGS,
                    ManufacturerId = 2,
                    Year = 2023
                },new Instrument {
                    Id = 3,
                    Name = "MockInstrument3",
                    Type = instrumentTypeEnum.WIND,
                    ManufacturerId = 3,
                    Year = 2023
                },new Instrument {
                    Id = 4,
                    Name = "MockInstrument4",
                    Type = instrumentTypeEnum.SYNTH,
                    ManufacturerId = 4,
                    Year = 2023
                },
            };
            mRepository = new Mock<IManufacturerRepository>();

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
            };
            bRepository = new Mock<IBandRepository>();

            var bands = new List<Band>() {
                new Band()
                {
                    Id = 1,
                    Name = "Mockband1"
                },
                new Band()
                {
                    Id = 2,
                    Name = "Mockband2"
                },
                new Band()
                {
                    Id = 3,
                    Name = "Mockband3"
                },
                new Band()
                {
                    Id = 4,
                    Name = "Mockband4"
                }
            };
            bRepository.Setup((m) => m.Entities).Returns(bands);
            bRepository.Setup((m) => m.GetAll()).Returns(() => bands.AsQueryable());
            bRepository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => bands[1]);


            iRepository.Setup((m) => m.Entities).Returns(instruments);
            iRepository.Setup((m) => m.GetAll()).Returns(()=> instruments.AsQueryable());
            iRepository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => instruments[1]);

            mRepository.Setup((m) => m.Entities).Returns(manufacturers);
            mRepository.Setup((m) => m.GetAll()).Returns(() => manufacturers.AsQueryable());
            mRepository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => manufacturers[1]);


            logic = new InstrumentLogic(iRepository.Object, mRepository.Object, bRepository.Object);
        }

        [Test]
        public void CreateTest()
        {
            Instrument inst = new Instrument() { Name = "" };
            Assert.Throws<ArgumentNullException>(()=> logic.AddNew(inst));
        }
        [Test]
        public void ManufacturerTest()
        {
            Assert.That(logic.GetManufacturer(1).Id, Is.EqualTo(1));
        }
    }
}
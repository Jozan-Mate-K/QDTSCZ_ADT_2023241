using Moq;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Test1
{
    public class Tests
    {

        private Mock<InstrumentRepository> repository;
        private InstrumentLogic logic;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<InstrumentRepository>();

            var instruments = new List<Instrument>() { 
                new Instrument { 
                    Id = 1, 
                    Name = "MockInstrument1",
                    Color = "Red",
                    Type = instrumentTypeEnum.PERCUSSION,
                    Year = 2023
                },new Instrument {
                    Id = 2,
                    Name = "MockInstrument2",
                    Color = "Red",
                    Type = instrumentTypeEnum.STRINGS,
                    Year = 2023
                },new Instrument {
                    Id = 3,
                    Name = "MockInstrument3",
                    Color = "Red",
                    Type = instrumentTypeEnum.WIND,
                    Year = 2023
                },new Instrument {
                    Id = 4,
                    Name = "MockInstrument4",
                    Color = "Red",
                    Type = instrumentTypeEnum.SYNTH,
                    Year = 2023
                },
            };
            repository.Setup((m) => m.Entities).Returns(instruments);
            repository.Setup((m) => m.GetAll()).Returns(()=> instruments.AsQueryable());
            repository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => instruments[1]);
            logic = new InstrumentLogic(repository.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
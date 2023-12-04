using Moq;
using NUnit.Framework;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;
using QDTSCZ_ADT_2023241.Repository;

namespace QDTSCZ_ADT_2023241.Test
{
    public class BandTests
    {

        private Mock<IBandRepository> repository;
        private IBandLogic logic;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<IBandRepository>();

            var bands = new List<Band>() {
                new Band()
                {
                    Id = 1,
                    Name = "Mockband1",
                    Balance = 10
                },
                new Band()
                {
                    Id = 2,
                    Name = "Mockband2",
                    Balance = 10
                },
                new Band()
                {
                    Id = 3,
                    Name = "Mockband3",
                    Balance = 10
                },
                new Band()
                {
                    Id = 4,
                    Name = "Mockband4",
                    Balance = 10
                }
            };
            repository.Setup((m) => m.Entities).Returns(bands);
            repository.Setup((m) => m.GetAll()).Returns(()=> bands.AsQueryable());
            repository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => bands[1]);
            logic = new BandLogic(repository.Object);
        }

        [Test]
        public void CreateTest()
        {
            Band band = new Band() { Name = "" };
            Assert.Throws<ArgumentNullException>(()=> logic.AddNew(band));
        }
    }
}
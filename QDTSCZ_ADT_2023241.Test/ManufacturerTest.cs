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
            };
            repository.Setup((m) => m.Entities).Returns(manufacturers);
            repository.Setup((m) => m.GetAll()).Returns(() => manufacturers.AsQueryable());
            repository.Setup((m) => m.GetSingle(It.Is<int>(value => value == 1))).Returns(() => manufacturers[1]);
            logic = new ManufacturerLogic(repository.Object);
        }

        [Test]
        public void CreateTest()
        {
            Manufacturer manu = new Manufacturer() { Name = "" };
            Assert.Throws<ArgumentNullException>(() => logic.AddNew(manu));
        }
    }
}

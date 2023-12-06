using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;

namespace QDTSCZ_ADT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private IManufacturerLogic iLogic;

        public ManufacturerController(IManufacturerLogic iLogic)
        {

            this.iLogic = iLogic;
        }

        [HttpGet]
        public IEnumerable<Manufacturer> Get()
        {
            return iLogic.GetAll();
        }
        [HttpGet("{id}")]
        public Manufacturer Get(int Id)
        {
            return iLogic.Get(Id);
        }

        [HttpPost]
        public void Post([FromBody] Manufacturer manufacturer)
        {
            iLogic.AddNew(manufacturer);
        }

        // PUT
        [HttpPut]
        public void Put([FromBody] Manufacturer manufacturer)
        {
            iLogic.UpdateName(manufacturer);
        }
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            iLogic.Delete(Id);
        }
    }
}

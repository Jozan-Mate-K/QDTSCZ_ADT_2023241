using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;

namespace QDTSCZ_ADT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NonCrudController : ControllerBase
    {
        private IInstrumentLogic iLogic;
        private IManufacturerLogic mLogic;

        public NonCrudController(
            IInstrumentLogic iLogic, 
            IManufacturerLogic mLogic)
        {

            this.iLogic = iLogic;
            this.mLogic = mLogic;
        }

        [HttpGet("manufacturer/{id}")]
        public Manufacturer GetManufacturer(int Id)
        {
            return iLogic.GetManufacturer(Id);
        }

        [HttpGet("band/{id}")]
        public Band GetBand(int Id)
        {
            return iLogic.GetBand(Id);
        }

        [HttpGet("intrumentsByManufacturer/{id}")]
        public IEnumerable<Instrument> GetInstrumentManufacturers(int Id)
        {
            return mLogic.GetInstrumentsByManufacturers(Id);
        }

    }
}

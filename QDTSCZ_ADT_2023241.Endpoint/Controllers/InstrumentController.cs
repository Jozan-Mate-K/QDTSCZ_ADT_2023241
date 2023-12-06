using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;

namespace QDTSCZ_ADT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private IInstrumentLogic iLogic;

        public InstrumentController(IInstrumentLogic iLogic)
        {

            this.iLogic = iLogic;
        }

        [HttpGet]
        public IEnumerable<Instrument> Get()
        {
            return iLogic.GetAll();
        }
        [HttpGet("{id}")]
        public Instrument Get(int Id)
        {
            return iLogic.Get(Id);
        }

        [HttpPost]
        public void Post([FromBody] Instrument instrument)
        {
            Console.WriteLine(instrument);
            iLogic.AddNew(instrument);
        }

        // PUT
        [HttpPut]
        public void Put([FromBody] Instrument instrument)
        {
            iLogic.Update(instrument);
        }


        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            iLogic.Delete(Id);
        }
    }
}

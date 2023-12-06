using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QDTSCZ_ADT_2023241.Logic;
using QDTSCZ_ADT_2023241.Models;

namespace QDTSCZ_ADT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private IBandLogic iLogic;

        public BandController(IBandLogic iLogic)
        {

            this.iLogic = iLogic;
        }

        [HttpGet]
        public IEnumerable<Band> Get()
        {
            return iLogic.GetAll();
        }
        [HttpGet("{id}")]
        public Band Get(int Id)
        {
            return iLogic.Get(Id);
        }

        [HttpPost]
        public void Post([FromBody] Band band)
        {
            iLogic.AddNew(band);
        }

        // PUT
        [HttpPut]
        public void Put([FromBody] Band band)
        {
            iLogic.UpdateBandBalance(band);
        }
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
            iLogic.Delete(Id);
        }
    }
}

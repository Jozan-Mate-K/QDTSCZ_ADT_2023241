using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QDTSCZ_ADT_2023241.Repository
{
    public class InstrumentRepository: Repository<Instrument>, IInstrumentRepository
    {

        public InstrumentRepository(Context context) : base(context) { }

        public override Instrument GetSingle(int Id)
        {
            return GetAll().SingleOrDefault(instrument => instrument.Id == Id);
        }

        public void UpdateBand (int Id, int bandId) 
        {

            GetSingle(Id).BandId = bandId;
            context.SaveChanges();
            

        }
    }
}

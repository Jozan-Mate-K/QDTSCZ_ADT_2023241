using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QDTSCZ_ADT_2023241.Repository
{
    internal class InstrumentRepository: Repository<Instrument>
    {

        public InstrumentRepository(Context context) : base(context) { }

        public override Instrument GetSingle(int Id)
        {
            return GetAll().SingleOrDefault(instrument => instrument.Id == Id);
        }

        public void UpdateBand (int Id, Band band) 
        {
            if(GetSingle(Id) == null)
            {
                throw new ArgumentException("There is no instrument with that id");
            }

            GetSingle(Id).Band = band;
            context.SaveChanges();
            

        }
    }
}

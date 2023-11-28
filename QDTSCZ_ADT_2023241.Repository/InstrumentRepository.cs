using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    internal class InstrumentRepository: Repository<Instrument>
    {

        public InstrumentRepository(Context context) : base(context) { }

        public override Instrument GetSingle(int Id)
        {
            return GetAll().SingleOrDefault(instrument => instrument.Id == Id);
        }
    }
}

using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    public interface IInstrumentRepository: IRepository<Instrument>
    {
        public void UpdateBand(int Id, Band band);
    }
}

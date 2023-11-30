using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Logic
{
    public interface IInstrumentLogic
    {
        Instrument Get(int Id);
        IEnumerable<Instrument> GetAll();
        void AddNew(Instrument instrument);
        void UpdateBand(Instrument instrument, Band band);
        void Delete(int Id);
    }
}

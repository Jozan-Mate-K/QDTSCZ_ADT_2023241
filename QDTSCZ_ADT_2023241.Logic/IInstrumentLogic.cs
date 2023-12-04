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
        void Update(Instrument instrument);
        void Delete(int Id);
    }
}

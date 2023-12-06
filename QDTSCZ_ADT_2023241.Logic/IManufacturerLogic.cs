using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Logic
{
    public interface IManufacturerLogic
    {
        Manufacturer Get(int Id);
        IEnumerable<Manufacturer> GetAll();
        void AddNew(Manufacturer manufacturer);
        void UpdateName(Manufacturer manufacturer);
        void Delete(int Id);

        public IEnumerable<Instrument> GetInstrumentsByManufacturers(int Id);

    }
}

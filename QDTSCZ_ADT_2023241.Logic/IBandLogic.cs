using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Logic
{
    public interface IBandLogic
    {
        Band Get(int Id);
        IEnumerable<Band> GetAll();
        void AddNew(Band band);
        void UpdateBandBalance(Band band);
        void Delete(int Id);
    }
}

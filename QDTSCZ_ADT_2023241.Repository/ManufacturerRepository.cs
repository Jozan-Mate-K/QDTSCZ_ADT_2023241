using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    internal class ManufacturerRepository: Repository<Manufacturer>
    {
        public ManufacturerRepository(Context context) : base(context) { }

        public override Manufacturer GetSingle(int Id)
        {
            return GetAll().SingleOrDefault(manufacturer => manufacturer.Id == Id);
        }
    }
}

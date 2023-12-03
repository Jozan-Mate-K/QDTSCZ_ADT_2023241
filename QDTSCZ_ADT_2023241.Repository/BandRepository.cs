using QDTSCZ_ADT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    public class BandRepository : Repository<Band>, IBandRepository
    {
        public BandRepository(Context context) : base(context) { }

        public override Band GetSingle(int Id)
        {
            return GetAll().SingleOrDefault(band => band.Id == Id) ;
        }
        public void UpdateBandBalance(int Id, int? balance)
        {
            GetSingle(Id).Balance = balance;
            context.SaveChanges();


        }
    }
}

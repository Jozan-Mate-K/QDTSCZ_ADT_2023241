using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetSingle(int ID);
        IQueryable<T> GetAll();
        void Add(T element);
        void Remove(T element);
        IEnumerable<T> Entities { get; set; }
    }
}

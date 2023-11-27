using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDTSCZ_ADT_2023241.Repository
{
    public abstract class Repository<T> where T : class
    {
        protected Context context;
        protected Repository(Context context)
        {
            this.context = context;
        }
        public void Add(T element)
        {
            context.Set<T>().Add(element);
            context.SaveChanges();
        }
        public void Remove(T element)
        {
            context.Set<T>().Remove(element);
            context.SaveChanges();
        }
        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
        public abstract T GetSingle(int ID);
    }
}

using dayOne.Models;

namespace dayOne.Repositries
{
    public class Repository<T, Y> : IRepository<T, Y> where T : class
    {
        private Context Context;
        public Repository(Context context)
        {

            Context = context;

        }
        public void Add(T Entity)
        {
            Context.Set<T>().Add(Entity);

        }

        public void HardDelete(Y id)
        {
            try
            {
                T Element = GetById(id);
                Context.Set<T>().Remove(Element);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual IEnumerable<T> GetAll(Func<T,bool> predicate)
        {
          return  Context.Set<T>().Where(predicate).ToList();
        }

        public T GetById(Y id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update( T Entity)
        {
            Context.Set<T>().Update(Entity);    

        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}

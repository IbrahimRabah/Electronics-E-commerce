namespace dayOne.Repositries
{
    public interface IRepository<T,Y> where T : class

    {
        void Add(T Entity);
        void Update(T Entity);
        void HardDelete(Y id);
        void SaveChanges();
        T GetById(Y id);
        IEnumerable<T> GetAll(Func<T, bool> predicate);
    }
}

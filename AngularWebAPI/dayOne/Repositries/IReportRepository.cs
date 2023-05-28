using dayOne.Models;

namespace dayOne.Repositries
{
    public interface IReportRepository : IRepository<Report,int>
    {
        void SoftDelete(int id);
        void Add(Report r);

        IEnumerable<Report> GetAll(Func<Report, bool> predicate);
    }
}

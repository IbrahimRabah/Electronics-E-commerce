using dayOne.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dayOne.Repositries
{
    public class ReportRepository : Repository<Report, int>, IReportRepository
    {
        private Context Context;
        public ReportRepository(Context context) : base(context)
        {
            Context = context;
        }

        public void Add(Report r)
        {
            Context.Reports.Add(r);
           Context.SaveChanges();

        }

        public void SoftDelete(int id)
        {
            Report report = GetById(id);
            report.isDeleted = true;
            Context.SaveChanges();
        }

        public IEnumerable<Report> GetAll(Func<Report, bool> predicate)
        {
            return Context.Reports.Where(predicate).ToList();
        }
    }
}

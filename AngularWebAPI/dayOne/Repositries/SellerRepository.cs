using dayOne.Models;
using Microsoft.EntityFrameworkCore;

namespace dayOne.Repositries
{
    public class SellerRepository : Repository<Seller, string>,ISellerRepository
    {
        private Context Context;
        private string confirmMessage = "Confirmed";
        private string regictMessage = "Regicted";
        public SellerRepository(Context context) : base(context)
        {
            Context = context;
        }
        public override List<Seller> GetAll(Func<Seller, bool> predicate)
        {
            List<Seller> sellers = Context.Seller.Include(c => c.ApplicationUser).Where(predicate).ToList();
            return sellers;
        }
        public Seller GetById(string id)
        {
            //return GetById(id);
            return Context.Seller.Include(e => e.ApplicationUser).FirstOrDefault(e => e.ApplicationUserId == id);

        }
        public IEnumerable<Customer> GetCustomers()
        {
            List<Customer> customers = Context.Customer.Include("ApplicationUser").ToList();
            return customers;
        }

        public void SoftDelete(String id)
        {
            Seller seller = GetById(id);
            seller.ApplicationUser.isDeleted = true;

        }

        public string confirm(string id)
        {
            Seller seller = GetById(id);
            seller.Status = status.confirmed;
            Context.SaveChanges();
            return confirmMessage;
        }

        public string reject(string id)
        {
            Seller seller = GetById(id);
            seller.Status = status.rejected;
            Context.SaveChanges();
            return regictMessage;
        }
    }
}

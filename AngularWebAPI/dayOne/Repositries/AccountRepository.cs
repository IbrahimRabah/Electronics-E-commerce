using dayOne.Models;

namespace dayOne.Repositries
{
    public class AccountRepository: IAccountRepository
    {
        private Context Context;
        public AccountRepository(Context context) 
        {
            Context = context;
        }

        public void AddShipper(Shipper shipper)
        {
            Context.Shipper.Add(shipper);
            Context.SaveChanges();  
        }
        public void AddCustomer(Customer customer)
        {
            Context.Customer.Add(customer);
            Context.SaveChanges();
        }

        public void AddSeller(Seller seller)
        {
            Context.Seller.Add(seller);
            Context.SaveChanges();
        }

    }
}

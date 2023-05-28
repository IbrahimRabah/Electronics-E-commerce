using dayOne.Models;

namespace dayOne.Repositries
{
    public class CustomerRepository: Repository<Customer, string>,ICustomerRepository
    {
        private Context Context;
        public CustomerRepository(Context context) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(String id)
        {
            Customer customer = GetById(id);
            customer.ApplicationUser.isDeleted = true;

        }
    }
}

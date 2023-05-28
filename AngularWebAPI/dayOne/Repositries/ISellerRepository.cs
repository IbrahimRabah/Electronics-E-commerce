using dayOne.Models;

namespace dayOne.Repositries
{
    public interface ISellerRepository:IRepository<Seller,string>
    {
        void SoftDelete(String id);
        IEnumerable<Customer> GetCustomers();

        string confirm(string id);
        string reject(string id);

    }
}

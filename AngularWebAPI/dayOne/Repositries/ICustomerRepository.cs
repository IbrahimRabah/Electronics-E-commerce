using dayOne.Models;

namespace dayOne.Repositries
{
    public interface ICustomerRepository:IRepository<Customer,string>
    {
        void SoftDelete(String id);
    }
}

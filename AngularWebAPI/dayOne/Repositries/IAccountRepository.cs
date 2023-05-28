using dayOne.Models;

namespace dayOne.Repositries
{
    public interface IAccountRepository
    {
        void AddShipper(Shipper shipper);
        void AddSeller(Seller seller);
        void AddCustomer(Customer customer);
    }
}
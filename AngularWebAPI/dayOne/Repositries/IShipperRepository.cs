using dayOne.DTO;
using dayOne.Models;

namespace dayOne.Repositries
{
    public interface IShipperRepository:IRepository<Shipper,string>
    {
        void SoftDelete(String id);
        IEnumerable<Shipper> GetAll(Func<Shipper, bool> predicate);
        Shipper GetById(string id);
        void Edit(string id, Shipper newShipper);
        void OrderDone(int orderId, string ShId);
        IEnumerable<orderPure> GetOrders(string Id);
        string confirm(string id);
        string reject(string id);
    }
}

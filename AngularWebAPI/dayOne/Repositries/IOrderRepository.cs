using dayOne.Models;

namespace dayOne.Repositries
{
    public interface IOrderRepository:IRepository<Order,int>
    {
        void SoftDelete(int id);

        IEnumerable<Order> GetAllWithoutFunc();
        double GetTotalprice();
        double Getprofit();
        Order GetOrder(string Orderid);
    }
}

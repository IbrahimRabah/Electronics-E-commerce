using dayOne.Models;
using Microsoft.Identity.Client;

namespace dayOne.Repositries
{
    public class OrderRepository : Repository<Order, int>,IOrderRepository
    {
        private Context Context;
        private double totalprice = 0;
        private double profit = 0;
        public OrderRepository(Context context) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(int id)
        {
            Order order = GetById(id);
            order.isDeleted = true;

        }
        public IEnumerable<Order> GetAllWithoutFunc()
        {
            return Context.Order;
        }

        public double GetTotalprice()
        {
            totalprice = Context.Order.Sum(order => order.TotalPrice);
            return totalprice;
        }

        public double Getprofit()
        {
            totalprice = GetTotalprice();
            profit = (totalprice - (totalprice * .05));
            return profit;
        }
        public Order GetOrder(string Orderid)
        {
            return Context.Order.Where(o => o.CustomerId == Orderid).FirstOrDefault();
        }
    }
}

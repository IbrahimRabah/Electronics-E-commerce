using dayOne.Models;

namespace dayOne.Repositries
{
    public interface IProductOrderRepository:IRepository<OrderProducts,int>
    {

        void SoftDelete(int id);
    }
}

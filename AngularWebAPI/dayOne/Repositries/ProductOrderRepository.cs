using dayOne.Models;

namespace dayOne.Repositries
{
    public class ProductOrderRepository : Repository<OrderProducts, int>, IProductOrderRepository
    {
        private Context Context;
        public ProductOrderRepository(Context context) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(int id)
        {
            OrderProducts orderProducts = GetById(id);
            orderProducts.isDeleted = true;

        }
    }
}

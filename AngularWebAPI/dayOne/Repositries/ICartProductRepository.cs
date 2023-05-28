using dayOne.DTO;
using dayOne.Models;

namespace dayOne.Repositries
{
    public interface ICartProductRepository : IRepository<ProductCart, int>
    {
        void SoftDelete(int id);

        string DeleteItem(int id);
        string IncreamentByOne(int id);
        string DecreamentByOne(int id);
        IEnumerable<ProductCartDto> GetAllProductCarts(string customarId);
    }
}

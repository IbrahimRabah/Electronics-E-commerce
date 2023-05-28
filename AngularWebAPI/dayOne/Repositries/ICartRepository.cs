using dayOne.Models;

namespace dayOne.Repositries
{
    public interface ICartRepository :IRepository<Cart,string>
    {
       void SoftDelete(String id);
    }
}

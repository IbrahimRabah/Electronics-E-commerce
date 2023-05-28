using dayOne.Models;
using Microsoft.EntityFrameworkCore;

namespace dayOne.Repositries
{
    public class CartRepository: Repository<Cart, string>,ICartRepository
    {
        private Context Context;
        public CartRepository(Context context) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(String id)
        {
            Cart cart = GetById(id);
            cart.isDeleted = true;

        }
        public Cart GetById(string id)
        {
            return Context.Cart.Where(c=>c.CustomerCartId==id).Include(e=>e.CartProducts).FirstOrDefault();
        }

    }
}

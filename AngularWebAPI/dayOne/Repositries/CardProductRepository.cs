using dayOne.DTO;
using dayOne.Models;
using Microsoft.EntityFrameworkCore;

namespace dayOne.Repositries
{
    public class CardProductRepository :Repository<ProductCart, int>, ICartProductRepository
    {
        private Context Context;
        public CardProductRepository(Context context) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(int id)
        {
            ProductCart cartProducts = GetById(id);
            cartProducts.isDeleted = true;

        }


        public string DecreamentByOne(int id)
        {
            ProductCart productCart = GetById(id);
            productCart.Quantity -= 1;
            SaveChanges();
            return "Decreased";
        }

        public string DeleteItem(int id)
        {
            HardDelete(id);
            SaveChanges();
            return ("Deleted");
        }

        public string IncreamentByOne(int id)
        {
            ProductCart productCart = GetById(id);
            productCart.Quantity += 1;
            SaveChanges();


            return "Increased";
        }


        public IEnumerable<ProductCartDto> GetAllProductCarts(string customarId)
        {
            List<ProductCart> ProductCarts = Context.productCart.Where(p=>p.CartId==customarId).Include(x => x.Product).ToList();
            List<ProductCartDto>list= new List<ProductCartDto>();
            foreach (ProductCart cart in ProductCarts)
            {
                list.Add(new ProductCartDto
                {
                    Quantity = cart.Quantity,
                    Name = cart.Product.Name,
                    Description= cart.Product.Description,
                    Price= cart.Product.Price,
                    MainImage= cart.Product.MainImage,
                    productcartId = cart.Id,
                    
                }); 
            }
            return list;
        }
    }
}

using dayOne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dayOne.Repositries
{
    public class ProductRepository : Repository<Product, int>,IProductRepository
    {
        private Context Context;
        public ProductRepository(Context context) : base(context)
        {
            Context = context;
        }
 

        public Product GetById(int id)
        {
            return Context.Product.Where(p => p.Id == id).Include("ProductImages").FirstOrDefault();
        }

        public void SoftDelete(int id)
        {
            Product product = GetById(id);
            product.isDeleted = true;

        }

      

     
    }
}

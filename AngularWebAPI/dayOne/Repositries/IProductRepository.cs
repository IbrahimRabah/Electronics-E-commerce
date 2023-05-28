using dayOne.Models;
using Microsoft.AspNetCore.Mvc;

namespace dayOne.Repositries
{
    public interface IProductRepository:IRepository<Product,int>
    {
      

        void SoftDelete(int id);
    }
}

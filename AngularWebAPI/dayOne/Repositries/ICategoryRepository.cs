using dayOne.Models;

namespace dayOne.Repositries
{
    public interface ICategoryRepository:IRepository<Category,int>
    {
        void SoftDelete(int id);
        int GetIdOfCategryByName(string name);

    }
}

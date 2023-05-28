using dayOne.Models;

namespace dayOne.Repositries
{
    public class CategoryRepository : Repository<Category, int>,ICategoryRepository
    {
        private Context Context;
        public CategoryRepository(Context context) : base(context)
        {
            Context = context;
        }
        public void SoftDelete(int id)
        {
            Category category = GetById(id);
            category.isDeleted = true;

        }

        public int GetIdOfCategryByName(string name)
        {
            return Context.Category.FirstOrDefault(c => c.Name == name).Id;
        }
    }
}

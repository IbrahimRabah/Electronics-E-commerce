using dayOne.Models;

namespace dayOne.Repositries
{
    public class ImageRepository: Repository<ProductImage, int>,IImageRepository
    {
        private Context Context;
        public ImageRepository(Context context) : base(context)
        {
            Context = context;
        }
    
    }
}

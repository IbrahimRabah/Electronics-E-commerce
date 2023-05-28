using dayOne.Models;

namespace dayOne.Repositries
{
    public class ApplictionUserRepository: Repository<ApplicationUser,string>
    {
        private Context Context;
        public ApplictionUserRepository( Context context):base(context) 
        {
            Context=context;
        }
       public void SoftDelete(String id)
        {
            ApplicationUser applicationUser=GetById(id);
            applicationUser.isDeleted=true;
             
        }
    }
}

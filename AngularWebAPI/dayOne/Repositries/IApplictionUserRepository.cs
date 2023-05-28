using dayOne.Models;

namespace dayOne.Repositries
{
    public interface IApplictionUserRepository: IRepository<ApplicationUser,string>
    {
        void SoftDelete(String id);
    }
}

using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Dal.Repositories.EFConcretes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}

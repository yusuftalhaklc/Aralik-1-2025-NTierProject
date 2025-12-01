using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Dal.Repositories.EFConcretes
{
    public class AppUserProfileRepository : BaseRepository<AppUserProfile>, IAppUserProfileRepository
    {
        public AppUserProfileRepository(AppDbContext context) : base(context)
        {
        }
    }
}

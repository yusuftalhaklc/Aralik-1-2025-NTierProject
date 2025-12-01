using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Dal.Repositories.EFConcretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}

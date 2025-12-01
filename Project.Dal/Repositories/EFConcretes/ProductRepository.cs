using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Dal.Repositories.EFConcretes
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}

using Project.Dal.Context;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Dal.Repositories.EFConcretes
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }
    }
}

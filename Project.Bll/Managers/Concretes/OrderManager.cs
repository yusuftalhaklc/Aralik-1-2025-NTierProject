using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class OrderManager : BaseManager<OrderDto,Order>, IOrderManager
    {
        private readonly IOrderRepository _repository;
        public OrderManager(IOrderRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }


}

using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class OrderDetailManager : BaseManager<OrderDetailDto, OrderDetail>, IOrderDetailManager
    {
        private readonly IOrderDetailRepository _repository;
        public OrderDetailManager(IOrderDetailRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }


}

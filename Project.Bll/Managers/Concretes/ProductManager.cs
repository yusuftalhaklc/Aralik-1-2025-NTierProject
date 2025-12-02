using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class ProductManager : BaseManager<ProductDto,Product>, IProductManager
    {
        private readonly IProductRepository _repository;
        public ProductManager(IProductRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }


}

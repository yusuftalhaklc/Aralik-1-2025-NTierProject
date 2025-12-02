using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class CategoryManager : BaseManager<CategoryDto, Category>, ICategoryManager
    {
        private readonly ICategoryRepository _repository;
        public CategoryManager(ICategoryRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }


}

using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class AppUserManager : BaseManager<AppUserDto,AppUser>, IAppUserManager
    {
        private readonly IAppUserRepository _repository;
        public AppUserManager(IAppUserRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }


}

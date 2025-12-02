using AutoMapper;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Models;

namespace Project.Bll.Managers.Concretes
{
    public class AppUserProfileManager : BaseManager<AppUserProfileDto, AppUserProfile>, IAppUserProfileManager
    {
        private readonly IAppUserProfileRepository _repository;
        public AppUserProfileManager(IAppUserProfileRepository repository, IMapper mapper) : base(repository,mapper)
        {
            _repository = repository;
        }
    }


}

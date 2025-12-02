using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _appUserProfileManager;

        public AppUserProfileController(IAppUserProfileManager appUserProfileManager)
        {
            _appUserProfileManager = appUserProfileManager;
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;

        public AppUserController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }
    }

}

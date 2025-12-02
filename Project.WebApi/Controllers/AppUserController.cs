using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.WebApi.Model.RequestModels;
using Project.WebApi.Model.ResponseModels;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserManager appUserManager, IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUsersList()
        {
            IEnumerable<AppUserDto> values = await _appUserManager.GetAllAsync();
            List<AppUserResponseModel> response = _mapper.Map<List<AppUserResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById([FromRoute] int id)
        {
            AppUserDto value = await _appUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser([FromBody] CreateAppUserRequestModel model)
        {
            AppUserDto appUser = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(appUser);
            return Ok("veri ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser([FromBody] UpdateAppUserRequestModel model)
        {
            AppUserDto appUser = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(appUser);
            return Ok("veri güncelleme başarılı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUser([FromRoute] int id)
        {
            string message = await _appUserManager.SoftDeleteAsync(id);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser([FromRoute] int id)
        {
            string message = await _appUserManager.HardDeleteAsync(id);
            return Ok(message);
        }
    }

}

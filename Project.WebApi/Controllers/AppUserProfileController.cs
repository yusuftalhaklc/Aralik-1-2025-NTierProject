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
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _appUserProfileManager;
        private readonly IMapper _mapper;

        public AppUserProfileController(IAppUserProfileManager appUserProfileManager, IMapper mapper)
        {
            _appUserProfileManager = appUserProfileManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfilesList()
        {
            IEnumerable<AppUserProfileDto> values = await _appUserProfileManager.GetAllAsync();
            List<AppUserProfileResponseModel> response = _mapper.Map<List<AppUserProfileResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfileById([FromRoute] int id)
        {
            AppUserProfileDto value = await _appUserProfileManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserProfileResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUserProfile([FromBody] CreateAppUserProfileRequestModel model)
        {
            AppUserProfileDto appUserProfile = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.CreateAsync(appUserProfile);
            return Ok("veri ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUserProfile([FromBody] UpdateAppUserProfileRequestModel model)
        {
            AppUserProfileDto appUserProfile = _mapper.Map<AppUserProfileDto>(model);
            await _appUserProfileManager.UpdateAsync(appUserProfile);
            return Ok("veri güncelleme başarılı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyAppUserProfile([FromRoute] int id)
        {
            string message = await _appUserProfileManager.SoftDeleteAsync(id);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUserProfile([FromRoute] int id)
        {
            string message = await _appUserProfileManager.HardDeleteAsync(id);
            return Ok(message);
        }
    }

}

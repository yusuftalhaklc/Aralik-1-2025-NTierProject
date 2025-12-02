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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesList()
        {
            IEnumerable<CategoryDto> values = await _categoryManager.GetAllAsync();
            List<CategoryResponseModel> response = _mapper.Map<List<CategoryResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            CategoryDto value = await _categoryManager.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestModel model)
        {
            CategoryDto category = _mapper.Map<CategoryDto>(model);
            await _categoryManager.CreateAsync(category);
            return Ok("veri ekleme başarılı");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequestModel model)
        {
            CategoryDto category = _mapper.Map<CategoryDto>(model);
            await _categoryManager.UpdateAsync(category);
            return Ok("veri güncelleme başarılı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyCategory([FromRoute] int id)
        {
            string message = await _categoryManager.SoftDeleteAsync(id);
            return Ok(message);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            string message = await _categoryManager.HardDeleteAsync(id);
            return Ok(message);
        }


    }

}

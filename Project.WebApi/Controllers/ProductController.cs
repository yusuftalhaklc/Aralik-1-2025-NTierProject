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
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsList()
        {
            IEnumerable<ProductDto> values = await _productManager.GetAllAsync();
            List<ProductResponseModel> response = _mapper.Map<List<ProductResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            ProductDto value = await _productManager.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestModel model)
        {
            ProductDto product = _mapper.Map<ProductDto>(model);
            await _productManager.CreateAsync(product);
            return Ok("veri ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequestModel model)
        {
            ProductDto product = _mapper.Map<ProductDto>(model);
            await _productManager.UpdateAsync(product);
            return Ok("veri güncelleme başarılı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyProduct([FromRoute] int id)
        {
            string message = await _productManager.SoftDeleteAsync(id);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            string message = await _productManager.HardDeleteAsync(id);
            return Ok(message);
        }
    }

}

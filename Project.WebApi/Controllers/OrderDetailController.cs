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
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailManager orderDetailManager, IMapper mapper)
        {
            _orderDetailManager = orderDetailManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailsList()
        {
            IEnumerable<OrderDetailDto> values = await _orderDetailManager.GetAllAsync();
            List<OrderDetailResponseModel> response = _mapper.Map<List<OrderDetailResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById([FromRoute] int id)
        {
            OrderDetailDto value = await _orderDetailManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderDetailResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail([FromBody] CreateOrderDetailRequestModel model)
        {
            OrderDetailDto orderDetail = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.CreateAsync(orderDetail);
            return Ok("veri ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail([FromBody] UpdateOrderDetailRequestModel model)
        {
            OrderDetailDto orderDetail = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.UpdateAsync(orderDetail);
            return Ok("veri güncelleme başarılı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrderDetail([FromRoute] int id)
        {
            string message = await _orderDetailManager.SoftDeleteAsync(id);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail([FromRoute] int id)
        {
            string message = await _orderDetailManager.HardDeleteAsync(id);
            return Ok(message);
        }
    }

}

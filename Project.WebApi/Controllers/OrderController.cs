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
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrderController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            IEnumerable<OrderDto> values = await _orderManager.GetAllAsync();
            List<OrderResponseModel> response = _mapper.Map<List<OrderResponseModel>>(values);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            OrderDto value = await _orderManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestModel model)
        {
            OrderDto order = _mapper.Map<OrderDto>(model);
            await _orderManager.CreateAsync(order);
            return Ok("veri ekleme başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequestModel model)
        {
            OrderDto order = _mapper.Map<OrderDto>(model);
            await _orderManager.UpdateAsync(order);
            return Ok("veri güncelleme başarılı");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrder([FromRoute] int id)
        {
            string message = await _orderManager.SoftDeleteAsync(id);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            string message = await _orderManager.HardDeleteAsync(id);
            return Ok(message);
        }
    }

}

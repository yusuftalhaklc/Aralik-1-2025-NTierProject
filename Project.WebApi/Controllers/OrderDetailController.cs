using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _orderDetailManager;

        public OrderDetailController(IOrderDetailManager orderDetailManager)
        {
            _orderDetailManager = orderDetailManager;
        }
    }

}

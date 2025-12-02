using Microsoft.AspNetCore.Mvc;
using Project.Bll.Managers.Abstracts;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
    }

}

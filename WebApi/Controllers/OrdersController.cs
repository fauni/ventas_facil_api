using Core.Entities.Errors;
using Core.Entities.Ventas;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Ventas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderRepository _repository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<OrdersDTO> orders = new List<OrdersDTO>();

                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetAll(sessionID);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
                    foreach (var item in result.Result) 
                    {
                        OrdersDTO ordersDTO = MapeoOrders.MapToDTO(item);
                        orders.Add(ordersDTO);
                    }
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.SaveOrder(sessionID, order);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

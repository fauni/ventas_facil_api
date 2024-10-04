using Core.Entities.Errors;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Items;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemBatchController : ControllerBase
    {
        IItemData _repository;

        public ItemBatchController(IItemData repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sessionID = Request.Headers["Cookie"];
            var result = _repository.GetLotesPorItemAll();
            return Ok(
                new {
                    resultado = result,
                    count = result.Count,
                    mensaje = "Operación con exito"
                }
            );
        }
    }
}

using Core.Entities.Errors;
using Core.Entities.Producto;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.Items;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemUnidadMedidaController : ControllerBase
    {
        IItemUnidadMedidaRepository _repository;

        public ItemUnidadMedidaController(IItemUnidadMedidaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var sessionID = Request.Headers["Cookie"];
            var result = await _repository.GetAll(sessionID);

            try
            {
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    return Ok(result.Result.Skip(1));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

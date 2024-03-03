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
    public class ItemGroupController : ControllerBase
    {
        IItemGroupRepository _repository;
        public ItemGroupController(IItemGroupRepository repository)
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
                } else
                {
                    List<ItemGrupoDTO> dto = new List<ItemGrupoDTO>();
                    foreach (var item in result.Result)
                    {
                        dto.Add(MapeoItemGroup.MapToDTO(item));
                    }
                    return Ok(dto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sessionID = Request.Headers["Cookie"];
            var result = await _repository.GetPorNumero(sessionID, id);

            try
            {
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    ItemGrupoDTO dto = MapeoItemGroup.MapToDTO(result.Result);
                    return Ok(dto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

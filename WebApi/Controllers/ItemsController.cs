using Core.Entities.Errors;
using Core.Interfaces;

using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        public ItemsController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _itemRepository.GetAll(sessionID);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    List<ItemDTO> dto = new List<ItemDTO>();
                    foreach (var item in result.Result)
                    {
                        var map = MapeoItem.MapToDTO(item);
                        dto.Add(map);
                    }
                    return Ok(dto);
                }

            } catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

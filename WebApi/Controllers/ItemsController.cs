using Core.Entities.Errors;
using Core.Interfaces;

using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.DTOs.Items;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemGroupRepository _itemGroupRepository;
        public ItemsController(IItemRepository itemRepository, IItemGroupRepository itemGroupRepository)
        {
            _itemRepository = itemRepository;
            _itemGroupRepository = itemGroupRepository;
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
                        var resultGrupo = await _itemGroupRepository.GetPorNumero(sessionID, (int)item.ItemsGroupCode);
                        var map = MapeoItem.MapToDTO(item, MapeoItemGroup.MapToDTO(resultGrupo.Result));
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

using Core.Entities.Errors;
using Core.Interfaces;
using Data.Interfaces;
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
        private readonly IItemData _itemData;
        public ItemsController(IItemRepository itemRepository, IItemGroupRepository itemGroupRepository, IItemData itemData)
        {
            _itemRepository = itemRepository;
            _itemGroupRepository = itemGroupRepository;
            _itemData = itemData;
        }

        [HttpGet]
        public async Task<IActionResult> Get(String text)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _itemRepository.GetAll(sessionID, text);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    List<ItemDTO> dto = new List<ItemDTO>();
                    foreach (var item in result.Result)
                    {
                        var infoItemLote = _itemData.GetLotesPorItem(item);
                        var resultGrupo = await _itemGroupRepository.GetPorNumero(sessionID, (int)item.ItemsGroupCode);
                        var map = MapeoItem.MapToDTO(item, MapeoItemGroup.MapToDTO(resultGrupo.Result));
                        map.InformacionItemLote = infoItemLote;
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

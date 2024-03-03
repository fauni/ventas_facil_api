using BusinessLogic.Logic;
using Core.Entities.Errors;
using Core.Entities.Ventas;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.DTOs.Ventas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPersonController : ControllerBase
    {
        private readonly ISalesPersonsRepository _salesPersonsRepository;
        public SalesPersonController(ISalesPersonsRepository salesPersonsRepository)
        {
            _salesPersonsRepository = salesPersonsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _salesPersonsRepository.GetAll(sessionID);

                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    List<SalesPersonsDTO> dto = new List<SalesPersonsDTO>();
                    foreach (var item in result.Result)
                    {
                        var map = MapeoSalesPerson.MapToDTO(item);
                        dto.Add(map);
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
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _salesPersonsRepository.GetById(sessionID, id);

                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
                    return Ok(MapeoSalesPerson.MapToDTO(result.Result));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

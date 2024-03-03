using Core.Entities.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.SocioNegocio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        IBPAdressRepository _repository;

        public AdressesController(IBPAdressRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetAll(sessionID);

                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    List<BPDireccionDTO> dto = new List<BPDireccionDTO>();
                    foreach (var item in result.Result)
                    {
                        dto.Add(MapeoBPDireccion.MapToDTO(item));
                    }
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

using BusinessLogic.Logic;
using Core.Entities.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.DTOs.SocioNegocio;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTermsTypesController : ControllerBase
    {
        private readonly IPaymentTermsTypesRepository _repository;
        public PaymentTermsTypesController(IPaymentTermsTypesRepository paymentTermsTypesRepository)
        {
            _repository = paymentTermsTypesRepository;
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
                    List<CondicionPagoDTO> dto = new List<CondicionPagoDTO>();
                    foreach (var item in result.Result)
                    {
                        var map = MapeoPaymentTermsTypes.MapToDTO(item);
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
        public async Task<IActionResult> GetByCodigo(int id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetByGrupo(sessionID, id);
                if (result.Error != null) 
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
                    return Ok(MapeoPaymentTermsTypes.MapToDTO(result.Result));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

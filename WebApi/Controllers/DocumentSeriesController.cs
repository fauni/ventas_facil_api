using Core.Entities.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentSeriesController : ControllerBase
    {
        IDocumentSeriesRepository _repository;

        public DocumentSeriesController(IDocumentSeriesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCode(int id)
        {
            List<DocumentSeriesDTO> series = new List<DocumentSeriesDTO>();
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetForDocumentCode(sessionID, id);

                if(result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
                    foreach (var item in result.Result)
                    {
                        DocumentSeriesDTO seriesDTO = new DocumentSeriesDTO();
                        seriesDTO = MapeoDocumentSeriesDTO.MapToDTO(item);
                        series.Add(seriesDTO);
                    }
                }
    
                return Ok(series);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

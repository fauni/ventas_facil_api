using Core.Entities;
using Core.Entities.Errors;
using Core.Interfaces;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSerieController : ControllerBase
    {
        IUserSerieData _userSerieData;
        public UserSerieController(IUserSerieData userSerieData)
        {
            _userSerieData = userSerieData;
        }

        [HttpGet("GetSerieByUser/{id}")]

        public IActionResult GetSerieByUser(string id)
        {
            try
            {
                var result = _userSerieData.GetSeriesByUser(id);
                if (result.Count > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            } catch (Exception ex) { 
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

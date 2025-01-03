﻿using Core.Entities.Errors;
using Core.Entities.Producto;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPartnersController : ControllerBase
    {
        private readonly IBusinessPartnersRepository _businessPartnersRepository;
        public BusinessPartnersController(IBusinessPartnersRepository businessPartnersRepository)
        {
            _businessPartnersRepository = businessPartnersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int top = 10, int skip = 0, string text = "")
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _businessPartnersRepository.GetAll(sessionID, top, skip, text);

                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
                    
                    List<BusinessPartnersDTO> dto = new List<BusinessPartnersDTO>();
                    foreach (var item in result.Result)
                    {
                        var map = MapeoBusinessPartner.MapToDTO(item);
                        dto.Add(map);
                    }
                    
                    return Ok(dto);
                }
            } catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _businessPartnersRepository.GetByCodigo(sessionID, id);

                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    return Ok(MapeoBusinessPartner.MapToDTO(result.Result));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

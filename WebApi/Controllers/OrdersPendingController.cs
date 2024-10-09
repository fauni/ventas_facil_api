using Core.Entities.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs.SocioNegocio;
using WebApi.DTOs.Ventas;
using WebApi.DTOs;
using Core.Entities.Ventas;
using static Org.BouncyCastle.Utilities.Test.FixedSecureRandom;
using Core.Entities.Series;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersPendingController : ControllerBase
    {
        IOrderPendingRepository _repository;
        ISalesPersonsRepository _salesPersonsRepository;
        IContactEmployeeRepository _contactEmployeeRepository;
        IBusinessPartnersRepository _businessPartnersRepository;
        IDocumentSeriesRepository _documentSeriesRepository;

        public OrdersPendingController(IOrderPendingRepository repository, ISalesPersonsRepository salesPersonsRepository, IContactEmployeeRepository contactEmployeeRepository, IBusinessPartnersRepository businessPartnersRepository, IDocumentSeriesRepository documentSeriesRepository)
        {
            _repository = repository;
            _salesPersonsRepository = salesPersonsRepository;
            _contactEmployeeRepository = contactEmployeeRepository;
            _businessPartnersRepository = businessPartnersRepository;
            _documentSeriesRepository = documentSeriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int top = 10, int skip = 0, string search = "")
        {
            try
            {
                List<OrdersDTO> orders = new List<OrdersDTO>();

                var sessionID = Request.Headers["Cookie"];
                var result = search.Length > 0
                    ? await _repository.GetBySearch(sessionID, search)
                    : await _repository.GetAll(sessionID, top, skip);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    foreach (var item in result.Result)
                    {
                        EmpleadoContactoDTO contactoDTO = new EmpleadoContactoDTO();
                        DocumentSeries series = new DocumentSeries();
                        var resultSerie = _documentSeriesRepository.GetForDocumentCode(sessionID, 17);
                        series = resultSerie.Result.Result.FirstOrDefault(s => s.Series == item.Series);
                        
                        var resultSocioNegocio = await _businessPartnersRepository.GetByCodigo(sessionID, item.CardCode);
                        var resultSalesPerson = await _salesPersonsRepository.GetById(sessionID, item.SalesPersonCode);
                        var resultContactEmployee = await _contactEmployeeRepository.GetAll(sessionID);

                        OrdersDTO ordersDTO = MapeoOrderDTO.MapToDTO(item);
                        foreach (var contacto in resultContactEmployee.Result)
                        {
                            if (contacto.InternalCode == ordersDTO.CodigoPersonaDeContacto)
                            {
                                contactoDTO = MapeoEmpleadoContacto.MapToDTO(contacto);
                            }
                        }
                        ordersDTO.Cliente = MapeoBusinessPartner.MapToDTO(resultSocioNegocio.Result);
                        ordersDTO.Empleado = MapeoSalesPerson.MapToDTO(resultSalesPerson.Result);
                        ordersDTO.Contacto = contactoDTO;
                        // ordersDTO.CodigoSerieNumeracion = series.Series;
                        ordersDTO.NombreSerieNumeracion = series.Name;
                        orders.Add(ordersDTO);
                    }
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpGet("Aprobados")]
        public async Task<IActionResult> Aprobados(int top = 10, int skip = 0, string search = "")
        {
            try
            {
                List<OrdersDTO> orders = new List<OrdersDTO>();

                var sessionID = Request.Headers["Cookie"];
                var result = search.Length > 0
                    ? await _repository.GetBySearchAprobados(sessionID, search)
                    : await _repository.GetAllAprobados(sessionID, top, skip);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    foreach (var item in result.Result)
                    {
                        EmpleadoContactoDTO contactoDTO = new EmpleadoContactoDTO();
                        var resultSocioNegocio = await _businessPartnersRepository.GetByCodigo(sessionID, item.CardCode);
                        var resultSalesPerson = await _salesPersonsRepository.GetById(sessionID, item.SalesPersonCode);
                        var resultContactEmployee = await _contactEmployeeRepository.GetAll(sessionID);

                        DocumentSeries series = new DocumentSeries();
                        var resultSerie = _documentSeriesRepository.GetForDocumentCode(sessionID, 17);
                        series = resultSerie.Result.Result.FirstOrDefault(s => s.Series == item.Series);

                        OrdersDTO ordersDTO = MapeoOrderDTO.MapToDTO(item);
                        foreach (var contacto in resultContactEmployee.Result)
                        {
                            if (contacto.InternalCode == ordersDTO.CodigoPersonaDeContacto)
                            {
                                contactoDTO = MapeoEmpleadoContacto.MapToDTO(contacto);
                            }
                        }
                        ordersDTO.Cliente = MapeoBusinessPartner.MapToDTO(resultSocioNegocio.Result);
                        ordersDTO.Empleado = MapeoSalesPerson.MapToDTO(resultSalesPerson.Result);
                        ordersDTO.Contacto = contactoDTO;
                        ordersDTO.NombreSerieNumeracion = series.Name;
                        orders.Add(ordersDTO);
                    }
                }
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpGet("CrearDocumento/{id}")]
        public async Task<IActionResult> CrearDocumento(int id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.CrearDocumento(sessionID, id);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                return Ok(result.Result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
    }
}

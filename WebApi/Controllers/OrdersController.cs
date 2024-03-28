using Core.Entities.Errors;
using Core.Entities.Producto;
using Core.Entities.SocioNegocio;
using Core.Entities.Ventas;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTOs;
using WebApi.DTOs.SocioNegocio;
using WebApi.DTOs.Ventas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderRepository _repository;
        ISalesPersonsRepository _salesPersonsRepository;
        IContactEmployeeRepository _contactEmployeeRepository;
        IBusinessPartnersRepository _businessPartnersRepository;
        public OrdersController(
            IOrderRepository orderRepository, 
            ISalesPersonsRepository salesPersonsRepository, 
            IContactEmployeeRepository contactEmployeeRepository,
            IBusinessPartnersRepository businessPartnersRepository
        )
        {
            _repository = orderRepository;
            _salesPersonsRepository = salesPersonsRepository;
            _contactEmployeeRepository = contactEmployeeRepository;
            _businessPartnersRepository = businessPartnersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<OrdersDTO> orders = new List<OrdersDTO>();

                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetAll(sessionID);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
                    foreach (var item in result.Result) 
                    {
                        EmpleadoContactoDTO contactoDTO = new EmpleadoContactoDTO();
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetById(sessionID, id);

                EmpleadoContactoDTO contactoDTO = new EmpleadoContactoDTO();
                var resultSocioNegocio = await _businessPartnersRepository.GetByCodigo(sessionID, result.Result.CardCode);
                var resultSalesPerson = await _salesPersonsRepository.GetById(sessionID, result.Result.SalesPersonCode);
                var resultContactEmployee = await _contactEmployeeRepository.GetAll(sessionID);

                OrdersDTO ordersDTO = MapeoOrderDTO.MapToDTO(result.Result);
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


                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    return Ok(ordersDTO);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrdenVentaDTO data)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                OrderGuardar order = MapeoGuardarOrdenVenta.DTOToMap(data);
                

                var result = await _repository.SaveOrder(sessionID, order);
                if (result.Error != null)
                {
                    if (result.Error.StatusCode == 401)
                    {
                        return StatusCode(401, new CodeErrorException(401));
                    }
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                var resultBP = await _businessPartnersRepository.GetByCodigo(sessionID, result.Result.CardCode);
                var resultSP = await _salesPersonsRepository.GetById(sessionID, result.Result.SalesPersonCode);
                var resultContacto = await _contactEmployeeRepository.GetAll(sessionID);

                EmpleadoContactoDTO contactoDTO = new EmpleadoContactoDTO();
                foreach (var contacto in resultContacto.Result)
                {
                    if (contacto.InternalCode == result.Result.ContactPersonCode)
                    {
                        contactoDTO = MapeoEmpleadoContacto.MapToDTO(contacto);
                    }
                }
                
                OrdenVentaDTO ordenVentaDTO = MapeoGuardarOrdenVenta.MapToDTO(result.Result);
                ordenVentaDTO.Cliente = MapeoBusinessPartner.MapToDTO(resultBP.Result);
                ordenVentaDTO.Empleado = MapeoSalesPerson.MapToDTO(resultSP.Result);
                ordenVentaDTO.Contacto = String.IsNullOrEmpty(contactoDTO.CodigoCliente) ? null : contactoDTO;
                return Ok(ordenVentaDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] OrdenVentaUpdateDTO data)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                OrderModificar order = MapeoModificarOrdenVenta.DTOToMap(data);

                var result = await _repository.UpdateOrder(sessionID, id, order);
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
        /*
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.SaveOrder(sessionID, order);
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
        */
    }
}

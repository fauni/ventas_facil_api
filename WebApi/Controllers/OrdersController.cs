using Core.Entities.Errors;
using Core.Entities.Ventas;
using Core.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Text.Json;
using WebApi.DTOs;
using WebApi.DTOs.SocioNegocio;
using WebApi.DTOs.Ventas;
using Newtonsoft.Json;
using BusinessLogic.Logic;
using Core.Entities.Series;

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
        IDocumentSeriesRepository _documentSeriesRepository;
        public OrdersController(
            IOrderRepository orderRepository, 
            ISalesPersonsRepository salesPersonsRepository, 
            IContactEmployeeRepository contactEmployeeRepository,
            IBusinessPartnersRepository businessPartnersRepository,
            IDocumentSeriesRepository documentSeriesRepository
        )
        {
            _repository = orderRepository;
            _salesPersonsRepository = salesPersonsRepository;
            _contactEmployeeRepository = contactEmployeeRepository;
            _businessPartnersRepository = businessPartnersRepository;
            _documentSeriesRepository = documentSeriesRepository;
        }

        #region METODOS MOSTRAR, GUARDAR, ACTUALIZAR

        [HttpGet]
        public async Task<IActionResult> Get(int top = 10, int skip = 0, string search = "")
        {
            try
            {
                List<OrdersDTO> orders = new List<OrdersDTO>();

                var sessionID = Request.Headers["Cookie"];
                var result = search.Length > 0 
                    ? await _repository.GetForText(sessionID, search)
                    : await _repository.GetAll(sessionID, top, skip);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetById(sessionID, id);

                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                } else
                {
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
            string jsonData = JsonConvert.SerializeObject(data);
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
                    } else if (result.Error.StatusCode == 404)
                    {
                        return Ok();
                    } else
                    {
                        return StatusCode(result.Error.StatusCode, result.Error);
                    }
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

        [HttpPatch("modificarEstadoLinea/{id}")]
        public async Task<IActionResult> ModificarEstadoLinea(int id, [FromBody] OrdenVentaUpdateDTO data)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                OrderModificarLinea order = MapeoModificarEstadoLinea.DTOToMap(data);

                var result = await _repository.UpdateStatusLineOrder(sessionID, id, order);
                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                return Ok(result.Result);
                // return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }

        #endregion

        #region REPORTES  
        [HttpGet("GenerarReporte/{id}")]
        public async Task<IActionResult> GenerarReporte(int id)
        {
            try
            {
                var sessionID = Request.Headers["Cookie"];
                var result = await _repository.GetById(sessionID, id);


                if (result.Error != null)
                {
                    return StatusCode(result.Error.StatusCode, result.Error);
                }
                else
                {
                    //EmpleadoContactoDTO contactoDTO = new EmpleadoContactoDTO();
                    //var resultSocioNegocio = await _businessPartnersRepository.GetByCodigo(sessionID, result.Result.CardCode);
                    //var resultSalesPerson = await _salesPersonsRepository.GetById(sessionID, result.Result.SalesPersonCode);
                    //var resultContactEmployee = await _contactEmployeeRepository.GetAll(sessionID);

                    //OrdersDTO ordersDTO = MapeoOrderDTO.MapToDTO(result.Result);
                    //foreach (var contacto in resultContactEmployee.Result)
                    //{
                    //    if (contacto.InternalCode == ordersDTO.CodigoPersonaDeContacto)
                    //    {
                    //        contactoDTO = MapeoEmpleadoContacto.MapToDTO(contacto);
                    //    }
                    //}
                    //ordersDTO.Cliente = MapeoBusinessPartner.MapToDTO(resultSocioNegocio.Result);
                    //ordersDTO.Empleado = MapeoSalesPerson.MapToDTO(resultSalesPerson.Result);
                    //ordersDTO.Contacto = contactoDTO;

                    // return Ok(ordersDTO);


                    #region datos
                    //Order data = new Order();
                    //data.DocEntry = 246000053;
                    //data.DocNum = 54;
                    //data.DocDate = DateTime.Now;
                    //data.CardCode = "00005";
                    //data.CardName = "INSTITUTO DE MEDICINA NUCLEAR INAMEN";
                    //data.SalesPersonCode = 30;
                    //data.Comments = "Creado por app mobile 10-03-2024";
                    //data.DocTotal = 10;
                    //List<DocumentLineOrder> line = new List<DocumentLineOrder>();
                    //line.Add(
                    //    new DocumentLineOrder
                    //    {
                    //        LineNum = 0,
                    //        ItemCode = "01E001",
                    //        ItemDescription = "CONSERVADOR DE REACTIVOS 1P",
                    //        Quantity = 1,
                    //        UnitPrice = 10,
                    //        ShipDate = Convert.ToDateTime("2024-04-18T00:00:00+00:00"),
                    //        MeasureUnit = "UND",
                    //        Currency = "BS",
                    //        LineTotal = 10
                    //    }
                    //);
                    //line.Add(
                    //            new DocumentLineOrder
                    //            {
                    //                LineNum = 0,
                    //                ItemCode = "01E001",
                    //                ItemDescription = "CONSERVADOR DE REACTIVOS 1P",
                    //                Quantity = 1,
                    //                UnitPrice = 10,
                    //                ShipDate = Convert.ToDateTime("2024-04-18T00:00:00+00:00"),
                    //                MeasureUnit = "UND",
                    //                Currency = "BS",
                    //                LineTotal = 10
                    //            }
                    //        );
                    //data.DocumentLines = line;
                    #endregion



                    var pdfStream = _repository.GenerarPDF(result.Result);
                    return File(pdfStream.ToArray(), "application/pdf", "Report.pdf");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CodeErrorException(500, ex.Message, ex.StackTrace));
            }
        }
        #endregion
    }
}

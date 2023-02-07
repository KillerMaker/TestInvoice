using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestInvoiceAPI.DataBase_Handler;
using TestInvoiceAPI.DTOs.Customer;
using TestInvoiceAPI.DTOs.Invoice;
using TestInvoiceAPI.Models;
using TestInvoiceAPI.Repo;

namespace TestInvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        InvoiceHeaderRepo _headerRepo;
        InvoiceDetailRepo _detailRepo;

        IMapper _mapper;

        public InvoiceController(ISqlServerHandler dbHandler, IConfigurationSection config, IMapper mapper)
        {
            _headerRepo = new InvoiceHeaderRepo(dbHandler, config);
            _detailRepo = new InvoiceDetailRepo(dbHandler, config);
            _mapper = mapper;
        }

        [HttpGet]
        public async IAsyncEnumerable<Invoice> Get([FromQuery] int? id = null)
        {
            await foreach (var header in (id.HasValue) ? _headerRepo.GetById(id.Value) : _headerRepo.GetAll())
            {
                Invoice invoice = new Invoice(header);

                await foreach (var detail in _detailRepo.GetById(header.id.Value))
                    invoice.AddDetail(detail);

                yield return invoice;
            }
        }

        [HttpPost]
        public async Task<object> Post([FromBody] InvoiceCreateDTO invoiceDTO)
        {
            Invoice invoice = _mapper.Map<Invoice>(invoiceDTO);

            invoice.details.ForEach(x => 
            { 
                x.subTotal = x.price * x.quantity;
                x.totalItbis = x.subTotal * 0.18m;
                x.total = x.subTotal + x.totalItbis;
            });
            
            invoice.header.subTotal = invoice.details.Sum(x => x.total);
            invoice.header.totalItbis = invoice.header.subTotal * 0.18m;
            invoice.header.total = invoice.header.subTotal + invoice.header.totalItbis;

            int invoiceId = await _headerRepo.Create(invoice.header);
            
            foreach(var detail in invoice.details)
            {
                detail.invoiceId = invoiceId;

                await _detailRepo.Create(detail);
            }

            return new { message = "Insertado correctamente" };
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await foreach (var item in _detailRepo.GetById(id))
                await _detailRepo.Delete(item.id.Value);

            await _headerRepo.Delete(id);
            return Ok(new { message = "Eliminado correctamente" });
        }
    }
}

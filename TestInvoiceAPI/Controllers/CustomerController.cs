using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestInvoiceAPI.DataBase_Handler;
using TestInvoiceAPI.DTOs.Customer;
using TestInvoiceAPI.Models;
using TestInvoiceAPI.Repo;

namespace TestInvoiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerRepo _repo;
        IMapper _mapper;

        public CustomerController(ISqlServerHandler dbHandler, IConfigurationSection config, IMapper mapper)
        {
            _repo= new CustomerRepo(dbHandler, config);
            _mapper=mapper;
        }

        [HttpGet]
        public async IAsyncEnumerable<CustomerGetDTO>Get([FromQuery]int? id = null)
        {
            await foreach (var item in (id.HasValue) ? _repo.GetById(id.Value) : _repo.GetAll())
               yield return _mapper.Map<CustomerGetDTO>(item);
        }

        [HttpPost]
        public async Task<ActionResult>Post([FromBody]CustomerCreateDTO customer)
        {
            await _repo.Create(_mapper.Map<Customer>(customer));
            return Ok(new {message="Insertado Correctamente."}); 
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody]CustomerUpdateDTO customer)
        {
            await _repo.Update(_mapper.Map<Customer>(customer));
            return Ok(new { message = "Actualizado Correctamente." });
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            await _repo.Delete(id);
            return Ok(new { message = "Elimindado Correctamente." });
        }
    }
}

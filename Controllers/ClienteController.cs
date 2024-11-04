using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2_FloricelaArguedas_WebApplication.Controllers
{
    [Route("api/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // GET: api/<ClienteController>
        [HttpGet("Index/")]
        public ActionResult <IList<Cliente>> Index()
        {
            try 
            {
                IList<Cliente> listaClientes = new List<Cliente>();
                listaClientes = Data.MemoriaCliente.Index();
                return Ok(listaClientes);
            }
            catch 
            {
                return BadRequest();
            }
        }


        // GET api/<ClienteController>/5
        [HttpGet("GetOne/{id}")]
        public ActionResult <Cliente> ObtenerCliente(int id)
        {
            try
            {
                Cliente ClienteEncontrado = Data.MemoriaCliente.SearchOne(id);
                return Ok(ClienteEncontrado);
            }
            catch
            {
                return BadRequest();
            }
        }


        // POST api/<ClienteController>
        [HttpPost("Create/")]
        public ActionResult <Cliente> Create([FromBody] Cliente ClienteNuevo)
        {
            try
            {
                Cliente NewClient = Data.MemoriaCliente.Create(ClienteNuevo);
                return Ok(NewClient);
            }
            catch
            {
                return BadRequest();
            }
        }




        // PUT api/<ClienteController>/5
        [HttpPut("Editar/")]
        public ActionResult <Cliente> Editar([FromBody] Cliente ClienteEditado)
        {
            try
            {
                Cliente ClienteActualizado = Data.MemoriaCliente.Editar(ClienteEditado);
                return Ok(ClienteActualizado);
            }
            catch
            {
                return BadRequest();
            }

        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Data.MemoriaCliente.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: api/<ClienteController>
        [HttpGet("ReporteSemanal/")]
        public ActionResult<IList<Cliente>> ReporteSemanal()
        {
            try
            {
                IList<Mantenimiento> listaMantenimientos = new List<Mantenimiento>();
                listaMantenimientos = Data.MemoriaMantenimiento.Index();

                IList<Cliente> listaClientesRW = new List<Cliente>();
                listaClientesRW = Data.MemoriaCliente.GetReportWeek(listaMantenimientos);
                return Ok(listaClientesRW);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

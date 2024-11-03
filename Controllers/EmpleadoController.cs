using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2_FloricelaArguedas_WebApplication.Controllers
{
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        // GET: api/<EmpleadoController>
        [HttpGet("Index/")]
        public ActionResult <IList<Empleado>> Index()
        {
            try 
            {
                IList<Empleado> listaEmpleados = new List<Empleado>();
                listaEmpleados = Data.MemoriaEmpleado.Index();
                return Ok(listaEmpleados);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("GetOne/{id}")]
        public ActionResult<Empleado> ObtenerEmpleado (int id)
        {
            try 
            { 
                Empleado EmpleadoEncontrado = Data.MemoriaEmpleado.SearchOne(id);
                return Ok(EmpleadoEncontrado);
            } 
            catch 
            {
                return BadRequest();
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost("Create/")]
        public ActionResult<Empleado> Create([FromBody] Empleado EmpleadoNuevo)
        {
            try 
            {
                Empleado NewEmployee = Data.MemoriaEmpleado.Create(EmpleadoNuevo);
                return Ok(NewEmployee);
            } 
            catch 
            {
                return BadRequest();
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("Editar/")]
        public ActionResult<Empleado> Editar([FromBody] Empleado EmpleadoEditado)
        {
            try 
            {
                Empleado EmpleadoActualizado = Data.MemoriaEmpleado.Editar(EmpleadoEditado);
                return Ok(EmpleadoActualizado);
            }
            catch 
            {   
                return BadRequest();
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try 
            {
                Data.MemoriaEmpleado.Delete(id);
                return Ok();
            } 
            catch 
            {
                return BadRequest();
            }
        }
    }
}

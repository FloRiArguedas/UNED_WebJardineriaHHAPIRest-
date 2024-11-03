using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2_FloricelaArguedas_WebApplication.Controllers
{
    [Route("api/Mantenimiento")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        // GET: api/<Mantenimiento>
        [HttpGet("Index/")]
        public ActionResult<IList<Mantenimiento>> Index()
        {
            try
            {
                IList<Mantenimiento> listaMantenimiento = new List<Mantenimiento>();
                listaMantenimiento = Data.MemoriaMantenimiento.Index();
                return Ok(listaMantenimiento);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<Mantenimiento>/5
        [HttpGet("GetOne/{id}")]
        public ActionResult<Mantenimiento> ObtenerMantenimiento(int id)
        {
            try
            {
                Mantenimiento MantenimientoEncontrado = Data.MemoriaMantenimiento.SearchOne(id);
                return Ok(MantenimientoEncontrado);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<Mantenimiento>
        [HttpPost("Create/")]
        public ActionResult<Mantenimiento> Create([FromBody] Mantenimiento MantenimimentoNuevo)
        {
            try
            {
                Mantenimiento NewMaintenance = Data.MemoriaMantenimiento.Create(MantenimimentoNuevo);
                return Ok(NewMaintenance);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<Mantenimiento>/5
        [HttpPut("Editar/")]
        public ActionResult<Mantenimiento> Editar([FromBody] Mantenimiento MantenimientoEditado)
        {
            try
            {
                Mantenimiento MantenimientoActualizado = Data.MemoriaMantenimiento.Edit(MantenimientoEditado);
                return Ok(MantenimientoActualizado);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<Mantenimiento>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Data.MemoriaMantenimiento.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

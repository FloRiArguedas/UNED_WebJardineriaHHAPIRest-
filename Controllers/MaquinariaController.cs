using Microsoft.AspNetCore.Mvc;
using P2_FloricelaArguedas_WebApplication.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P2_FloricelaArguedas_WebApplication.Controllers
{
    [Route("api/Maquinaria")]
    [ApiController]
    public class MaquinariaController : ControllerBase
    {
        // GET: api/<Maquinaria>
        [HttpGet("Index/")]
        public ActionResult <IList<Maquinaria>> Index()
        {
            try 
            {
                IList<Maquinaria> listaMaquinaria = new List<Maquinaria>();
                listaMaquinaria = Data.MemoriaMaquinaria.Index();
                return Ok(listaMaquinaria);

            } 
            catch 
            {
                return BadRequest();
            }
        }

        // GET api/<Maquinaria>/5
        [HttpGet("GetOne/{id}")]
        public ActionResult <Maquinaria> ObtenerMaquinaria(int id)
        {
            try
            {
                Maquinaria MaquinariaEncontrada = Data.MemoriaMaquinaria.SearchOne(id);
                return Ok(MaquinariaEncontrada);
            }
            catch 
            {
                return BadRequest();
            }
        }

        // POST api/<Maquinaria>
        [HttpPost("Create/")]
        public ActionResult<Maquinaria> Create([FromBody] Maquinaria MaquinariaNueva)
        {
            try
            {
                Maquinaria NewMachinery = Data.MemoriaMaquinaria.Create(MaquinariaNueva);
                return Ok(NewMachinery);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<Maquinaria>/5
        [HttpPut("Editar/")]
        public ActionResult <Maquinaria> Editar([FromBody] Maquinaria MaquinariaEditada)
        {
            try
            {
                Maquinaria MaquinariaActualizada = Data.MemoriaMaquinaria.Edit(MaquinariaEditada);
                return Ok(MaquinariaActualizada);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<Maquinaria>/5
        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Data.MemoriaMaquinaria.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

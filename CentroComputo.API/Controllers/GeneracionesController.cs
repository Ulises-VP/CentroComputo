using AutoMapper;
using CentroComputo.data.DataContext;
using CentroComputo.DTOS;
using EIN.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace CentroComputo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneracionesController : ControllerBase
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;
        public GeneracionesController(BaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var generaciones = _context.Generaciones
                    .Where(x=>x.EstaActivo==true)
                .Select(x => _mapper.Map<GeneracionGetDTO>(x))
                .ToList();

                if (generaciones == null || generaciones.Count == 0)
                    return NoContent();

                return Ok(generaciones);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpPost]
        public IActionResult Post([FromBody] GeneracionSetDTO newObj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var obj = _mapper.Map<GeneracionEntity>(newObj);
                _context.Generaciones.Add(obj);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), newObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var generacion = _context.Generaciones.Find(id);

                if (generacion == null)
                    return NotFound();

                //_context.Generaciones.Remove(generacion);
                generacion.EstaActivo = false;
                _context.Generaciones.Update(generacion);
                _context.SaveChanges();
                return Ok("Generacion eliminadas correctamente");
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult put(int id,[FromBody]GeneracionSetDTO updateObj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var generacion = _context.Generaciones.Where(x=> x.ID==id && x.EstaActivo).FirstOrDefault();

                if (generacion == null)
                    return NotFound();

                generacion.Nombre = updateObj.Nombre;
                _context.Generaciones.Update(generacion);
                _context.SaveChanges();
                return Ok("Generacion actualizada correctamente");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult patch(int id,[FromBody] GeneracionEntity updateObj)
        {
            return Ok("Generacion actualizada parcialmente correctamente");   
        }
    }
}

using AutoMapper;
using CentroComputo.data.DataContext;
using CentroComputo.DTOS;
using CentroComputoDTOS;
using EIN.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CentroComputo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {

        private readonly BaseContext _context;
        private readonly IMapper _mapper;

       public GruposController(BaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

        [HttpGet]
        public IActionResult Listar()
        {

            var lista = _context.Grupos
                .Include(x => x.Generacion)
                .Select(x => _mapper.Map<GrupoGetDTO>(x));
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Guardar(GrupoSetDTO newObj)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var obj = _mapper.Map<GrupoEntity>(newObj);
                _context.Grupos.Add(obj);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Listar), newObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

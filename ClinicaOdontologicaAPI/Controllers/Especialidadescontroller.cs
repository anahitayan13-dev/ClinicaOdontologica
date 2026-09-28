using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public EspecialidadesController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Especialidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidades()
        {
            return await _context.Especialidades.ToListAsync();
        }

        // GET: api/Especialidades/5
        [HttpGet("{idespecialidad}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidad(int idespecialidad)
        {
            var especialidad = await _context.Especialidades.FindAsync(idespecialidad);

            if (especialidad == null)
            {
                return NotFound();
            }

            return especialidad;
        }

        // POST: api/Especialidades
        [HttpPost]
        public async Task<ActionResult<Especialidad>> PostEspecialidad(Especialidad especialidad)
        {
            _context.Especialidades.Add(especialidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEspecialidad), new { idespecialidad = especialidad.IdEspecialidad }, especialidad);
        }

        // PUT: api/Especialidades/5
        [HttpPut("{idespecialidad}")]
        public async Task<IActionResult> PutEspecialidad(int idespecialidad, Especialidad especialidad)
        {
            if (idespecialidad != especialidad.IdEspecialidad)
            {
                return BadRequest();
            }

            _context.Entry(especialidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(idespecialidad))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Especialidades/5
        [HttpDelete("{idespecialidad}")]
        public async Task<IActionResult> DeleteEspecialidad(int idespecialidad)
        {
            var especialidad = await _context.Especialidades.FindAsync(idespecialidad);
            if (especialidad == null)
            {
                return NotFound();
            }

            _context.Especialidades.Remove(especialidad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EspecialidadExists(int idespecialidad)
        {
            return _context.Especialidades.Any(e => e.IdEspecialidad == idespecialidad);
        }
    }
}
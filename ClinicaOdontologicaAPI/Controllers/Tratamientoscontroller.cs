using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public TratamientosController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Tratamientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tratamiento>>> GetTratamientos()
        {
            return await _context.Tratamientos.ToListAsync();
        }

        // GET: api/Tratamientos/5
        [HttpGet("{idtratamiento}")]
        public async Task<ActionResult<Tratamiento>> GetTratamiento(int idtratamiento)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(idtratamiento);

            if (tratamiento == null)
            {
                return NotFound();
            }

            return tratamiento;
        }

        // POST: api/Tratamientos
        [HttpPost]
        public async Task<ActionResult<Tratamiento>> PostTratamiento(Tratamiento tratamiento)
        {
            _context.Tratamientos.Add(tratamiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTratamiento), new { idtratamiento = tratamiento.IdTratamiento }, tratamiento);
        }

        // PUT: api/Tratamientos/5
        [HttpPut("{idtratamiento}")]
        public async Task<IActionResult> PutTratamiento(int idtratamiento, Tratamiento tratamiento)
        {
            if (idtratamiento != tratamiento.IdTratamiento)
            {
                return BadRequest();
            }

            _context.Entry(tratamiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TratamientoExists(idtratamiento))
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

        // DELETE: api/Tratamientos/5
        [HttpDelete("{idtratamiento}")]
        public async Task<IActionResult> DeleteTratamiento(int idtratamiento)
        {
            var tratamiento = await _context.Tratamientos.FindAsync(idtratamiento);
            if (tratamiento == null)
            {
                return NotFound();
            }

            _context.Tratamientos.Remove(tratamiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TratamientoExists(int idtratamiento)
        {
            return _context.Tratamientos.Any(e => e.IdTratamiento == idtratamiento);
        }
    }
}
using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public CitasController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Citas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            return await _context.Citas.ToListAsync();
        }

        // GET: api/Citas/5
        [HttpGet("{idcita}")]
        public async Task<ActionResult<Cita>> GetCita(int idcita)
        {
            var cita = await _context.Citas.FindAsync(idcita);

            if (cita == null)
            {
                return NotFound();
            }

            return cita;
        }

        // POST: api/Citas
        [HttpPost]
        public async Task<ActionResult<Cita>> PostCita(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCita), new { idcita = cita.IdCita }, cita);
        }

        // PUT: api/Citas/5
        [HttpPut("{idcita}")]
        public async Task<IActionResult> PutCita(int idcita, Cita cita)
        {
            if (idcita != cita.IdCita)
            {
                return BadRequest();
            }

            _context.Entry(cita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitaExists(idcita))
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

        // DELETE: api/Citas/5
        [HttpDelete("{idcita}")]
        public async Task<IActionResult> DeleteCita(int idcita)
        {
            var cita = await _context.Citas.FindAsync(idcita);
            if (cita == null)
            {
                return NotFound();
            }

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CitaExists(int idcita)
        {
            return _context.Citas.Any(e => e.IdCita == idcita);
        }
    }
}
using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialMedicosController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public HistorialMedicosController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialMedicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMedico>>> GetHistorialMedicos()
        {
            return await _context.HistorialMedicos.ToListAsync();
        }

        // GET: api/HistorialMedicos/5
        [HttpGet("{idhistorial}")]
        public async Task<ActionResult<HistorialMedico>> GetHistorialMedico(int idhistorial)
        {
            var historial = await _context.HistorialMedicos.FindAsync(idhistorial);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // POST: api/HistorialMedicos
        [HttpPost]
        public async Task<ActionResult<HistorialMedico>> PostHistorialMedico(HistorialMedico historial)
        {
            _context.HistorialMedicos.Add(historial);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistorialMedico), new { idhistorial = historial.IdHistorialMedico }, historial);
        }

        // PUT: api/HistorialMedicos/5
        [HttpPut("{idhistorial}")]
        public async Task<IActionResult> PutHistorialMedico(int idhistorial, HistorialMedico historial)
        {
            if (idhistorial != historial.IdHistorialMedico)
            {
                return BadRequest();
            }

            _context.Entry(historial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialMedicoExists(idhistorial))
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

        // DELETE: api/HistorialMedicos/5
        [HttpDelete("{idhistorial}")]
        public async Task<IActionResult> DeleteHistorialMedico(int idhistorial)
        {
            var historial = await _context.HistorialMedicos.FindAsync(idhistorial);
            if (historial == null)
            {
                return NotFound();
            }

            _context.HistorialMedicos.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialMedicoExists(int idhistorial)
        {
            return _context.HistorialMedicos.Any(e => e.IdHistorialMedico == idhistorial);
        }
    }
}
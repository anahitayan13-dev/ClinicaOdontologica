using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesCitasController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public DetallesCitasController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/DetallesCitas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCita>>> GetDetallesCitas()
        {
            return await _context.DetallesCitas.ToListAsync();
        }

        // GET: api/DetallesCitas/5
        [HttpGet("{iddetallecita}")]
        public async Task<ActionResult<DetalleCita>> GetDetalleCita(int iddetallecita)
        {
            var detalle = await _context.DetallesCitas.FindAsync(iddetallecita);

            if (detalle == null)
            {
                return NotFound();
            }

            return detalle;
        }

        // POST: api/DetallesCitas
        [HttpPost]
        public async Task<ActionResult<DetalleCita>> PostDetalleCita(DetalleCita detalle)
        {
            _context.DetallesCitas.Add(detalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDetalleCita), new { iddetallecita = detalle.IdDetalleCita }, detalle);
        }

        // PUT: api/DetallesCitas/5
        [HttpPut("{iddetallecita}")]
        public async Task<IActionResult> PutDetalleCita(int iddetallecita, DetalleCita detalle)
        {
            if (iddetallecita != detalle.IdDetalleCita)
            {
                return BadRequest();
            }

            _context.Entry(detalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleCitaExists(iddetallecita))
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

        // DELETE: api/DetallesCitas/5
        [HttpDelete("{iddetallecita}")]
        public async Task<IActionResult> DeleteDetalleCita(int iddetallecita)
        {
            var detalle = await _context.DetallesCitas.FindAsync(iddetallecita);
            if (detalle == null)
            {
                return NotFound();
            }

            _context.DetallesCitas.Remove(detalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleCitaExists(int iddetallecita)
        {
            return _context.DetallesCitas.Any(e => e.IdDetalleCita == iddetallecita);
        }
    }
}
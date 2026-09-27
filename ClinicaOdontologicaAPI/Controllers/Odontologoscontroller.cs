using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdontologosController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public OdontologosController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Odontologos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Odontologo>>> GetOdontologos()
        {
            return await _context.Odontologos.ToListAsync();
        }

        // GET: api/Odontologos/5
        [HttpGet("{idodontologo}")]
        public async Task<ActionResult<Odontologo>> GetOdontologo(int idodontologo)
        {
            var odontologo = await _context.Odontologos.FindAsync(idodontologo);

            if (odontologo == null)
            {
                return NotFound();
            }

            return odontologo;
        }

        // POST: api/Odontologos
        [HttpPost]
        public async Task<ActionResult<Odontologo>> PostOdontologo(Odontologo odontologo)
        {
            _context.Odontologos.Add(odontologo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOdontologo), new { idodontologo = odontologo.IdOdontologo }, odontologo);
        }

        // PUT: api/Odontologos/5
        [HttpPut("{idodontologo}")]
        public async Task<IActionResult> PutOdontologo(int idodontologo, Odontologo odontologo)
        {
            if (idodontologo != odontologo.IdOdontologo)
            {
                return BadRequest();
            }

            _context.Entry(odontologo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OdontologoExists(idodontologo))
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

        // DELETE: api/Odontologos/5
        [HttpDelete("{idodontologo}")]
        public async Task<IActionResult> DeleteOdontologo(int idodontologo)
        {
            var odontologo = await _context.Odontologos.FindAsync(idodontologo);
            if (odontologo == null)
            {
                return NotFound();
            }

            _context.Odontologos.Remove(odontologo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OdontologoExists(int idodontologo)
        {
            return _context.Odontologos.Any(e => e.IdOdontologo == idodontologo);
        }
    }
}
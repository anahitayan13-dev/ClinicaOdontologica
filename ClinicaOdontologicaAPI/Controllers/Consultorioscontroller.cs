using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultoriosController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public ConsultoriosController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Consultorios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultorio>>> GetConsultorios()
        {
            return await _context.Consultorios.ToListAsync();
        }

        // GET: api/Consultorios/5
        [HttpGet("{idconsultorio}")]
        public async Task<ActionResult<Consultorio>> GetConsultorio(int idconsultorio)
        {
            var consultorio = await _context.Consultorios.FindAsync(idconsultorio);

            if (consultorio == null)
            {
                return NotFound();
            }

            return consultorio;
        }

        // POST: api/Consultorios
        [HttpPost]
        public async Task<ActionResult<Consultorio>> PostConsultorio(Consultorio consultorio)
        {
            _context.Consultorios.Add(consultorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetConsultorio), new { idconsultorio = consultorio.IdConsultorio }, consultorio);
        }

        // PUT: api/Consultorios/5
        [HttpPut("{idconsultorio}")]
        public async Task<IActionResult> PutConsultorio(int idconsultorio, Consultorio consultorio)
        {
            if (idconsultorio != consultorio.IdConsultorio)
            {
                return BadRequest();
            }

            _context.Entry(consultorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultorioExists(idconsultorio))
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

        // DELETE: api/Consultorios/5
        [HttpDelete("{idconsultorio}")]
        public async Task<IActionResult> DeleteConsultorio(int idconsultorio)
        {
            var consultorio = await _context.Consultorios.FindAsync(idconsultorio);
            if (consultorio == null)
            {
                return NotFound();
            }

            _context.Consultorios.Remove(consultorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultorioExists(int idconsultorio)
        {
            return _context.Consultorios.Any(e => e.IdConsultorio == idconsultorio);
        }
    }
}
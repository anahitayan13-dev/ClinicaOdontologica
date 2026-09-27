using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public RecetasController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Recetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetas()
        {
            return await _context.Recetas.ToListAsync();
        }

        // GET: api/Recetas/5
        [HttpGet("{idreceta}")]
        public async Task<ActionResult<Receta>> GetReceta(int idreceta)
        {
            var receta = await _context.Recetas.FindAsync(idreceta);

            if (receta == null)
            {
                return NotFound();
            }

            return receta;
        }

        // POST: api/Recetas
        [HttpPost]
        public async Task<ActionResult<Receta>> PostReceta(Receta receta)
        {
            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReceta), new { idreceta = receta.IdReceta }, receta);
        }

        // PUT: api/Recetas/5
        [HttpPut("{idreceta}")]
        public async Task<IActionResult> PutReceta(int idreceta, Receta receta)
        {
            if (idreceta != receta.IdReceta)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(idreceta))
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

        // DELETE: api/Recetas/5
        [HttpDelete("{idreceta}")]
        public async Task<IActionResult> DeleteReceta(int idreceta)
        {
            var receta = await _context.Recetas.FindAsync(idreceta);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecetaExists(int idreceta)
        {
            return _context.Recetas.Any(e => e.IdReceta == idreceta);
        }
    }
}
using ClinicaOdontologicaAPI.Data;
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaOdontologicaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly ClinicaDbContext _context;

        public FacturasController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }

        // GET: api/Facturas/5
        [HttpGet("{idfactura}")]
        public async Task<ActionResult<Factura>> GetFactura(int idfactura)
        {
            var factura = await _context.Facturas.FindAsync(idfactura);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // POST: api/Facturas
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFactura), new { idfactura = factura.IdFactura }, factura);
        }

        // PUT: api/Facturas/5
        [HttpPut("{idfactura}")]
        public async Task<IActionResult> PutFactura(int idfactura, Factura factura)
        {
            if (idfactura != factura.IdFactura)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(idfactura))
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

        // DELETE: api/Facturas/5
        [HttpDelete("{idfactura}")]
        public async Task<IActionResult> DeleteFactura(int idfactura)
        {
            var factura = await _context.Facturas.FindAsync(idfactura);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturaExists(int idfactura)
        {
            return _context.Facturas.Any(e => e.IdFactura == idfactura);
        }
    }
}
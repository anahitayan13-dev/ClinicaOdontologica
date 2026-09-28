using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class FacturasController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<Factura>.GetAll());
        }

        public IActionResult Details(int? idfactura)
        {
            if (idfactura == null) return NotFound();
            var factura = CRUD<Factura>.GetById(idfactura.Value);
            if (factura == null) return NotFound();
            return View(factura);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Factura factura)
        {
            try
            {
                CRUD<Factura>.Create(factura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(factura);
            }
        }

        public IActionResult Edit(int? idfactura)
        {
            if (idfactura == null) return NotFound();
            var factura = CRUD<Factura>.GetById(idfactura.Value);
            if (factura == null) return NotFound();
            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idfactura, Factura factura)
        {
            if (idfactura != factura.IdFactura) return NotFound();
            try
            {
                CRUD<Factura>.Update(idfactura, factura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(factura);
            }
        }

        public IActionResult Delete(int? idfactura)
        {
            if (idfactura == null) return NotFound();
            var factura = CRUD<Factura>.GetById(idfactura.Value);
            if (factura == null) return NotFound();
            return View(factura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idfactura)
        {
            CRUD<Factura>.Delete(idfactura);
            return RedirectToAction(nameof(Index));
        }
    }
}

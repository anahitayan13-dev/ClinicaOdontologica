using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class DetallesCitasController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<DetalleCita>.GetAll());
        }

        public IActionResult Details(int? iddetallecita)
        {
            if (iddetallecita == null) return NotFound();
            var detalle = CRUD<DetalleCita>.GetById(iddetallecita.Value);
            if (detalle == null) return NotFound();
            return View(detalle);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DetalleCita detalle)
        {
            try
            {
                CRUD<DetalleCita>.Create(detalle);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(detalle);
            }
        }

        public IActionResult Edit(int? iddetallecita)
        {
            if (iddetallecita == null) return NotFound();
            var detalle = CRUD<DetalleCita>.GetById(iddetallecita.Value);
            if (detalle == null) return NotFound();
            return View(detalle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int iddetallecita, DetalleCita detalle)
        {
            if (iddetallecita != detalle.IdDetalleCita) return NotFound();
            try
            {
                CRUD<DetalleCita>.Update(iddetallecita, detalle);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(detalle);
            }
        }

        public IActionResult Delete(int? iddetallecita)
        {
            if (iddetallecita == null) return NotFound();
            var detalle = CRUD<DetalleCita>.GetById(iddetallecita.Value);
            if (detalle == null) return NotFound();
            return View(detalle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int iddetallecita)
        {
            CRUD<DetalleCita>.Delete(iddetallecita);
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class HistorialMedicosController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<HistorialMedico>.GetAll());
        }

        public IActionResult Details(int? idhistorial)
        {
            if (idhistorial == null) return NotFound();
            var historial = CRUD<HistorialMedico>.GetById(idhistorial.Value);
            if (historial == null) return NotFound();
            return View(historial);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HistorialMedico historial)
        {
            try
            {
                CRUD<HistorialMedico>.Create(historial);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(historial);
            }
        }

        public IActionResult Edit(int? idhistorial)
        {
            if (idhistorial == null) return NotFound();
            var historial = CRUD<HistorialMedico>.GetById(idhistorial.Value);
            if (historial == null) return NotFound();
            return View(historial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idhistorial, HistorialMedico historial)
        {
            if (idhistorial != historial.IdHistorialMedico) return NotFound();
            try
            {
                CRUD<HistorialMedico>.Update(idhistorial, historial);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(historial);
            }
        }

        public IActionResult Delete(int? idhistorial)
        {
            if (idhistorial == null) return NotFound();
            var historial = CRUD<HistorialMedico>.GetById(idhistorial.Value);
            if (historial == null) return NotFound();
            return View(historial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idhistorial)
        {
            CRUD<HistorialMedico>.Delete(idhistorial);
            return RedirectToAction(nameof(Index));
        }
    }
}

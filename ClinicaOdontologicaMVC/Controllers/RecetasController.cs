using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class RecetasController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<Receta>.GetAll());
        }

        public IActionResult Details(int? idreceta)
        {
            if (idreceta == null) return NotFound();
            var receta = CRUD<Receta>.GetById(idreceta.Value);
            if (receta == null) return NotFound();
            return View(receta);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Receta receta)
        {
            try
            {
                CRUD<Receta>.Create(receta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(receta);
            }
        }

        public IActionResult Edit(int? idreceta)
        {
            if (idreceta == null) return NotFound();
            var receta = CRUD<Receta>.GetById(idreceta.Value);
            if (receta == null) return NotFound();
            return View(receta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idreceta, Receta receta)
        {
            if (idreceta != receta.IdReceta) return NotFound();
            try
            {
                CRUD<Receta>.Update(idreceta, receta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(receta);
            }
        }

        public IActionResult Delete(int? idreceta)
        {
            if (idreceta == null) return NotFound();
            var receta = CRUD<Receta>.GetById(idreceta.Value);
            if (receta == null) return NotFound();
            return View(receta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idreceta)
        {
            CRUD<Receta>.Delete(idreceta);
            return RedirectToAction(nameof(Index));
        }
    }
}

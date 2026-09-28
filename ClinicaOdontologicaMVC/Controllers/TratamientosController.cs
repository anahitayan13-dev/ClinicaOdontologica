using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class TratamientosController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<Tratamiento>.GetAll());
        }

        public IActionResult Details(int? idtratamiento)
        {
            if (idtratamiento == null) return NotFound();
            var tratamiento = CRUD<Tratamiento>.GetById(idtratamiento.Value);
            if (tratamiento == null) return NotFound();
            return View(tratamiento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tratamiento tratamiento)
        {
            try
            {
                CRUD<Tratamiento>.Create(tratamiento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(tratamiento);
            }
        }

        public IActionResult Edit(int? idtratamiento)
        {
            if (idtratamiento == null) return NotFound();
            var tratamiento = CRUD<Tratamiento>.GetById(idtratamiento.Value);
            if (tratamiento == null) return NotFound();
            return View(tratamiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idtratamiento, Tratamiento tratamiento)
        {
            if (idtratamiento != tratamiento.IdTratamiento) return NotFound();
            try
            {
                CRUD<Tratamiento>.Update(idtratamiento, tratamiento);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(tratamiento);
            }
        }

        public IActionResult Delete(int? idtratamiento)
        {
            if (idtratamiento == null) return NotFound();
            var tratamiento = CRUD<Tratamiento>.GetById(idtratamiento.Value);
            if (tratamiento == null) return NotFound();
            return View(tratamiento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idtratamiento)
        {
            CRUD<Tratamiento>.Delete(idtratamiento);
            return RedirectToAction(nameof(Index));
        }
    }
}

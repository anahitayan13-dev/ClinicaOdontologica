using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class EspecialidadesController : Controller
    {
        // GET: Especialidades
        public IActionResult Index()
        {
            return View(CRUD<Especialidad>.GetAll());
        }

        // GET: Especialidades/Details/5
        public IActionResult Details(int? idespecialidad)
        {
            if (idespecialidad == null) return NotFound();

            var especialidad = CRUD<Especialidad>.GetById(idespecialidad.Value);
            if (especialidad == null) return NotFound();

            return View(especialidad);
        }

        // GET: Especialidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Especialidad especialidad)
        {
            try
            {
                CRUD<Especialidad>.Create(especialidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(especialidad);
            }
        }

        // GET: Especialidades/Edit/5
        public IActionResult Edit(int? idespecialidad)
        {
            if (idespecialidad == null) return NotFound();

            var especialidad = CRUD<Especialidad>.GetById(idespecialidad.Value);
            if (especialidad == null) return NotFound();

            return View(especialidad);
        }

        // POST: Especialidades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idespecialidad, Especialidad especialidad)
        {
            if (idespecialidad != especialidad.IdEspecialidad) return NotFound();

            try
            {
                CRUD<Especialidad>.Update(idespecialidad, especialidad);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(especialidad);
            }
        }

        // GET: Especialidades/Delete/5
        public IActionResult Delete(int? idespecialidad)
        {
            if (idespecialidad == null) return NotFound();

            var especialidad = CRUD<Especialidad>.GetById(idespecialidad.Value);
            if (especialidad == null) return NotFound();

            return View(especialidad);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idespecialidad)
        {
            CRUD<Especialidad>.Delete(idespecialidad);
            return RedirectToAction(nameof(Index));
        }
    }
}

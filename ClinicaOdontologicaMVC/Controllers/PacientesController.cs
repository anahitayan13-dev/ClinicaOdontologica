using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<Paciente>.GetAll());
        }

        public IActionResult Details(int? idpaciente)
        {
            if (idpaciente == null) return NotFound();
            var paciente = CRUD<Paciente>.GetById(idpaciente.Value);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Paciente paciente)
        {
            try
            {
                CRUD<Paciente>.Create(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paciente);
            }
        }

        public IActionResult Edit(int? idpaciente)
        {
            if (idpaciente == null) return NotFound();
            var paciente = CRUD<Paciente>.GetById(idpaciente.Value);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idpaciente, Paciente paciente)
        {
            if (idpaciente != paciente.IdPaciente) return NotFound();
            try
            {
                CRUD<Paciente>.Update(idpaciente, paciente);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(paciente);
            }
        }

        public IActionResult Delete(int? idpaciente)
        {
            if (idpaciente == null) return NotFound();
            var paciente = CRUD<Paciente>.GetById(idpaciente.Value);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idpaciente)
        {
            CRUD<Paciente>.Delete(idpaciente);
            return RedirectToAction(nameof(Index));
        }
    }
}

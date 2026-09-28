using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;

namespace ClinicaOdontologicaMVC.Controllers
{
    public class OdontologosController : Controller
    {
        public IActionResult Index()
        {
            return View(CRUD<Odontologo>.GetAll());
        }

        public IActionResult Details(int? idodontologo)
        {
            if (idodontologo == null) return NotFound();
            var odontologo = CRUD<Odontologo>.GetById(idodontologo.Value);
            if (odontologo == null) return NotFound();
            return View(odontologo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Odontologo odontologo)
        {
            try
            {
                CRUD<Odontologo>.Create(odontologo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(odontologo);
            }
        }

        public IActionResult Edit(int? idodontologo)
        {
            if (idodontologo == null) return NotFound();
            var odontologo = CRUD<Odontologo>.GetById(idodontologo.Value);
            if (odontologo == null) return NotFound();
            return View(odontologo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int idodontologo, Odontologo odontologo)
        {
            if (idodontologo != odontologo.IdOdontologo) return NotFound();
            try
            {
                CRUD<Odontologo>.Update(idodontologo, odontologo);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(odontologo);
            }
        }

        public IActionResult Delete(int? idodontologo)
        {
            if (idodontologo == null) return NotFound();
            var odontologo = CRUD<Odontologo>.GetById(idodontologo.Value);
            if (odontologo == null) return NotFound();
            return View(odontologo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int idodontologo)
        {
            CRUD<Odontologo>.Delete(idodontologo);
            return RedirectToAction(nameof(Index));
        }
    }
}

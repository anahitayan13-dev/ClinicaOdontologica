```csharp
using Microsoft.AspNetCore.Mvc;
using ClinicaOdontologicaModelos;
using ClinicaOdontologica.Consumer;
using System;

namespace ClinicaOdontologica.MVC.Controllers
{
    public class ConsultoriosController : Controller
    {
        // Constructor para inicializar la URL del servicio
        public ConsultoriosController()
        {
            CRUD<Consultorio>.Endpoint = "https://localhost:7056/api/Consultorios";
        }

        // GET: CONSULTORIOS
        public ActionResult Index()
        {
            var consultorios = CRUD<Consultorio>.GetAll();
            return View(consultorios);
        }

        // GET: CONSULTORIOS/Details/5
        public ActionResult Details(int idconsultorio)
        {
            var consultorio = CRUD<Consultorio>.GetById(idconsultorio);

            if (consultorio == null)
            {
                return NotFound();
            }
            else
            {
                return View(consultorio);
            }
        }

        // GET: CONSULTORIOS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CONSULTORIOS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Consultorio consultorio)
        {
            try
            {
                CRUD<Consultorio>.Create(consultorio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(consultorio);
            }
        }

        // GET: CONSULTORIOS/Edit/5
        public ActionResult Edit(int idconsultorio)
        {
            var consultorio = CRUD<Consultorio>.GetById(idconsultorio);

            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // POST: CONSULTORIOS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idconsultorio, Consultorio consultorio)
        {
            try
            {
                CRUD<Consultorio>.Update(idconsultorio, consultorio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(consultorio);
            }
        }

        // GET: CONSULTORIOS/Delete/5
        public ActionResult Delete(int idconsultorio)
        {
            var consultorio = CRUD<Consultorio>.GetById(idconsultorio);

            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // POST: CONSULTORIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idconsultorio)
        {
            try
            {
                CRUD<Consultorio>.Delete(idconsultorio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}


using ClinicaOdontologica.Consumer;
using ClinicaOdontologicaModelos; // O el namespace donde tengas la clase Cita
using ClinicaOdontologicaModelos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClinicaOdontologica.MVC.Controllers
{
    public class CitasController : Controller
    {
        // Constructor o bloque estático para inicializar la URL del servicio
        public CitasController()
        {
            CRUD<Cita>.Endpoint = "https://localhost:7056/api/Citas";
        }

        // GET: CITAS
        public ActionResult Index()
        {
            var citas = CRUD<Cita>.GetAll();
            return View(citas);
        }

        // GET: CITAS/Details/5
        public ActionResult Details(int idcita)
        {
            var cita = CRUD<Cita>.GetById(idcita);
            if (cita == null)
            {
                return NotFound();
            }
            else
            {
                return View(cita);
            }
        }

        // GET: CITAS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CITAS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cita cita)
        {
            try
            {
                CRUD<Cita>.Create(cita);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cita);
            }
        }

        // GET: CITAS/Edit/5
        public ActionResult Edit(int idcita)
        {
            var cita = CRUD<Cita>.GetById(idcita);
            if (cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }

        // POST: CITAS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int idcita, Cita cita)
        {
            try
            {
                CRUD<Cita>.Update(idcita, cita);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cita);
            }
        }

        // GET: CITAS/Delete/5
        public ActionResult Delete(int idcita)
        {
            var cita = CRUD<Cita>.GetById(idcita);
            if (cita == null)
            {
                return NotFound();
            }
            return View(cita);
        }

        // POST: CITAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idcita)
        {
            try
            {
                CRUD<Cita>.Delete(idcita);
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
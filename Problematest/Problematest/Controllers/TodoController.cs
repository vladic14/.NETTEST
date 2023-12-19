namespace Problematest.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Problematest.Models;
    using System;
    using System.Collections.Generic;

    public class TodoController : Controller
    {
        private static List<TodoItem> listaSarcini = new List<TodoItem>();

        public IActionResult Index()
        {
            return View(listaSarcini);
        }

        public IActionResult Adauga()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adauga(TodoItem sarcina)
        {
            sarcina.Id = listaSarcini.Count + 1;
            listaSarcini.Add(sarcina);
            return RedirectToAction("Index");
        }

        public IActionResult Editeaza(int id)
        {
            var sarcina = listaSarcini.Find(item => item.Id == id);
            if (sarcina == null)
            {
                return NotFound();
            }
            return View(sarcina);
        }

        [HttpPost]
        public IActionResult Editeaza(TodoItem sarcina)
        {
            var existent = listaSarcini.FindIndex(item => item.Id == sarcina.Id);
            if (existent != -1)
            {
                listaSarcini[existent] = sarcina;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Sterge(int id)
        {
            var sarcina = listaSarcini.Find(item => item.Id == id);
            if (sarcina == null)
            {
                return NotFound();
            }
            return View(sarcina);
        }

        [HttpPost]
        public IActionResult StergeConfirmare(int id)
        {
            var sarcina = listaSarcini.Find(item => item.Id == id);
            if (sarcina != null)
            {
                listaSarcini.Remove(sarcina);
            }
            return RedirectToAction("Index");
        }
    }

}

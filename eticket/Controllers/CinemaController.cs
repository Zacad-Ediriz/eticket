using Eticket.Data;
using Eticket.Models;
using Eticket.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Controllers
{
    [Authorize]
    public class CinemaController : Controller
    {

        public IActionResult Index()
        {
            var repo = new CinemaRepo();
            var data = repo.getAll();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Cinema model)
        {
            var repo = new CinemaRepo();
            repo.create(model.logo, model.Name, model.Description);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var repo = new CinemaRepo();
            Cinema found = repo.get_by_id(id);
            return View(found);

        }

        [HttpPost]
        public IActionResult Edit(Cinema model)
        {
            var repo = new CinemaRepo();
            repo.update(model.Id, model.Name, model.logo, model.Description);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var repo = new CinemaRepo();
            Cinema found = repo.get_by_id(id);
            return View(found);

        }

        [HttpPost]
        public IActionResult Delete(Cinema model)
        {
            var repo = new CinemaRepo();
            repo.delete(model.Id);
            return RedirectToAction("Index");
        }

    }
}

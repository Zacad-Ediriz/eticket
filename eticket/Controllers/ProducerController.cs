using Eticket.Data;
using Eticket.Models;
using Eticket.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Controllers
{
    [Authorize]
    public class ProducerController : Controller
    {

        public IActionResult Index()
        {
            var repo = new ProducerRepo();
            var data = repo.getAll();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Producer model)
        {
            var repo = new ProducerRepo();
            repo.create(model.ProfilePictureUrl, model.Fullname, model.Bio);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            var repo = new ProducerRepo();
            Producer found = repo.get_by_id(id);
            return View(found);

        }

        [HttpPost]
        public IActionResult Edit(Producer model)
        {
            var repo = new ProducerRepo();
            repo.update(model.Id, model.ProfilePictureUrl, model.Fullname, model.Bio);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var repo = new ProducerRepo();
            Producer found = repo.get_by_id(id);
            return View(found);

        }

        [HttpPost]
        public IActionResult Delete(Producer model)
        {
            var repo = new ProducerRepo();
            repo.delete(model.Id);
            return RedirectToAction("Index");
        }

    }
}

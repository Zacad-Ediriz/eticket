using Eticket.Data;
using Eticket.Models;
using Eticket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticket.Controllers
{

    [Authorize]
    public class ActorController : Controller
    {

        public readonly IActorServices _Services;
        private object _service;

        public ActorController(IActorServices services)
        {
            _Services = services;
        }
        public async Task<IActionResult> Actors()
        {
            var allactor = await _Services.GetAll();
            return View(allactor);
        }
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Fullname,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Services.AddAsync(actor);
            return RedirectToAction(nameof(Actors));
        }

        //Get: Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _Services.Bygetid(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _Services.Bygetid(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Fullname,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _Services.UpdateAsync(id ,actor);
            return RedirectToAction(nameof(Actors));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _Services.Bygetid(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _Services.Bygetid(id);
            if (actorDetails == null) return View("NotFound");

            await _Services.DeleteAsync(id);
            return RedirectToAction(nameof(Actors));
        }



    }
}

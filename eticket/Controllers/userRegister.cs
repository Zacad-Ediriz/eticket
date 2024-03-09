using Eticket.Models;
using Eticket.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eticket.Controllers
{
    public class userRegister : Controller
    {
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create(Registeruser model)
        {
            var repo = new userRegisterRepo();
            repo.create(model.Username, model.Password, model.ConfirmPassword);
            return RedirectToAction("Login" , "accounts");

        }


    }
}

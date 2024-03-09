using Eticket.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace Eticket.Controllers
{
    public class accountsController : Controller
    {
        public IActionResult Login()
        {
            ViewData["error"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult Login(userlogin model)
        {
            //find the user credentials from db
            string connString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ECommerce_Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(connString))
            {
                con.Open();
                string stmt = $"select count(*) total from login where username='{model.username}' and password='{model.password}'";
                SqlCommand cmd = new SqlCommand(stmt, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    //user is valid
                    HttpContext.Session.SetString("username", model.username);

                    //create authentication cookie
                    var claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier,model.username),
                    new Claim(ClaimTypes.Role,"Admin")

                    }.ToArray();

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var princible = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, princible);

                    return RedirectToAction("Movie", "Movie");
                }
                else
                {
                    ViewData["error"] = "Correct your Username and Password ";
                    //user is invalid
                    return View(model);
                }

            }


        }

        public IActionResult logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }


}


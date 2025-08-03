using CarDealerProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CarDealerProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        // Hardcoded credentials (as per test task)
        private const string AdminUsername = "admin";
        private const string AdminPassword = "password123";

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Admin/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                HttpContext.Session.SetString("IsAdmin", "true");
                return RedirectToAction("Dashboard");
            }

            ViewData["Error"] = "Invalid username or password";
            return View();
        }

        // GET: /Admin/Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("IsAdmin") != "true")
                return RedirectToAction("Login");

            return View();
        }

        // GET: /Admin/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("IsAdmin");
            return RedirectToAction("Login");
        }
    }
}

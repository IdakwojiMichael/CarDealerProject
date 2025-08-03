using CarDealerProject.Data;
using CarDealerProject.Data.Models;
using CarDealerProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealerProject.Controllers
{
    public class InquiryController : Controller
    {
        private readonly AppDbContext _context;

        public InquiryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(InquiryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inquiry = new Inquiry
                {
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    CarId = model.CarId
                };

                _context.Inquiries.Add(inquiry);
                await _context.SaveChangesAsync();

                return RedirectToAction("ThankYou");
            }

            return View(model);
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        // ✅ View all inquiries (for Admin)
        public async Task<IActionResult> Index()
        {
            var inquiries = await _context.Inquiries
                .Include(i => i.Car)
                .ToListAsync();

            return View(inquiries);
        }
    }
}



//######### 21st Jan code ################
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarly.DAL;
using Scholarly.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Scholarly.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> StudentDashboard()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Login"); // Redirect to login if not authenticated
            }

            var user = await _context.user
                .Where(u => u.Username == User.Identity.Name)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return RedirectToAction("Index", "Login"); // Redirect to login if user doesn't exist
            }

            var student = await _context.student
                .Where(s => s.Name == user.Username)
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return RedirectToAction("Index", "Login"); // Redirect if student not found
            }

            var enrollments = await _context.Enrollments
                .Where(e => e.StudentId == student.Id)
                .Include(e => e.Courses)
                .Include(e => e.Attendance)
                .ToListAsync();

            var model = new StudentDashboardViewModel(student);
            return View(model);
        }




        public IActionResult Error()
        {
            return View();
        }
    }
}


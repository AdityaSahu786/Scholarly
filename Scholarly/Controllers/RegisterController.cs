using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarly.DAL;
using Scholarly.Models;

public class RegisterController : Controller
{
    private readonly DatabaseContext _context;
    private readonly IPasswordHasher<user> _passwordHasher;

    public RegisterController(DatabaseContext context, IPasswordHasher<user> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    // GET: Register
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // POST: Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(RegisterViewModel model) // Use RegisterViewModel here
    {
        if (ModelState.IsValid)
        {
            // Check if the username or email already exists
            var existingUser = await _context.user
                .FirstOrDefaultAsync(u => u.Username == model.Username || u.Email == model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Username or Email already in use.");
                return View("~/Views/Login/Index.cshtml");  //if user already exists, redirect to login page
            }

            // Hash the password before storing it
            var hashedPassword = _passwordHasher.HashPassword(null, model.Password);

            // Create a new user object
            var user = new user
            {
                Username = model.Username,
                Email = model.Email,
                PasswordHash = hashedPassword,
                Roles = model.Roles // Example: 'Student' or 'Teacher'
            };

            _context.user.Add(user); // Add user to the database
            await _context.SaveChangesAsync();

            // Create related profile based on role
            if (model.Roles == "Student")
            {
                var student = new Students
                {
                    Name = model.Username,
                    Year = 1, // Default value
                    Email = model.Email,
                    UserId = user.Id
                };
                _context.student.Add(student);
            }
            else if (model.Roles == "Teacher")
            {
                var teacher = new Teachers
                {
                    Name = model.Username,
                    UserId = user.Id
                };
                _context.Teacher.Add(teacher);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Login");   // Redirect to home page after successful registration
        }

        return View(model);
    }
}



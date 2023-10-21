using MannariEnterprises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;

public class AccountController : Controller
{
    private readonly AppDbContext _dbContext;
    private readonly IAuthenticationService _authService;
    public AccountController(AppDbContext dbContext, IAuthenticationService authService )
    {
        _dbContext= dbContext;
        _authService=authService;
    }

    [HttpGet]
    public IActionResult Login()
    {   
        ViewData["IsLoginPage"] = true;
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(StudentLogin studentLogin)
    {   
        var model = new StudentLogin();

        // if (ModelState.IsValid)
        // {
            if (_authService.AuthenticateUser(studentLogin.username, studentLogin.password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, studentLogin.username)
                    // Additional claims...
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                HttpContext.Session.SetString("Username", studentLogin.username);

                // Redirect to the main page or a designated protected resource
                 return RedirectToAction("Index", "Product");
            }
            else
            {
                // Invalid credentials, return the login view with an error message
                ModelState.AddModelError("", "Invalid username or password.");
            }
        // }
        return View();
    }


    [HttpGet]
    public IActionResult Register()
    {
        var model = new StudentLogin();
        ViewData["IsLoginPage"] = true;
        return View(model);
    }
    [HttpPost]
    public IActionResult Register(StudentLogin studentLogin)
    {
        if (!ModelState.IsValid)
        {
            // Handle validation errors and display error messages
            return View(studentLogin);
        }
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        //string hashPass = null;
        //if(studentLogin.password!=null && hashPass!=null){

        string hashPass= BCrypt.Net.BCrypt.HashPassword(studentLogin?.password,salt);
        studentLogin.password = hashPass;
        //studentLogin.role="Customer";
        //}
        //studentLogin.salt= salt
        // Process the registration logic, such as creating a new user in the database
        // Assuming you have an instance of your DbContext called "_dbContext"
        _dbContext.Logins.Add(studentLogin);
        _dbContext.SaveChanges();

        // Redirect to a success page or login page
        return RedirectToAction("Login");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        // Perform logout logic here
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        
        // Redirect to the desired page after logout
        return RedirectToAction("Login", "Account");
    }
}

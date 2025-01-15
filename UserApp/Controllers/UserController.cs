using System.Diagnostics;
using Data;
using Microsoft.AspNetCore.Mvc;
using UserApp.Models;
using Microsoft.EntityFrameworkCore;

namespace UserApp.Controllers;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger,  ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Users()
    {
        var users = await _context.Users.ToListAsync();
        return View(users);
    }

    public async Task<IActionResult> UserDetails(int id)
    {
        var user = await _context.Users.Include(user => user.UserProfile).FirstOrDefaultAsync(user => user.Id == id);
        Console.WriteLine(user);
        if (user == null){
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            return View(user);
        }
         return NotFound();
    }

    public async Task<IActionResult> SearchUsers(string keyword)
    {
        var users = await _context.Users.Include(user => user.UserProfile)
                                  .Where(user => user.UserProfile.Biography.Contains(keyword))
                                  .ToListAsync();
         if (users == null){
            return NotFound();
        }
        return View(users);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
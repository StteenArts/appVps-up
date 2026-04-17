using Microsoft.AspNetCore.Mvc;
using appVps_up.Data;
using appVps_up.Models;

namespace appVps_up.Controllers;

public class UserController : Controller
{
    private readonly MysqlDbContext _context;

    public UserController(MysqlDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.users.ToList();// Select * from users
        return View(users);
    }

    public IActionResult Create()
    {
        
        return View();
    }

    public IActionResult Show(int id)
    {
        var user = _context.users.Find(id);
        return View(user);
    }

    public IActionResult Edit(int id)
    {
        var user = _context.users.Find(id);
        return View(user);
    }
    [HttpPost]
    public IActionResult Update(User user)
    {
        var userDb = _context.users.Find(user.Id);
        userDb.Name = user.Name;
        userDb.Email = user.Email;
        userDb.Password = user.Password;
        _context.SaveChanges();
        
        return RedirectToAction("Index");

    }
    [HttpPost]
    public IActionResult Destroy(int id)
    {
        var user = _context.users.Find(id);
        _context.Remove(user);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
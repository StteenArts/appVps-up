using appVps_up.Data;
using appVps_up.Models;
using Microsoft.AspNetCore.Mvc;

namespace appVps_up.Controllers;

public class EventController : Controller
{
    private readonly MysqlDbContext _context;

    public EventController(MysqlDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var events = _context.events.ToList();
        return View(events);
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Events newEvents)
    {
        var eventUpdate = _context.events.Find(id);
        eventUpdate.Name = newEvents.Name;
        eventUpdate.Date = newEvents.Date;
        eventUpdate.Status = newEvents.Status;
        _context.events.Update(eventUpdate);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var eventDelete = _context.events.Find(id);
        _context.events.Remove(eventDelete);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Store(Events events)
    {
        _context.events.Add(events);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class PeopleController : Controller
{
  private readonly AppDbContext _context;

  public PeopleController(AppDbContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    var people = _context.People.ToList();
    return View(people);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(PersonModel person)
  {
    _context.People.Add(person);
    _context.SaveChanges();
    return RedirectToAction("Index");
  }

  public IActionResult Edit(int id)
  {
    var person = _context.People.Find(id);
    return View(person);
  }

  [HttpPost]
  public IActionResult Edit(PersonModel person)
  {
    _context.Entry(person).State = EntityState.Modified;
    _context.SaveChanges();
    return RedirectToAction("Index");
  }

  public IActionResult Delete(int id)
  {
    var person = _context.People.Find(id);
    return View(person);
  }

  [HttpPost, ActionName("Delete")]
  public IActionResult DeleteConfirmed(int id)
  {
    var person = _context.People.Find(id);
    _context.People.Remove(person);
    _context.SaveChanges();
    return RedirectToAction("Index");
  }
}

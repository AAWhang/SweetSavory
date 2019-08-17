using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SweetSavory.Controllers
{
  public class FlavorsController : Controller
  {
    private readonly SweetSavoryContext _db;

    public FlavorsController(SweetSavoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavors> model = _db.Flavors.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Flavors Flavors)
    {
      _db.Flavors.Add(Flavors);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisFlavors = _db.Flavors
          .Include(Flavors => Flavors.Treats)
          .ThenInclude(join => join.Treat)
          .FirstOrDefault(Flavors => Flavors.FlavorsId == id);
      return View(thisFlavors);
    }

    public ActionResult Edit(int id)
    {
      var thisFlavors = _db.Flavors.FirstOrDefault(Flavors => Flavors.FlavorsId == id);
      return View(thisFlavors);
    }

    [HttpPost]
    public ActionResult Edit(Flavors Flavors)
    {
      _db.Entry(Flavors).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisFlavors = _db.Flavors.FirstOrDefault(Flavors => Flavors.FlavorsId == id);
      return View(thisFlavors);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisFlavors = _db.Flavors.FirstOrDefault(Flavors => Flavors.FlavorsId == id);
      _db.Flavors.Remove(thisFlavors);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

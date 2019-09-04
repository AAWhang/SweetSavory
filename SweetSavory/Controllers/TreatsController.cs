using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavory.Controllers
{
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly SweetSavoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, SweetSavoryContext database)
    {
      _userManager = userManager;
      _db = database;
    }

    public async Task<ActionResult> Index()
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        return View(_db.Treats.Where(x => x.User.Id == currentUser.Id));
    }

    public ActionResult Create()
    {
        ViewBag.FlavorsId = new SelectList(_db.Flavors, "FlavorsId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat Treat)
    {
        var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var currentUser = await _userManager.FindByIdAsync(userId);
        Treat.User = currentUser;
        _db.Treats.Add(Treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTreat = _db.Treats
          .Include(Treat => Treat.Flavors)
          .ThenInclude(join => join.Flavors)
          .FirstOrDefault(Treat => Treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(Treats => Treats.TreatId == id);
      ViewBag.FlavorsId = new SelectList(_db.Flavors, "FlavorsId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat Treat, int FlavorsId)
    {
      if (FlavorsId != 0)
      {
        _db.FlavorsTreat.Add(new FlavorsTreat() { FlavorsId = FlavorsId, TreatId = Treat.TreatId });
      }
      _db.Entry(Treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavors(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(Treats => Treats.TreatId == id);
      ViewBag.FlavorsId = new SelectList(_db.Flavors, "FlavorsId", "Name");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavors(Treat Treat, int FlavorsId)
    {
      if (FlavorsId != 0)
      {
        _db.FlavorsTreat.Add(new FlavorsTreat() { FlavorsId = FlavorsId, TreatId = Treat.TreatId });
        Treat.Flavors.Add(new FlavorsTreat() { FlavorsId = FlavorsId, TreatId = Treat.TreatId });

      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(Treats => Treats.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTreat = _db.Treats.FirstOrDefault(Treats => Treats.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteFlavors(int joinId)
    {
      var joinEntry = _db.FlavorsTreat.FirstOrDefault(entry => entry.FlavorsTreatId == joinId);
      _db.FlavorsTreat.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

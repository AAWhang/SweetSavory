using Microsoft.AspNetCore.Mvc;

namespace ECSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    } 
  }
}

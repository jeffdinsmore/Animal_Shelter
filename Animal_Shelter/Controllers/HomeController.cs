using Microsoft.AspNetCore.Mvc;

namespace Animal_Shelter.Controllers
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
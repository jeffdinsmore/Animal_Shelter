using Microsoft.AspNetCore.Mvc;
using Animal_Shelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Animal_Shelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly Animal_ShelterContext _db;
    public AnimalsController(Animal_ShelterContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      List<Animal> SortedList = model.OrderBy(o => o.Name).ToList();
      return View(SortedList);
    }
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }

    public ActionResult Search()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(string name)
    {
      List<Animal> model = _db.Animals.Where(x => x.Name.Contains(name)).ToList();
      List<Animal> SortedList = model.OrderBy(o => o.Name).ToList();
      return View("Index", SortedList);
    }

    public ActionResult Edit(int id)
    {
      var thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }

    [HttpPost]
    public ActionResult Edit(Animal animal)
    {
      _db.Entry(animal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

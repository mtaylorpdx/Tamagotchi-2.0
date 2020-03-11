using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

namespace Tamagotchi.Controllers
{
  public class PetsController : Controller
  {
    [HttpPost("/pets")]
    public ActionResult Create(string petName)
    {
      Place newPlace = new Place(petName);
      return RedirectToAction("Index");
    }

    [HttpGet("/pets")]
    public ActionResult Index()
    {
      List<Place> petsList = Place.GetAll();
      return View(petsList);
    }
    
    [HttpGet("/pets/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/pets/{id}")]
    public ActionResult Show(int id)
    {
      Place foundPlace = Place.Find(id);
      return View(foundPlace);
    }

    [HttpPost("/pets/delete")]
    public ActionResult DeleteAll()
    {
      Place.ClearAll();
      return View();
    }
  }
}
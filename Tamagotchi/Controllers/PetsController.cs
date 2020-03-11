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
      Pet newPet = new Pet(petName);
      return RedirectToAction("Index");
    }

    [HttpGet("/pets")]
    public ActionResult Index()
    {
      List<Pet> petsList = Pet.GetAll();
      Pet.PassTime();
      // foreach(Pet pet in petsList)
      // {
      //   pet.Food -= 1;
      // }
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
      Pet foundPet = Pet.Find(id);
      return View(foundPet);
    }

    [HttpPost("/pets/delete")]
    public ActionResult DeleteAll()
    {
      Pet.ClearAll();
      return View();
    }
  }
}
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

    [HttpPost("/feed/{id}")]
    public ActionResult Feed(int id)
    {
      Pet fedPet = Pet.Find(id);
      fedPet.ChangeFood(3);
      List<Pet> petsList = Pet.GetAll();
      foreach(Pet pet in petsList)
      {

        pet.ChangeAttention(-1);
        pet.ChangeRest(-2);
      }
    return RedirectToAction("Index");
    }

    [HttpPost("/play/{id}")]
    public ActionResult Play(int id)
    {
      Pet fedPet = Pet.Find(id);
      fedPet.ChangeAttention(3);
      List<Pet> petsList = Pet.GetAll();
      foreach(Pet pet in petsList)
      {
        pet.ChangeFood(-2);
        pet.ChangeRest(-2);
      }
    return RedirectToAction("Index");
    }

    [HttpPost("/sleep/{id}")]
    public ActionResult Sleep(int id)
    {
      Pet fedPet = Pet.Find(id);
      fedPet.ChangeRest(3);
      List<Pet> petsList = Pet.GetAll();
      foreach(Pet pet in petsList)
      {
        pet.ChangeFood(-1);
        pet.ChangeAttention(-1);
      }
    return RedirectToAction("Index");
    }
  }
}
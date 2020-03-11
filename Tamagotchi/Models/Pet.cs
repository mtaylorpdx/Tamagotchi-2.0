using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public string Name {get;set;}
    public int Food {get;set;} = 10;
    public int Attention {get;set;} = 10;
    public int Rest {get;set;} = 10;
    public int Id {get;}
    private static List<Pet> _instances = new List<Pet> {};

    public Pet(string name)
    {
      Name = name.ToUpper();
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Pet> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId-1];
    }

    // public static Pet PassTime(Pet petList)
    // {

    // }
  }
}
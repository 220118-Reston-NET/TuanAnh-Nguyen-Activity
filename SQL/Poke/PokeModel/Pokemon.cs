namespace PokeModel
{
  public class Pokemon
  {
    public string Name { get; set; }
    public int Level { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }

    //Full properties are required to do validation
    private List<Ability> _abilities;
    public List<Ability> Abilities
    {
      get { return _abilities; }
      set
      {
        //Cannot set abilities to have more than 4
        if (value.Count < 4)
        {
          _abilities = value;
        }
        else
        {
          throw new Exception("Pokemon cannot hold more than 4 abilities!");
        }
      }

    }


    //Default constructor to add default values to the properties
    public Pokemon()
    {
      Name = "Ditto";
      Level = 1;
      Attack = 55;
      Defense = 55;
      Health = 55;
      _abilities = new List<Ability>()
            {
                new Ability()
            };
    }

    //ToString() method is the string version of your object
    public override string ToString()
    {
      return $"Name: {Name}\nLevel: {Level}\nAttack: {Attack}\nDefense: {Defense}\nHealth: {Health}";
    }
  }
}
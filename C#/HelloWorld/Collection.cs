namespace CollectionFunction
{
  public class Collection
  {
    //Array
    //Used to store a datatype and have a fixed size
    //zero-based index
    //Syntax: (datatype)[] ()name of variable) = new (datatype)[(size of the array)];
    private int[] _nums = new int[5];

    //Generic Collection
    //They store a specific datatype and have variable size
    //Syntax: <(datatype)> 

    //List Collectipon
    //zero-based index
    //Used to store a datatype and has variable size
    private List<string> _strings = new List<string>();

    //Hashset Collection
    //There is no particular order to the elements so NOT zero-based index
    //You cannot have duplicate elements
    private HashSet<int> _numsCollection = new HashSet<int>();

    //Dictionary Collection
    //Stores information through key-value pairs
    //There is no particular order 
    private Dictionary<string, int> _directory = new Dictionary<string, int>();

    //Non-generic Collection
    //They store any datatype and have variable size

    public void CollectionMain()
    {
      Console.WriteLine("===Collection Demo===");

      _nums[0] = 3;
      _nums[1] = 10;
      _nums[2] = 4;

      //A way to go through a list
      //Foreach will iterate through all of the elements of a collection/array
      //Syntax: ( (datatype) (Name of variable) in (Name of array/collection) )
      Console.WriteLine("===Foreach Loop===");
      foreach (int num in _nums)
      {
        Console.WriteLine(num);
      }

      //For loop is for a more complex way to iterate through a collection
      Console.WriteLine("===For Loop===");
      for (int i = 0; i < _nums.Length; i++)
      {
        Console.WriteLine("Current value of i: " + i);
        Console.WriteLine(_nums[i]);
      }

      //
      Console.WriteLine("===Generic Collection===");
      Console.WriteLine("===List Demo===");
      _strings.Add("First element");
      _strings.Add("Second element");
      _strings.Add("Third element");
      _strings.Add("First element");

      foreach (string item in _strings)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine(_strings[1]);

      Console.WriteLine("===Hashset Demo===");
      _numsCollection.Add(1);
      _numsCollection.Add(2);
      _numsCollection.Add(3);
      _numsCollection.Add(1);

      foreach (var item in _numsCollection)
      {
        Console.WriteLine(item);
      }
      // Console.WriteLine(numsCollection[1]); -- Gives an exception due to hashset not being zero-based index

      Console.WriteLine("===Dictionary Demo===");
      _directory.Add("Alex", 1024);
      _directory.Add("Stephen", -1000);
      _directory.Add("Vijhan", 1000);

      //Dictionary uses key to look up information from its store
      Console.WriteLine(_directory["Stephen"]);
    }
  }
}
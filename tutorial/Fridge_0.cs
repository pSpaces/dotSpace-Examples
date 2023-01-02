using dotSpace.Interfaces.Space;
using dotSpace.Objects.Space;
using Tuple = dotSpace.Objects.Space.Tuple;

class Program
{
    static void Main(string[] args)
    {
        // Creating a tuple
        var tuple = new Tuple("milk", 1);
        Console.WriteLine("We just created tuple");
        Console.WriteLine(tuple);

        Console.WriteLine($"The fields of {tuple} are {tuple[0]} and {tuple[1]}");

        // Creating a space
        var fridge = new SequentialSpace();

        // Adding tuples
        fridge.Put("coffee", 1);
        fridge.Put("coffee", 1);
        fridge.Put("clean kitchen");
        fridge.Put("butter", 2);
        fridge.Put("milk", 3);

        // Looking for a tuple
        var obj1 = fridge.QueryP("clean kitchen");
        if (obj1 == null) throw new NullReferenceException("Clean kitchen not found");
        Console.WriteLine("We need to clean the kitchen");
        
        // Removing a tuple
        var obj2 = fridge.GetP("clean kitchen");
        if (obj2 == null) throw new NullReferenceException("Clean kitchen not found");
        Console.WriteLine("Cleaning...");

        // Looking for a tuple with pattern matching
        int numberOfBottles;
        var objs3 = fridge.QueryP(new Pattern("milk", typeof(int)));
        numberOfBottles = (int) objs3[1];

        // Updating a tuple
        if (objs3 != null && numberOfBottles <= 10)
        {
            Console.WriteLine("We plan to buy milk, but not enough...");
            var objs4 = fridge.GetP(new Pattern("milk", typeof(int)));
            numberOfBottles = (int)objs4[1];
            fridge.Put("milk", numberOfBottles + 1);
        }

        var groceryList = fridge.QueryAll(new Pattern(typeof(string), typeof(int)));
        Console.WriteLine("Items to buy: ");
        foreach (var obj in groceryList) Console.WriteLine(obj.ToString());
    }
}

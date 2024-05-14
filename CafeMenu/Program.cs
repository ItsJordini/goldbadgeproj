namespace CafeMenu

    class Program
{
    static void Main(string[] args)
    {
        // Instantiate MenuItemRepository
        var repository = new MenuItemRepository();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Welcome to the Cafe Menu Management System!");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. View All Menu Items");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        AddMenuItem(repository);
                        break;
                    case 2:
                        ViewAllMenuItems(repository);
                        break;
                    case 3:
                        isRunning = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    static void AddMenuItem(MenuItemRepository repository)
    {
        Console.WriteLine("Adding a new menu item:");
        Console.Write("Enter meal number: ");
        int mealNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter meal name: ");
        string mealName = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter ingredients (comma-separated): ");
        string[] ingredients = Console.ReadLine().Split(',');
        Console.Write("Enter price: ");
        decimal price = decimal.Parse(Console.ReadLine());

        MenuItem newItem = new MenuItem
        {
            MealNumber = mealNumber,
            MealName = mealName,
            Description = description,
            Ingredients = ingredients,
            Price = price
        };

        repository.AddMenuItem(newItem);
        Console.WriteLine("Menu item added successfully!");
    }

    static void ViewAllMenuItems(MenuItemRepository repository)
    {
        Console.WriteLine("All Menu Items:");
        var menuItems = repository.GetAllMenuItems();

        foreach (var item in menuItems)
        {
            Console.WriteLine($"Meal Number: {item.MealNumber}");
            Console.WriteLine($"Meal Name: {item.MealName}");
            Console.WriteLine($"Description: {item.Description}");
            Console.WriteLine($"Ingredients: {string.Join(", ", item.Ingredients)}");
            Console.WriteLine($"Price: {item.Price:C}");
            Console.WriteLine();
        }
    }
}

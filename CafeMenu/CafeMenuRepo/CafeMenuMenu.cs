namespace CafeMenuRepo;

public class MenuItem
{
    public int MealNumber { get; set; }
    public string MealName { get; set; }
    public string Description { get; set; }
    public List<string> Ingredients { get; set; }
    public decimal Price { get; set; }

    // Constructor(s) if needed Still not sure if needed 5/11
    public MenuItem(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
    {
        MealNumber = mealNumber;
        MealName = mealName;
        Description = description;
        Ingredients = ingredients;
        Price = price;
    }

    //Additional constructor 
    public MenuItem()
    {
        //Lets Init Ingredients list 
        Ingredients = new List<string>();
    }
}

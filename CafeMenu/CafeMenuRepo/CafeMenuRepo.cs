namespace CafeMenuRepo;

public class MenuItemRepository
{
    private readonly List<MenuItem> _menuItems = new List<MenuItem>();

    public void AddMenuItem(MenuItem item)
    {
        // Add new menu item to the list
        _menuItems.Add(item);
    }

    public bool UpdateMenuItem(int mealNumber, MenuItem newItem)
    {
        // Update existing menu item with the given meal number
        MenuItem existingItem = _menuItems.Find(item => item.MealNumber == mealNumber);
        if (existingItem != null)
        {
            // Update the item
            existingItem.MealName = newItem.MealName;
            existingItem.Description = newItem.Description;
            existingItem.Ingredients = newItem.Ingredients;
            existingItem.Price = newItem.Price;
            return true; // Return true indicating success
        }
        else
        {
            return false; // Return false indicating failure
        }
    }

    public bool RemoveMenuItem(int mealNumber)
    {
        // Remove menu item with the given meal number
        MenuItem existingItem = _menuItems.Find(item => item.MealNumber == mealNumber);
        if (existingItem != null)
        {
            _menuItems.Remove(existingItem);
            return true; // Return true indicating success
        }
        else
        {
            return false; // Return false indicating failure
        }
    }

    public List<MenuItem> GetAllMenuItems()
    {
        // Retrieve all menu items from the list
        return _menuItems;
    }
}

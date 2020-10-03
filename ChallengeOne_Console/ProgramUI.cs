using ChallengeOne_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Console
{
    class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();
        //This method starts the UI part of the application
        public void Run()
        {
            SeedItemsToList();
            ProgramMenu();
        }

        ///UI Menu method called ProgramMenu to avoid confusion with other Menu related naming conventions already used
        private void ProgramMenu()
        {
            bool keepRunning = true; //as long as this is true the while loop (the program menu) will keep running
            while (keepRunning)
            {
                //Display the options to user
                Console.WriteLine("What would you like to do?\n" +
                    "1. Create a menu item.\n" +
                    "2. View the entire menu.\n" +
                    "3. View menu items by item number.\n" +
                    "4. Delete a menu item.\n" +
                    "5. Exit");
                //Get the user's input
                string userInput = Console.ReadLine();
                //Evaluate the user's input and act accordingly
                switch (userInput) //switch evaulates the user input
                {
                    case "1":
                        //Create new menu item
                        CreateNewMenuItem();
                        break;
                    case "2":
                        //view all menu items
                        ViewMenuItems();
                        break;
                    case "3":
                        //view by menu item number
                        ViewMenuItemsByNumber();
                        break;
                    case "4":
                        //Delete menu item
                        DeleteMenuItems();
                        break;
                    case "5":
                        keepRunning = false; //this ends the while loop and exits the program
                        break;
                    default:
                        Console.WriteLine("Invalid Input\n" +
                            "Enter a number that corresponds with the task you wish to complete.");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey(); //Won't clear the program UI until a key is pressed.
                Console.Clear(); //Clears console after input is evaluated
            }
        }

        //Create new menu item
        private void CreateNewMenuItem()
        {
            MenuItem newMenuItem = new MenuItem(); //new menu item object

            //MealNumber
            Console.WriteLine("Enter the name of the menu item you would like to add: ");
            newMenuItem.ItemName = Console.ReadLine();

            //MealName
            Console.WriteLine("Enter the ID for the menu item: ");
            //The ID needs to be converted to a string
            string itemIdString = Console.ReadLine();   //Declares the user input as a string the will represent item ID
            newMenuItem.ItemID = int.Parse(itemIdString); //Parses the menu item to string

            //MealDescription
            Console.WriteLine("Enter the description for the menu item: ");
            newMenuItem.ItemDescription = Console.ReadLine();

            //MealIngredients
            List<string> userIngredients = new List<string>(); //creates the list for user ingredients. Reference this list when pulling up ingredients/
            Console.WriteLine("Enter the ingredients in this item: ");
            string ingredientInput = Console.ReadLine();
            userIngredients.Add(ingredientInput); //adds the user ingredients to a list
            while (ingredientInput != "")
            {
                Console.WriteLine("Enter another ingredient, or leave blank and press Enter to continue: ");
                ingredientInput = Console.ReadLine();
                userIngredients.Add(ingredientInput);
            }
             
                                      
            //MealPrice
            Console.WriteLine("Enter the price of this item: ");
            string itemPriceString = Console.ReadLine(); //Item price needs to be converted to string as well
            newMenuItem.ItemPrice = double.Parse(itemPriceString);
        }
        //view current menu items
        private void ViewMenuItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuRepo.GetMenuItems();
            foreach (MenuItem menuItem in listOfMenuItems)
            {
                Console.WriteLine($"ID: {menuItem.ItemID}\n" +
                    $"Name: {menuItem.ItemName}\n" +
                    $"Description: {menuItem.ItemDescription}\n" +
                    $"Ingredients: {menuItem.ItemIngredients}\n" +
                    $"Price: ${menuItem.ItemPrice}");
            }
        }
        //view menu items by menu number
        private void ViewMenuItemsByNumber()
        {
            Console.Clear(); 
            Console.WriteLine("Enter the ID to find the ingredients: ");
            int itemId = Convert.ToInt32(Console.ReadLine());

            MenuItem menuItem = _menuRepo.GetMenuItemsByNumber(itemId);

            if (itemId == menuItem.ItemID)
            {
                Console.WriteLine($"ID: {menuItem.ItemID}\n" +
                    $"Name: {menuItem.ItemName}\n" +
                    $"Ingredients: {menuItem.ItemIngredients}\n" +
                    $"Price: ${menuItem.ItemPrice}");
            }
            else
            {
                Console.WriteLine("No menu item with that ID.");
            }
        }

        //Delete menu items
        private void DeleteMenuItems()
        {
            ViewMenuItems();
            Console.WriteLine("Enter the ID of the item you want to delete: ");

            int input = Int32.Parse(Console.ReadLine());

            bool wasDeleted = _menuRepo.RemoveMenuItems(input);

            if (wasDeleted)
            {
                Console.WriteLine("The content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The content could not be deleted.");
            }
        }
        
        private void SeedItemsToList()
        {
            MenuItem iceLatte = new MenuItem(1, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            MenuItem iceLatte1 = new MenuItem(2, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            MenuItem iceLatte2 = new MenuItem(3, "Iced Latte", "This is a latte with ice.", "Coffee, Ice, Milk", 5.99);
            _menuRepo.AddMenuItems(iceLatte);
            _menuRepo.AddMenuItems(iceLatte1);
            _menuRepo.AddMenuItems(iceLatte2);
        }
    }
}

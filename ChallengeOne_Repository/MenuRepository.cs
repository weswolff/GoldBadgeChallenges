using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    public class MenuRepository
    {
        private List<MenuItem> _listOfMenuItems = new List<MenuItem>();

        //Create
        public void AddMenuItems(MenuItem menuItem) //menuItem refers to individual "meals" in the menu
        {
            _listOfMenuItems.Add(menuItem);
        }
        //Read
        public List<MenuItem> GetMenuItems()
        {
            return _listOfMenuItems;
        }
        //Delete
        public bool RemoveMenuItems(int menuNumber) //bool for process to verify menu item was deleted
        {
            MenuItem menuItem = GetMenuItemsByNumber(menuNumber); //Call the method that searches the menu by meal number

            if (menuItem == null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count; //Initial count is compared to number of menu items in order to verify removal
            _listOfMenuItems.Remove(menuItem);

            if (initialCount > _listOfMenuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method that searches for menu items
        public MenuItem GetMenuItemsByNumber(int menuNumber)
        {
            foreach (MenuItem menuItem in _listOfMenuItems)
            {
                if (menuItem.ItemID == menuNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}

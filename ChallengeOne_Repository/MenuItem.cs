using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    public class MenuItem
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemIngredients { get; set; } //string may not be correct type
        public double ItemPrice { get; set; }

        public MenuItem() {}
        public MenuItem(int itemNumber, string itemName, string itemDescription, string itemIngredients, double itemPrice)
        {
            ItemID = itemNumber;                //number associated with menu item
            ItemName = itemName;                    //name of menu item
            ItemDescription = itemDescription;      //description of item
            ItemIngredients = itemIngredients;      //ingredients of item
            ItemPrice = itemPrice;                  //price of item
        }
    }
}

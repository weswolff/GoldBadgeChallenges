using KomodoBadge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Console
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        private Dictionary<int, string> doorDictionary = new Dictionary<int, string>()
            {
                { 12345, "A7" },
                {22345, "A1, A4, B1, B2" },
                {32345, "A4, A5" }
            };
        public void Run()
        {
            SeedBadgesToDictionary();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //display options to user
                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                //switch case for user input
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input\n" +
                            "Enter a number that corresponds with task you wish to complete.");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void DisplayAllBadges()
        {
            Console.Clear();
            Dictionary<int, Badge> listOfBadges = _badgeRepo.GetBadgeDictionary();

            Console.WriteLine("Badge #                Door Access");

            foreach (KeyValuePair<int, Badge> badge in listOfBadges) 
            {
                Console.WriteLine("{0, -20}", badge.Key);
               // for (int i = 0; i < badge.Value.DoorName.Count; i++)
               //Door name needs to be a list for this to work
                {

                }
                
            }
        }

        public void CreateBadge()
        {
            Badge newBadge = new Badge();

            //Badge ID
            Console.WriteLine("What is the number on the badge: ");
            //Convert string to int
            string badgeIdString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIdString);

            //Door name
            Console.WriteLine("List a door that it needs access to: ");
            newBadge.DoorName = Console.ReadLine();

            //Continue adding doors
            Console.WriteLine("Any other doors(y/n)? ");
            string userInput = Console.ReadLine(); //set up the if statement for continuing to work on doors
            while (userInput == "y")
            {
                Console.WriteLine("List a door that it needs access to: ");
                newBadge.DoorName = Console.ReadLine();
                Console.WriteLine("Any other doors(y/n)? ");
                userInput = Console.ReadLine();
            }

            //add to list of badges
            _badgeRepo.AddBadgeToList(newBadge);

        }
        public void UpdateBadge()
        {
            DisplayAllBadges();
            Badge badge = new Badge();
            Console.WriteLine("What is the badge number to update? ");

            Console.WriteLine($"{badge.BadgeID} has access to {badge.DoorName}");
            Console.WriteLine("What would you like to do? \n" +
                "1. Remove a door\n" +
                "2. Add a door");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    //Remove Door
                    Console.WriteLine("Which door would you like to remove?");
                    int doorName = Convert.ToInt32(Console.ReadLine());
                    doorDictionary.Remove(doorName); //remove specific door name from dictionary string

                    Console.WriteLine($"{badge.BadgeID} has access to {doorDictionary[doorName]}");
                    break;
                case "2":
                    //add door
                    Console.WriteLine("Which door would you like to add?");
                    string oldDoorName = Console.ReadLine();
                   // _badgeRepo.AddBadgeToList(oldDoorName);
                    Console.WriteLine($"{badge.BadgeID} has access to {badge.DoorName}");
                    break;
                default:
                    break;
            }

        }
        public void SeedBadgesToDictionary()
        {
            Badge badge1 = new Badge(12345, "A7", "Badge 1");
            Badge badge2 = new Badge(22345, "A1, A4, B1, B2", "Badge 2");
            Badge badge3 = new Badge(32345, "A4, A5", "Badge 3");

            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.AddBadgeToDictionary(badge2);
            _badgeRepo.AddBadgeToDictionary(badge3);
        }
    }
}

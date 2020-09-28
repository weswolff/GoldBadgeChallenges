using ChallengeTwo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            SeedClaimsToList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //display options to user
                Console.WriteLine("What would you like to do?\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit");
                //Get user input and evaluate it
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //view all claims
                        
                        break;
                    case "2":
                        //Take care of next claim
                       
                        break;
                    case "3":
                        //Create a new claim
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input\n" +
                            "Enter a number that corresponds with the task you wish to complete.");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create a new claim
        private void CreateNewClaim()
        {
            Claims newClaim = new Claims();

            //Claim ID
            Console.WriteLine("Enter the Claim ID: ");
            //Conver ID to string
            string claimIdString = Console.ReadLine();
            newClaim.ClaimId = int.Parse(claimIdString);

            //Claim Type
            Console.WriteLine("What is the claim type?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string claimTypeAsString = Console.ReadLine(); //user input as string
            int claimTypeAsInt = int.Parse(claimTypeAsString); //parse string to int
            newClaim.ClaimType = (TypeOfClaim)claimTypeAsInt; //associate int with claim type

            //Claim Description
            Console.WriteLine("Enter a description for this claim: ");
            newClaim.Description = Console.ReadLine();

            //Amount of claim
            Console.WriteLine("Enter the amount of this claim: ");
            string claimAmountAsString = Console.ReadLine();
            newClaim.ClaimAmount = double.Parse(claimAmountAsString); //parse to double

            // Date of accident
            Console.WriteLine("When did the accident happen? ");
            newClaim.DateOfIncident = GetDateTime(); // the return of the get date time method is set to day of accident

            //Date of claim
            Console.WriteLine("When was the claim filed? ");
            newClaim.DateOfClaim = GetDateTime();

            //Validate if claim is valid or not
            if ((newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays < 30)
            {
                bool isValid = true;
            }
            else
            {
                bool isValid = false;
            }

        }

        private DateTime GetDateTime() //This method gets the date from the user to be used for accident and claim dates
        {
            Console.WriteLine("Day: ");
            var day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Month: ");
            var month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Year: ");
            var year = Convert.ToInt32(Console.ReadLine());

            return new DateTime(month, day, year);
        }
    }
}

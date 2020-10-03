using ChallengeTwo_Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Console
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            SeedClaimsToQueue();
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
                        ShowAllClaims();
                        break;
                    case "2":
                        NextClaimInQ();
                        break;
                    case "3":
                        CreateNewClaim();
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

        public void ShowAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimsQ = _claimRepo.GetClaims(); //This is not displaying properly, need to figure out how to
            foreach (Claims claim in claimsQ)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimId}\n" +
                        $"Type: {claim.ClaimType}\n" +
                        $"Description: {claim.Description}\n" +
                        $"Amount: {claim.ClaimAmount}\n" +
                        $"DateOfIncident: {claim.DateOfIncident}\n" +
                        $"DateOfClaim: {claim.DateOfClaim}\n" +
                        $"IsValid: {claim.IsValid}\n");
            }                              
        }
        public void DisplayClaim(Claims claims)
        {
            Queue<Claims> claimsQ = _claimRepo.GetClaims();
            
            
        }

        //This method will display the claim at the top of the queue with more detail
        public void NextClaimInQ()
        {
            bool workingOnClaims = true;
            while (workingOnClaims)
            {
                Claims claim = _claimRepo.NextClaim();
                Console.WriteLine($"ClaimID: {claim.ClaimId}\n" +
                            $"Type: {claim.ClaimType}\n" +
                            $"Description: {claim.Description}\n" +
                            $"Amount: {claim.ClaimAmount}\n" +
                            $"DateOfIncident: {claim.DateOfIncident}\n" +
                            $"DateOfClaim: {claim.DateOfClaim}\n" +
                            $"IsValid: {claim.IsValid}\n");
                Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
                string userInput = Console.ReadLine();
                if (userInput == "y")
                {
                    _claimRepo.DeleteClaims();
                }
                else
                {
                    workingOnClaims = false;
                }
            }


        }
        //Create a new claim
        private void CreateNewClaim()
        {
            Claims newClaim = new Claims();

            //Claim ID
            Console.WriteLine("Enter the Claim ID: ");
            //Convert ID to string
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
                Console.WriteLine("This claim is valid.");
            }
            else
            {
                Console.WriteLine("This claim is not valid.");
            }
            _claimRepo.AddClaims(newClaim);
        }

        private DateTime GetDateTime() //This method gets the date from the user to be used for accident and claim dates
        {
            Console.WriteLine("Day: ");
            var day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Month: ");
            var month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Year: ");
            var year = Convert.ToInt32(Console.ReadLine());

            return new DateTime(day, month, year);
        }

        
        public void SeedClaimsToQueue()
        {
            DateTime dateOfCarCrash = new DateTime(2018 , 04, 25);
            DateTime dateOfCarClaim = new DateTime(2018 , 04, 12);

            DateTime dateOfHouseFire = new DateTime(2018, 04, 11);
            DateTime dateOfHouseClaim = new DateTime(2018, 04, 12);

            DateTime dateOfTheft = new DateTime(2018, 04, 27);
            DateTime dateOfTheftClaim = new DateTime(2018, 06, 01);

            Claims carClaim = new Claims(1, TypeOfClaim.Car , "Car accident on 465.", 400.00, dateOfCarCrash, dateOfCarClaim, true);
            Claims houseClaim = new Claims(2, TypeOfClaim.Home, "House fire in kitchen.", 4000.00, dateOfHouseFire, dateOfHouseClaim, true);
            Claims theftClaim = new Claims(3, TypeOfClaim.Theft, "Stolen pancakes.", 4.00, dateOfTheft, dateOfTheftClaim, false);
            //Get your list from the repo
            _claimRepo.AddClaims(carClaim);
            _claimRepo.AddClaims(houseClaim);
            _claimRepo.AddClaims(theftClaim);
            
            
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClaimsLibrary;
using ClaimsUI.Consoles;

namespace ClaimsUI
{
    public class UserInterface
    {
        private readonly IConsole _console; // This is my console
        private readonly ClaimsRepository _repo = new ClaimsRepository(); // This is where I define how my console runs
        public UserInterface(IConsole console) { _console = console; } // Using constructor to ask for console, and injecting the console into our field
        public void Run() { SeedContent(); RunMenu(); }
        private void RunMenu() // Method to run the menu
        {
            bool isRunning = true;
            while (isRunning)
            {
                _console.Clear();
                _console.WriteLine(
                    "Enter the number of your menu selection: \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit"
                );
                string userSelection = _console.ReadLine();
                switch(userSelection.ToLower())
                {
                    case "1":
                    case "all":
                        GetClaims();
                        break;
                    case "2":
                    case "next":
                        NextClaim();
                        break;
                    case "3":
                    case "new":
                        EnterClaim();
                        break;
                    case "4":
                    case "exit":
                        _console.WriteLine("Exiting program...");
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void GetClaims() // Method to list all the claims
        {
            _console.Clear();
            Queue<Claim> listOfClaims = _repo.GetClaims();
            foreach(Claim content in listOfClaims) { PrintContent(content); }
        }
        private void GetClaimByID() // Method to find a claim by its ID (not currently used)
        {
            _console.Clear();
            _console.WriteLine("Enter a claim ID: ");
            int targetID = int.Parse( _console.ReadLine());
            Claim content = _repo.GetClaimByID(targetID);
            if(content != null) { PrintContent(content); }
            else { _console.WriteLine("ID not found."); }
            _console.WriteLine("Press any key to continue...");
            _console.ReadLine();
            _console.Clear();
        }
        private void EnterClaim() // Method to enter a new claim
        {
            Console.Clear();
            Claim content = new Claim();
            _console.WriteLine("Enter the claim ID: ");
            content.ClaimID = int.Parse(_console.ReadLine());
            _console.WriteLine("Choose the claim type: \n" + "1: Car \n" + "2: Home \n" + "3: Theft");
            string claimTypeResponse = _console.ReadLine();
            switch(claimTypeResponse.ToLower())
            {
                case "1":
                case "car":
                    content.ClaimType = ClaimType.Car;
                    break;
                case "2":
                case "home": 
                    content.ClaimType = ClaimType.Home;
                    break;
                case "3":
                case "theft": 
                    content.ClaimType = ClaimType.Theft;
                    break;
                default:
                    break;
            }
            _console.WriteLine("Enter a brief description of the claim: ");
            content.Description = _console.ReadLine();
            _console.WriteLine("Enter the monetary amount of damage: ");
            content.ClaimAmount = double.Parse(_console.ReadLine());
            _console.WriteLine("Enter the date of the incident: ");
            content.DateOfIncident = DateTime.Parse(_console.ReadLine());
            _console.WriteLine("Enter the date of the claim: ");
            content.DateOfClaim = DateTime.Parse(_console.ReadLine());
            _console.WriteLine("Is this claim valid? \n" + "1: Yes \n" + "2: No");
            string validityResponse = _console.ReadLine();
            switch(validityResponse.ToLower())
            {
                case "1":
                case "yes":
                    content.IsValid = true;
                    break;
                case "2":
                case "no":
                    content.IsValid = false;
                    break;
                default:
                    break;
            }
        }
        public void NextClaim() // Method to get the next claim in the queue
        {
            _console.Clear();
            Claim content = _repo.NextClaim();
            if(content != null) 
            { 
                PrintContent(content); 
                _console.WriteLine("Do you want to deal with this claim now? \n" + "y: yes\n" + "n: no"); 
                string userSelection = _console.ReadLine();
                switch(userSelection.ToLower())
                {
                    case "y":
                    case "yes":
                        NextClaim();
                        break;
                    default:
                        break;
                }
            }
            else { _console.WriteLine("There are no claims in the queue."); }
        }
        private void SeedContent() // Seed method, which stores some claims in the database
        {
            Claim x = new Claim(1, ClaimType.Car, "Car accident on 465.", 400, new DateTime(20180418), new DateTime(20180427), true);
            Claim y = new Claim (2, ClaimType.Home, "House fire in kitchen", 4000, new DateTime(20180411), new DateTime(20180412), true);
            Claim z = new Claim (3, ClaimType.Theft, "Stolen pancakes", 4, new DateTime(20180427), new DateTime(20180618), false);
            _repo.EnterClaim(x); _repo.EnterClaim(y); _repo.EnterClaim(z);
        }
        private void PrintContent(Claim content) // Helper method for printing the content of a claim
        {
            _console.WriteLine(
                            $"Claim ID: {content.ClaimID} \n" +
                            $"Type of claim: {content.ClaimType} \n" +
                            $"Description: {content.Description} \n" +
                            $"Claim amount: {content.ClaimAmount} \n" +
                            $"Date of incident: {content.DateOfIncident} \n" +
                            $"Date of claim: {content.DateOfClaim} \n" +
                            $"Claim is valid? {content.IsValid} \n\n"
            );
        }
    }
}
using System;
using System.Collections.Generic;

// The main class representing the dog racing program
public class DogProgram {
    // Lists to store information about dogs, user balance, payment history, and racing tracks
    static List<Dog> dogs;
    static double userBalance = 0.0;
    static List<double> paymentHistory = new List<double>();
    static List<RacingTrack> race;

    // The main entry point of the program
    public static void Main(string[] args) {
        bool exit = false;
        dogs = new List<Dog>();
        race = new List<RacingTrack>();

        // Initialize dogs and tracks
        InitializeDogs();
        InitializeTracks();

        // Main program loop
        while (!exit) {
            // Display main menu
            Console.Clear();
            Console.WriteLine("*********************************");
            Console.WriteLine("*    Welcome to ShellesKennel!   *");
            Console.WriteLine("* Choose what you're looking for: *");
            Console.WriteLine("* 0. Information about Shelle's  *");
            Console.WriteLine("*    Kennel                      *");
            Console.WriteLine("* 1. Show information about the *");
            Console.WriteLine("*    dogs                         *");
            Console.WriteLine("* 2. Add your dog                 *");
            Console.WriteLine("* 3. Competitive race            *");
            Console.WriteLine("* 4. Add funds                   *");
            Console.WriteLine("* 5. Exit                         *");
            Console.WriteLine("*********************************");
            int temp = 0;
            // Get user choice
            int choice;

            while (true) {
                Console.Write("Enter your choice: ");

                try {
                    choice = int.Parse(Console.ReadLine()); // Parse user input as an integer for the menu choice.
                    break; // Exit the loop if parsing is successful
                }
                catch (FormatException) {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            // Switch based on user choice
            switch (choice) {

                case 0:
                    // Information about Shelle's Kennel
                    Console.WriteLine("*********************************");
                    Console.WriteLine("[Shelle Kennel]");
                    Console.WriteLine("What We Offer: Safe and cozy boarding, personalized training, and expert breeding for [specific breeds].");
                    Console.WriteLine("Our Place: Customized spaces, play areas, grooming services for a happy pet.");
                    Console.WriteLine("Our Promise: Safety-first approach, a clean environment, and vet collaboration.");
                    Console.WriteLine("Choose Us For: Your pet's happiness and well-being.");
                    Console.WriteLine("Before Arrival: Ensure your pet’s vaccinations are up-to-date.");
                    Console.WriteLine("Thank you for considering [Shelle's Kennel]. We're excited to care for your pet");
                    break;

                case 1:
                    // Show information about the dogs
                    Console.WriteLine("*********************************");
                    foreach (var dog in dogs) {
                        dog.PrintInfo();
                        Console.WriteLine("*********************************");
                    }
                    break;

                case 2:
                    // Add your dog
                    Console.WriteLine("*********************************");
                    Yourdog();
                    break;

                case 3:
                    // Start the dog racing
                    DogsReadyForRacing();
                    break;


                case 4:
                    Console.WriteLine("*********************************");
                    // Add money to user balance
                    Console.Write("Enter the amount of money you want to add to your balance: ");
                    double amountToAdd = Convert.ToDouble(Console.ReadLine());
                    userBalance += amountToAdd;

                    // Add the transaction to payment history
                    paymentHistory.Add(amountToAdd);

                    Console.WriteLine($"Your balance is now: {userBalance:$0}");
                    break;

                case 5:
                    Console.WriteLine("*********************************");
                    // Exit the user program
                    exit = true;
                    Console.WriteLine("Exiting ShellesKennel. Goodbye!");
                    break;

                default:
                    // If the user typed a non-existent case, he will get the default case.
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;


            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadKey();
        }
    }

    // The m    ethod to add a new dog to the list

    static void Yourdog() {
        // Collect information about the new dog from the user
        Console.Write("Enter your dog's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your dog's age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your dog's height: ");
        int height = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your dog's breed: ");
        string breed = Console.ReadLine();

        Console.Write("Enter your dog's max speed: ");
        int maxSpeed = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your dog's gender: ");
        string gender = Console.ReadLine();

        Console.Write("Enter your dog's weight: ");
        int weight = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your dog's endurance: ");
        int endurance = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your dog's acceleration: ");
        int acceleration = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your dog's focus: ");
        int focus = Convert.ToInt32(Console.ReadLine());

        Dog newDog = new Dog(name, age, height, breed, maxSpeed, gender, weight, endurance, acceleration, focus);
        dogs.Add(newDog);

        Console.WriteLine("Your dog has been added to the list!");
    }

    // The method to handle dog racing

    static void DogsReadyForRacing() {
        // Display dogs and available racing tracks
        Console.WriteLine("*********************************");
        Console.WriteLine("Dogs ready for racing:");
        for (int i = 0; i < dogs.Count; i++) {
            Console.WriteLine($"{i + 1}. {dogs[i].Name}");
        }

        Console.WriteLine("\nAvailable Tracks:");
        for (int i = 0; i < race.Count; i++) {
            Console.WriteLine($"{i + 1}. {race[i].Name} (Length: {race[i].Length}m, Surface: {race[i].Surface})");
        }
        // Collect user input for the race
        Console.Write("\nEnter the number of the track you want to race on: ");
        string trackInput = Console.ReadLine();
        int chosenTrackIndex;

        if (!int.TryParse(trackInput, out chosenTrackIndex) || chosenTrackIndex < 1 || chosenTrackIndex > race.Count) {
            Console.WriteLine("Invalid track choice. Please try again.");
            return;
        }

        // Perform the race and update user balance
        Console.WriteLine("********************************************************");
        Console.WriteLine($"You've chosen to race on {race[chosenTrackIndex - 1].Name}.");

        Console.Write("Enter the number of the dog you want to bet on: ");
        string dogInput = Console.ReadLine();
        int chosenDogIndex;

        if (!int.TryParse(dogInput, out chosenDogIndex) || chosenDogIndex < 1 || chosenDogIndex > dogs.Count) {
            Console.WriteLine("Invalid choice. Please try again.");
            return;
        }

        Console.WriteLine("********************************************************");
        Console.Write($"Enter the amount of money you want to bet (minimum $100): ");
        string betInput = Console.ReadLine();
        int betAmount;

        if (!int.TryParse(betInput, out betAmount) || betAmount < 100) {
            Console.WriteLine("Invalid bet amount. Minimum bet is $100. Please try again.");
            return;
        }

        if (betAmount > userBalance) {
            Console.WriteLine("Insufficient funds. Please add money to your balance.");
        }
        else {
            userBalance -= betAmount;

            Random random = new Random();
            int winningDogIndex = random.Next(0, dogs.Count);

            Console.WriteLine("********************************************************");
            Console.WriteLine($"The winning dog is {dogs[winningDogIndex].Name} on track {race[chosenTrackIndex - 1].Name}!");

            if (chosenDogIndex - 1 == winningDogIndex) {
                double winnings = betAmount * 2; // 2x earnings
                userBalance += winnings;

                Console.WriteLine($"Congratulations! You won {winnings} $. Your new balance is ${userBalance}$.");
            }
            else {
                Console.WriteLine("Unfortunately, you lost the race. Better luck next time!");
            }

            paymentHistory.Add(betAmount);

        }

    }

    // The method to initialize default dogs
    static void InitializeDogs() {
        dogs.Add(new Dog());
        dogs.Add(new Dog("Martin", 12, 65, "Saluki", 67, "F", 20, 80, 90, 70));
        dogs.Add(new Dog("Usain", 13, 72, "Greyhound", 72, "M", 28, 85, 88, 75));
        dogs.Add(new Dog("Bella", 5, 45, "Labrador Retriever", 55, "F", 22, 75, 80, 65));
        dogs.Add(new Dog("Max", 7, 65, "Golden Retriever", 70, "M", 26, 78, 85, 72));
    }

    // The method to initialize default racing tracks
    static void InitializeTracks() {
        race.Add(new RacingTrack("Track: 1", 1000, "Grass"));
        race.Add(new RacingTrack("Track: 2", 800, "Sand"));
        race.Add(new RacingTrack("Track: 3", 1200, "Dirt"));
    }
}

// Class representing a dog
class Dog {
    // Properties representing various attributes of a dog
    public int Height { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string Breed { get; set; }
    public int MaxSpeed { get; set; }
    public string Gender { get; set; }
    public int Endurance { get; set; }
    public int Acceleration { get; set; }
    public int Focus { get; set; }

    // Default constructor for a dog
    public Dog() {
        // Set default values for a dog
        Name = "Drake";
        Age = 11;
        Height = 67;
        Breed = "Greyhound";
        MaxSpeed = 72;
        Gender = "M";
        Weight = 31;
        Endurance = 85;
        Acceleration = 88;
        Focus = 75;
    }

    // Greatnessconstructor for a dog
    public Dog(string name, int age, int height, string breed, int maxSpeed, string gender, int weight,
        int endurance, int acceleration, int focus) {
        // Initialize a dog with provided values
        Name = name;
        Age = age;
        Height = height;
        Breed = breed;
        MaxSpeed = maxSpeed;
        Gender = gender;
        Weight = weight;
        Endurance = endurance;
        Acceleration = acceleration;
        Focus = focus;
    }

    // The method to print information about a dog
    public void PrintInfo() {
        // Print details of a dog
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Height: " + Height);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Breed: " + Breed);
        Console.WriteLine("Max Speed: " + MaxSpeed);
        Console.WriteLine("Gender: " + Gender);
        Console.WriteLine("Endurance: " + Endurance);
        Console.WriteLine("Acceleration: " + Acceleration);
        Console.WriteLine("Focus: " + Focus);
        Console.WriteLine();
    }
}

// Class representing racing track
class RacingTrack {
    // Properties representing attributes of a racing track
    public string Name { get; set; }
    public int Length { get; set; }
    public string Surface { get; set; }

    // Constructor for a racing track
    public RacingTrack(string name, int length, string surface) {
        Name = name;
        Length = length;
        Surface = surface;
    }
}

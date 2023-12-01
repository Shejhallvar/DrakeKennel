using System;
using System.Reflection;
using System.Xml.Linq;

public class DogProgram {

    static List<Dogs> dogs;



    
    public static void Main(string[] args) {

        bool exit = false;
        dogs = new List<Dogs>();
        dogs.Add(new Dogs());
        dogs.Add(new Dogs("Martin", 12, 65, "Saluki", 67, "F", 20));
        dogs.Add(new Dogs("Usain", 13, 72, "Greyhound", 72, "M", 28));

        while (!exit) {

            Console.Clear();
            Console.WriteLine("Welcome to ShellesKennel!");
            Console.WriteLine("Choose what you're looking for:");
            Console.WriteLine("0. Information about Shelle's Kennel");
            Console.WriteLine("1. Show information about the dogs");
            Console.WriteLine("2. Simulate a competitive race");
            Console.WriteLine("3. Add your dog");
            Console.WriteLine("4. Display available dogs");
            Console.WriteLine("5. Exit");

            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice)) {
            Console.WriteLine("Invalid selection. Try again.");
            continue;

            }

            switch (choice) {

                case 0:

                    // Information about Shelle's Kennel

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

                    //DisplayDogsInfo();
                    Console.WriteLine("************************");
                    for (int i = 0; i < dogs.Count; i++) {
                        dogs[i].PrintInfo();
                        Console.WriteLine("************************");
                    }
                    break;

                case 2:

                    // Simulate a competitive race

                    Console.WriteLine("Simulating a competitive race...");
                    Console.WriteLine("1- Use one of our dogs");
                    Console.WriteLine("2- Use your own dog");

                    break;

                case 3:

                    // Add your dog

                    Yourdog();

                    break;

                case 4:

                    // Display available dogs

                    DogsReadyForRacing();
                        Console.WriteLine("Enter the number of the dog you want to bet on: ");
                        string input = Console.ReadLine();
                        int TheChosenDog = Convert.ToInt32(input);
                    if (TheChosenDog > dogs.Count) {
                        Console.WriteLine("Invald chose please try again");
                        break;
                    }

                    Console.WriteLine("Enter the amount of money you want to bet: ");
                    string moneyinput = Console.ReadLine();
                    int money = Convert.ToInt32(moneyinput);
                    Random random = new Random();
                    int WiningDog= random.Next(1, dogs.Count);
                    Console.WriteLine("The wining dog is " + WiningDog + "!");
                    if (TheChosenDog == WiningDog) {
                        Console.WriteLine("Congratulations the dog you bet on won!");
                        Console.WriteLine("Your bet now is " + money*2+"$");

                    }
                    if (TheChosenDog != WiningDog) {
                        Console.WriteLine("Unfortunately the dog you bet on lost :(");
                        Console.WriteLine("You lost you bet");
                    }
                    break;

                case 5:

                    // Exit the user program

                    exit = true;

                    Console.WriteLine("Exiting ShellesKennel. Goodbye!");

                    break;

                default:    //If the user typed an non-existent case he will get the default case.

                    Console.WriteLine("Invalid choice. Please select again.");
                break;

            }

            Console.ReadKey();

        }

    }


    static void Yourdog() {

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

        Dogs newDog = new Dogs(name, age, height, breed, maxSpeed, gender, weight);

        dogs.Add(newDog);

        Console.WriteLine("Your dog has been added to the list!");

    }

    static void DogsReadyForRacing() {

        for (int i = 0; i < dogs.Count; i++) {

            Console.WriteLine((i + 1) + " " + dogs[i].Name);

        }

    }

}





class Dogs {

    public int Height { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Weight { get; set; }
    public string Breed { get; set; }
    public int MaxSpeed { get; set; }
    public string Gender { get; set; }
    public Dogs(string name, int age, int height, string breed, int maxSpeed, string gender, int weight) {

        Name = name;
        Age = age;
        Height = height;
        Breed = breed;
        MaxSpeed = maxSpeed;
        Gender = gender;
        Weight = weight;
    }
    public Dogs() {
        Name = "Drake";
        Age = 11;
        Height = 67;
        Breed = "Greyhound";
        MaxSpeed = 72;
        Gender = "M";
        Weight = 31;

    }



    public void PrintInfo() {

        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Height: " + Height);
        Console.WriteLine("Weight: " + Weight);
        Console.WriteLine("Breed: " + Breed);
        Console.WriteLine("Max Speed: " + MaxSpeed);
        Console.WriteLine("Gender: " + Gender);
        Console.WriteLine();
    }
}

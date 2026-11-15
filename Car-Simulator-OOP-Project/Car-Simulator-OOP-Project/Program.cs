using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Toyota");
            car.ShowStatus();

            string choice = " ";

            while (choice != "6")
            {
                Console.WriteLine("Car Simulator Menu:");
                Console.WriteLine("1. Start Engine");
                Console.WriteLine("2. increase Speed");
                Console.WriteLine("3. Stop Engine");
                Console.WriteLine("4. Refuel");
                Console.WriteLine("5. Show Status");
                Console.WriteLine("6. Exit");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if(car.Fuel > 0)
                        {
                            Console.WriteLine("Starting engine...");
                            car.StartEngine();
                        }
                        else
                        {
                            Console.WriteLine("Cannot start engine. Not enough fuel.");
                        }
                        break;
                    case "2":
                        if(car.EngineOn && car.Fuel > 0)
                        {
                            Console.WriteLine("Increasing speed...");
                            car.Drive(10);
                        }
                        else
                        {
                            Console.WriteLine("Cannot increase speed. Not enough fuel.");
                            car.StopEngine();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Stopping engine...");
                        car.StopEngine();
                        break;
                    case "4":
                        if(car.Fuel < 80)
                        {     
                            Console.WriteLine("Refueling...");
                            car.Refuel(50.0);
                        }
                        else
                        {
                            Console.WriteLine("Fuel tank is already almost full.");
                        }
                        break;
                    case "5":
                        car.ShowStatus(); 
                        break;
                }
            }
        }
    }
    public class Car
    {
        public string Brand { get; set; }
        public int Speed { get; set; }
        public double Fuel { get; set; }
        public bool EngineOn { get; set; }

        public Car(string brand)
        {
            Brand = brand;
            Speed = 0;
            Fuel = 50.0;
            EngineOn = false;
        }

        public bool StartEngine()
        {
            if (Fuel <= 0)
            {
                return false;
            }
            EngineOn = true;
            return true;
        }

        public bool StopEngine()
        {
            if (Speed > 0)
            {
                return false;
            }
            EngineOn = false;
            Speed = 0;
            return true;
        }

        public void Drive(int speedIncrease)
        {
            if (EngineOn && Fuel > 0)
            {
                Speed += speedIncrease;
                Fuel -= speedIncrease * 0.1;
                if (Fuel < 0) Fuel = 0;
            }
        }

        public void Refuel(double amount)
        {
            Fuel += amount;
            if (Fuel > 100.0) Fuel = 100.0;
        }

        public void ShowStatus()
        {
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Speed: {Speed}km/h");
            Console.WriteLine($"Fuel: {Fuel}%");
            Console.WriteLine($"Engine On: {EngineOn}");
        }
    }
}
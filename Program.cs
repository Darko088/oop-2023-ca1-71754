namespace ca1_oop_71754
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bogus;

    public abstract class ParkingLot
    {
        public string Name { get; }
        public double HourlyRate { get; }
        public double MaxDailyCharge { get; }
        public double TotalReceipts { get; protected set; }

        protected ParkingLot(string name, double hourlyRate, double maxDailyCharge)
        {
            Name = name;
            HourlyRate = hourlyRate;
            MaxDailyCharge = maxDailyCharge;
            TotalReceipts = 0;
        }

        // Abstract method to calculate parking charges, to be implemented by derived classes
        public abstract double CalculateCharges(int parkedHours);

        // Method to simulate parking a car and calculate charges
        public double ParkCar(int parkedHours)
        {
            double charge = CalculateCharges(parkedHours);
            TotalReceipts += charge;
            return charge;
        }
    }

    public class ParkingLot1 : ParkingLot
    {
        public ParkingLot1() : base("Parking Lot 1", 0.50, 10.00) { }

        // Implementation of the abstract method to calculate charges for Parking Lot 1
        public override double CalculateCharges(int parkedHours)
        {
            double minFee = 2.00;
            int maxHours = 3;
            double additionalHoursFee = Math.Max(0, parkedHours - maxHours) * HourlyRate;
            return Math.Min(minFee + additionalHoursFee, MaxDailyCharge);
        }
    }

    public class ParkingLot2 : ParkingLot
    {
        public ParkingLot2() : base("Parking Lot 2", 0.60, 10.00) { }

        // Implementation of the abstract method to calculate charges for Parking Lot 2
        public override double CalculateCharges(int parkedHours)
        {
            double minFee = 2.00;
            int maxHours = 3;
            double additionalHoursFee = Math.Max(0, parkedHours - maxHours) * HourlyRate;
            return Math.Min(minFee + additionalHoursFee, MaxDailyCharge);
        }
    }

    public class ParkingLot3 : ParkingLot
    {
        public ParkingLot3() : base("Parking Lot 3", 0.75, 10.00) { }

        // Implementation of the abstract method to calculate charges for Parking Lot 3
        public override double CalculateCharges(int parkedHours)
        {
            double minFee = 2.00;
            int maxHours = 3;
            double additionalHoursFee = Math.Max(0, parkedHours - maxHours) * HourlyRate;
            return Math.Min(minFee + additionalHoursFee, MaxDailyCharge);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the jungle");

            var parkingLots = new List<ParkingLot> { new ParkingLot1(), new ParkingLot2(), new ParkingLot3() };

            foreach (var parkingLot in parkingLots)
            {
                Console.WriteLine($"{parkingLot.Name} has 10 cars parked in one day");

                for (int i = 0; i < 10; i++)
                {
                    string registrationNumber = GenerateRegistrationNumber();
                    int parkedHours = new Faker().Random.Int(1, 10);
                    double charge = parkingLot.ParkCar(parkedHours);

                    Console.WriteLine($"Customer {registrationNumber} - Parked for {parkedHours} hours - Charge: €{charge:F2}");
                }

                Console.WriteLine($"Total receipts for {parkingLot.Name}: €{parkingLot.TotalReceipts:F2}\n");
            }

            double overallTotal = parkingLots.Sum(p => p.TotalReceipts);
            Console.WriteLine($"Overall Total Receipts: €{overallTotal:F2}");
        }

        // Method to generate a random registration number
        static string GenerateRegistrationNumber()
        {
            var faker = new Faker();
            string letters = faker.Random.AlphaNumeric(2);
            string numbers = faker.Random.Number(10000, 99999).ToString();
            return $"{letters}{numbers}";
        }
    }

}
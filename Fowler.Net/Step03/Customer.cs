using System.Collections.Generic;

namespace Step03
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        private string _name;
        public string Name => _name; 

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
            => _rentals.Add(rental);

        public string GetStatement()
        {
            var totalAmount = 0m;
            var frequentRenterPoints = 0;
            var result = $"Rental Record for {Name}\n";

            foreach(var rental in _rentals)
            {
                var thisAmount = rental.GetCharge();
                frequentRenterPoints += rental.GetFrequentRenterPoints();

                // show figures for this rental
                result += $"\t{rental.Movie.Title}\t{thisAmount:£0.00}\n";
                totalAmount += thisAmount;
            }

            result += $"Amount owed is {totalAmount:£0.00}\n";
            result += $"You earned {frequentRenterPoints} frequent renter points";
            
            return result;
        }
    }
}
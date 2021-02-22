using System.Collections.Generic;
using System.Linq;

namespace Step07
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
            var result = $"Rental Record for {Name}\n";

            foreach(var rental in _rentals)
            {
                // show figures for this rental
                result += $"\t{rental.Movie.Title}\t{rental.GetCharge():£0.00}\n";
            }

            // add footer lines
            result += $"Amount owed is {GetTotalCharge():£0.00}\n";
            result += $"You earned {GetFrequentRenterPoints()} frequent renter points";
            
            return result;
        }

        private int GetFrequentRenterPoints()
            => _rentals.Sum(x => x.GetFrequentRenterPoints());

        private decimal GetTotalCharge()
            => _rentals.Sum(x => x.GetCharge());
    }
}
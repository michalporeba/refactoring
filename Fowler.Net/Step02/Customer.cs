using System.Collections.Generic;

namespace Step02
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
                var thisAmount = AmountFor(rental);
                frequentRenterPoints += FrequentRenterPointsFor(rental);

                // show figures for this rental
                result += $"\t{rental.Movie.Title}\t{thisAmount:£0.00}\n";
                totalAmount += thisAmount;
            }

            // add footer lines
            result += $"Amount owed is {totalAmount:£0.00}\n";
            result += $"You earned {frequentRenterPoints} frequent renter points";
            
            return result;
        }

        private static int FrequentRenterPointsFor(Rental rental)
        {
            if ((rental.Movie.PriceCode == Movie.PriceCodes.NewRelease)
                && (rental.DaysRented > 1))
                return 2;
            return 1;
        }

        private decimal AmountFor(Rental rental)
        {
            var result = 0m;
            switch (rental.Movie.PriceCode)
            {
                case Movie.PriceCodes.Regular:
                    result += 2;
                    if (rental.DaysRented > 2)
                        result += (rental.DaysRented - 2) * 1.5m;
                    break;
                case Movie.PriceCodes.NewRelease:
                    result += rental.DaysRented * 3;
                    break;
                case Movie.PriceCodes.Children:
                    result += 1.5m;
                    if (rental.DaysRented > 3)
                        result += (rental.DaysRented - 3) * 1.5m;
                    break;
            }

            return result;
        }
    }
}
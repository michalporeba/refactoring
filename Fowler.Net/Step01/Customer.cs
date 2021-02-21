using System.Collections.Generic;

namespace Step01
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        private string _name;
        public string Name
        {
            get { return _name; }
        }

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string GetStatement()
        {
            var totalAmount = 0m;
            var frequentRenterPoints = 0;
            var result = $"Rental Record for {Name}\n";

            foreach(var rental in _rentals)
            {
                var thisAmount = 0m;
                switch (rental.Movie.PriceCode)
                {
                    case Movie.PriceCodes.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5m;
                        break;
                    case Movie.PriceCodes.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.PriceCodes.Children:
                        thisAmount += 1.5m;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5m;
                        break;
                }
                
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental 
                if ((rental.Movie.PriceCode == Movie.PriceCodes.NewRelease)
                    && (rental.DaysRented > 1))
                    frequentRenterPoints++;
                
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
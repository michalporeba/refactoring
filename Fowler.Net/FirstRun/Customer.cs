using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstRun
{
    public class Customer
    {
        private List<Rental> _rentals = new List<Rental>();
        
        public string Name { get; private set; }

        public Customer(string name)
        {
            this.Name = name;
        }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            var result = "Rental Record for " + Name + Environment.NewLine;

            foreach (var rental in _rentals)
            {
                // show figures for this rental
                result += "\t" + rental.Movie.Title + "\t" + rental.GetCharge() + Environment.NewLine;
            }

            result += "Amount owed is " + TotalCharge() + Environment.NewLine;
            result += "You earned " + FrequentRenterPoints() + " frequent renter points";

            return result;
        }

        public string htmlStatement()
        {
            var result = "<h1>Rentals for <em>" + Name + "</em></h1><p>" + Environment.NewLine;
            foreach (var rental in _rentals)
            {
                result += rental.Movie.Title + ": " + rental.GetCharge() + "<br>" + Environment.NewLine;
            }
            
            result += "</p><p>You owe <em>" + TotalCharge() + "</em></p>";
            result += "<p>You earned " + FrequentRenterPoints() + " frequent renter points</p>";

            return result;
        }
        
        private double TotalCharge()
            => _rentals.Sum(x => x.GetCharge());

        private double FrequentRenterPoints()
            => _rentals.Sum(x => x.GetFrequentRenterPoints());
    }
}
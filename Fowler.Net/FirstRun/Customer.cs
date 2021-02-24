using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstRun
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();
        private string _name;

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
            var builder = new StringStatementBuilder();
            builder.AddName(_name);
            builder.AddTotalCharge(TotalCharge());
            _rentals.ForEach(rental => builder.AddRental(rental));

            foreach (var rental in _rentals)
            {
                // show figures for this rental
                //result += "\t" + rental.Movie.Title + "\t" + rental.GetCharge().ToString("£0.00") + Environment.NewLine;
            }


            return builder.ToStatement();
        }

        public string GetHtmlStatement()
        {
            var result = "<h1>Rentals for <em>" + _name + "</em></h1><p>" + Environment.NewLine;
            foreach (var rental in _rentals)
            {
                result += rental.Movie.Title + ": " + rental.GetCharge() + "<br>" + Environment.NewLine;
            }
            
            result += "</p><p>You owe <em>" + TotalCharge() + "</em></p>";
            result += "<p>You earned " + FrequentRenterPoints() + " frequent renter points</p>";

            return result;
        }
        
        private decimal TotalCharge()
            => _rentals.Sum(x => x.GetCharge());

        private int FrequentRenterPoints()
            => _rentals.Sum(x => x.GetFrequentRenterPoints());
    }
}
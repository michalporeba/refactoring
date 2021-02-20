using System;
using System.Collections.Generic;

namespace Step01
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

        public string GetStatement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + Environment.NewLine;

            foreach(var rental in _rentals)
            {
                double thisAmount = 0;
                switch (rental.Movie.PriceCode)
                {
                    case Movie.PriceCodes.Regular:
                        thisAmount += 2;
                        if (rental.DaysRented > 2)
                            thisAmount += (rental.DaysRented - 2) * 1.5;
                        break;
                    case Movie.PriceCodes.NewRelease:
                        thisAmount += rental.DaysRented * 3;
                        break;
                    case Movie.PriceCodes.Childrens:
                        thisAmount += 1.5;
                        if (rental.DaysRented > 3)
                            thisAmount += (rental.DaysRented - 3) * 1.5;
                        break;
                }
                
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental 
                if ((rental.Movie.PriceCode == Movie.PriceCodes.NewRelease)
                    && (rental.DaysRented > 1))
                    frequentRenterPoints++;
                
                // show figures for this rental
                result += "\t" + rental.Movie.Title + "\t£" + thisAmount.ToString("0.00") + Environment.NewLine;
                totalAmount += thisAmount;
            }

            result += "Amount owed is £" + totalAmount.ToString("0.00") + Environment.NewLine;
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            
            return result;
        }
    }
}
using System;
using System.Collections.Generic;

namespace FirstRun
{
    public abstract class StatementBuilder
    {
        protected string _name;
        protected decimal _total;
        protected int _points;
        protected List<Rental> _rentals = new List<Rental>();

        public void AddName(string name) => _name = name;
        public void AddTotalCharge(decimal charge) => _total = charge;
        public void AddFrequentRenterPoints(int points) => _points = points;
        public void AddRental(Rental rental) => _rentals.Add(rental);

        public abstract string ToStatement();
    }

    public class StringStatementBuilder : StatementBuilder
    {
        public override string ToStatement()
            => $"Rental Record for {_name}\n" 
               + $"Amount owed is {_total:£0.00}\n"
               + $"You earned {_points} frequent renter points";
    }

    public class HtmlStatementBuilder : StatementBuilder
    {
        public override string ToStatement()
            => $"<p>Rental Record for {_name}</p>\n" 
               + $"<p>Amount owed is {_total:£0.00}</p>\n"
               + $"<p>You earned {_points} frequent renter points</p>";
    }
}
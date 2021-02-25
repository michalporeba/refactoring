using System.Collections.Generic;
using System.Linq;

namespace Step11
{
    public class Customer
    {
        public interface Statement
        {
            void AddName(string name);
            void AddRental(Rental rental);
            void AddTotalCharge(decimal totalCharge);
            void AddFrequentRenterPoints(int points);
            string Build();
        } 
        
        private readonly List<Rental> _rentals = new List<Rental>();
        private readonly string _name; 

        public Customer(string name)
        {
            _name = name;
        }

        public void AddRental(Rental rental)
            => _rentals.Add(rental);

        public string GetStatement() 
            => GetStatement(new PlainTextStatement(this));

        public string GetStatement(Statement statement)
        {
            statement.AddName(_name);
            _rentals.ForEach(rental => statement.AddRental(rental));
            statement.AddTotalCharge(GetTotalCharge());
            statement.AddFrequentRenterPoints(GetFrequentRenterPoints());
            return statement.Build();
        }

        private int GetFrequentRenterPoints()
            => _rentals.Sum(x => x.GetFrequentRenterPoints());

        private decimal GetTotalCharge()
            => _rentals.Sum(x => x.GetCharge());
    }
}
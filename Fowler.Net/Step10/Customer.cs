using System.Collections.Generic;
using System.Linq;

namespace Step10
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
        
        private List<Rental> _rentals = new List<Rental>();

        public string Name { get; } 

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
            => _rentals.Add(rental);

        public string GetStatement() 
            => GetStatement(new PlainTextStatement(this));

        public string GetStatement(Statement statement)
        {
            statement.AddName(Name);
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
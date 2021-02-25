using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step09
{
    public class Customer
    {
        internal List<Rental> Rentals { get; } = new List<Rental>();

        public string Name { get; } 

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
            => Rentals.Add(rental);

        public string GetStatement() 
            => GetStatement(new PlainTextStatement());

        public string GetStatement(Statement statement)
            => statement.Create(this);

        internal int GetFrequentRenterPoints()
            => Rentals.Sum(x => x.GetFrequentRenterPoints());

        internal decimal GetTotalCharge()
            => Rentals.Sum(x => x.GetCharge());
    }
}
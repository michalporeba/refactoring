using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step10
{
    public class Customer
    {
        public interface Statement
        {
            void AddName(string name);
            string Build();
        } 
        
        internal List<Rental> Rentals { get; } = new List<Rental>();

        public string Name { get; } 

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
            => Rentals.Add(rental);

        public string GetStatement() 
            => GetStatement(new PlainTextStatement(this));

        public string GetStatement(Statement statement)
        {
            statement.AddName(Name);
            return statement.Build();
        }

        internal int GetFrequentRenterPoints()
            => Rentals.Sum(x => x.GetFrequentRenterPoints());

        internal decimal GetTotalCharge()
            => Rentals.Sum(x => x.GetCharge());
    }
}
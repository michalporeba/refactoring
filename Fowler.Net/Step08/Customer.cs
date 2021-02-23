using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Step08
{
    public class Customer
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public string Name { get; } 

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
            => _rentals.Add(rental);

        public string GetStatement()
        {
            var sb = new StringBuilder($"Rental Record for {Name}\n");

            _rentals.ForEach(rental => sb.AppendLine($"\t{rental.Movie.Title}\t{rental.GetCharge():£0.00}"));

            sb.AppendLine($"Amount owed is {GetTotalCharge():£0.00}\n");
            sb.AppendLine($"You earned {GetFrequentRenterPoints()} frequent renter points");
            
            return sb.ToString();
        }
        
        public string GetHtmlStatement()
        {
            var sb = new StringBuilder($"<p>Rental Record for {Name}</p>");

            _rentals.ForEach(rental => sb.Append($"<p>{rental.Movie.Title} for {rental.GetCharge():£0.00}</p>"));

            sb.Append($"<p>Amount owed is {GetTotalCharge():£0.00}</p>");
            sb.Append($"<p>You earned {GetFrequentRenterPoints()} frequent renter points</p>");
            
            return sb.ToString();
        }

        private int GetFrequentRenterPoints()
            => _rentals.Sum(x => x.GetFrequentRenterPoints());

        private decimal GetTotalCharge()
            => _rentals.Sum(x => x.GetCharge());
    }
}
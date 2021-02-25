using System.Text;

namespace Step09
{
    public interface Statement
    {
        string Create(Customer customer);
    }

    public class PlainTextStatement : Statement
    {
        public string Create(Customer customer)
        {
            var sb = new StringBuilder($"Rental Record for {customer.Name}\n");

            customer.Rentals.ForEach(rental => sb.Append($"\t{rental.Movie.Title}\t{rental.GetCharge():£0.00}\n"));

            sb.Append($"Amount owed is {customer.GetTotalCharge():£0.00}\n");
            sb.Append($"You earned {customer.GetFrequentRenterPoints()} frequent renter points\n");
            
            return sb.ToString();
        }
    }

    public class HtmlStatement : Statement
    {
        public string Create(Customer customer)
        {
            var sb = new StringBuilder($"<p>Rental Record for {customer.Name}</p>");

            customer.Rentals.ForEach(rental => sb.Append($"<p>{rental.Movie.Title} for {rental.GetCharge():£0.00}</p>"));

            sb.Append($"<p>Amount owed is {customer.GetTotalCharge():£0.00}</p>");
            sb.Append($"<p>You earned {customer.GetFrequentRenterPoints()} frequent renter points</p>");
            
            return sb.ToString();
        }
    }
}
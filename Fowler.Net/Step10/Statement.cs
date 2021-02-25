using System.Text;

namespace Step10
{
    public class PlainTextStatement : Customer.Statement
    {
        private readonly Customer _customer;
        private readonly StringBuilder _sb = new StringBuilder();
        
        public PlainTextStatement(Customer customer) => _customer = customer;
        
        public void AddName(string name)
            => _sb.Append($"Rental Record for {_customer.Name}\n");
        
        public string Build()
        {
            _customer.Rentals.ForEach(rental => _sb.Append($"\t{rental.Movie.Title}\t{rental.GetCharge():£0.00}\n"));

            _sb.Append($"Amount owed is {_customer.GetTotalCharge():£0.00}\n");
            _sb.Append($"You earned {_customer.GetFrequentRenterPoints()} frequent renter points\n");
            
            return _sb.ToString();
        }
    }

    public class HtmlStatement : Customer.Statement
    {
        private readonly Customer _customer;
        private readonly StringBuilder _sb = new StringBuilder();
        
        public HtmlStatement(Customer customer) => _customer = customer;

        public void AddName(string name) 
            => _sb.Append($"<p>Rental Record for {name}</p>"); 
        
        public string Build()
        {
            _customer.Rentals.ForEach(rental => _sb.Append($"<p>{rental.Movie.Title} for {rental.GetCharge():£0.00}</p>"));

            _sb.Append($"<p>Amount owed is {_customer.GetTotalCharge():£0.00}</p>");
            _sb.Append($"<p>You earned {_customer.GetFrequentRenterPoints()} frequent renter points</p>");
            
            return _sb.ToString();
        }
    }
}
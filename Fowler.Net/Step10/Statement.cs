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

        public void AddRental(Rental rental)
            => _sb.Append(rental.ToStatement(new RentalStatement()));
        
        public string Build()
        {
            _sb.Append($"Amount owed is {_customer.GetTotalCharge():£0.00}\n");
            _sb.Append($"You earned {_customer.GetFrequentRenterPoints()} frequent renter points\n");
            
            return _sb.ToString();
        }

        private class RentalStatement : Rental.Statement
        {
            private readonly StringBuilder _sb = new StringBuilder();

            public void AddMovie(string title, decimal charge)
                => _sb.Append($"\t{title}\t{charge:£0.00}\n");

            public string Build() => _sb.ToString();
        }
    }

    public class HtmlStatement : Customer.Statement
    {
        private readonly Customer _customer;
        private readonly StringBuilder _sb = new StringBuilder();
        
        public HtmlStatement(Customer customer) => _customer = customer;

        public void AddName(string name) 
            => _sb.Append($"<p>Rental Record for {name}</p>"); 
        
        public void AddRental(Rental rental)
            => _sb.Append(rental.ToStatement(new RentalStatement()));

        public string Build()
        {
            _sb.Append($"<p>Amount owed is {_customer.GetTotalCharge():£0.00}</p>");
            _sb.Append($"<p>You earned {_customer.GetFrequentRenterPoints()} frequent renter points</p>");
            
            return _sb.ToString();
        }
        
        private class RentalStatement : Rental.Statement
        {
            private readonly StringBuilder _sb = new StringBuilder();

            public void AddMovie(string title, decimal charge)
                => _sb.Append($"<p>{title} for {charge:£0.00}</p>");

            public string Build() => _sb.ToString();
        }
    }
}
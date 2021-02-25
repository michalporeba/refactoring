using System.Text;

namespace Step11
{
    public class HtmlStatement : Customer.Statement
    {
        private readonly Customer _customer;
        private readonly StringBuilder _sb = new StringBuilder();
        
        public HtmlStatement(Customer customer) => _customer = customer;

        public void AddName(string name) 
            => _sb.Append($"<p>Rental Record for {name}</p>"); 
        
        public void AddRental(Rental rental)
            => _sb.Append(rental.ToStatement(new RentalStatement()));

        public void AddTotalCharge(decimal totalCharge)
            => _sb.Append($"<p>Amount owed is {totalCharge:£0.00}</p>");

        public void AddFrequentRenterPoints(int points)
            => _sb.Append($"<p>You earned {points} frequent renter points</p>");

        public string Build() => _sb.ToString();
        
        private class RentalStatement : Rental.Statement
        {
            private readonly StringBuilder _sb = new StringBuilder();

            public void AddMovie(Movie movie, int daysRented)
                => _sb.Append(movie.ToStatement(new MovieStatement(), daysRented));

            public string Build() => _sb.ToString();
        }

        private class MovieStatement : Movie.Statement
        {
            private readonly StringBuilder _sb = new StringBuilder();

            public void AddTitle(string title)
                => _sb.Append($"<p>{title}");

            public void AddCharge(decimal charge)
                => _sb.Append($" for {charge:£0.00}</p>");

            public string Build() => _sb.ToString();
        }
    }
}
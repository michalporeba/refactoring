using System.Text;

namespace Step10
{
    public class PlainTextStatement : Customer.Statement
    {
        private readonly Customer _customer;
        private readonly StringBuilder _sb = new StringBuilder();
        
        public PlainTextStatement(Customer customer) => _customer = customer;
        
        public void AddName(string name)
            => _sb.Append($"Rental Record for {name}\n");

        public void AddRental(Rental rental)
            => _sb.Append(rental.ToStatement(new RentalStatement()));

        public void AddTotalCharge(decimal totalCharge)
            => _sb.Append($"Amount owed is {totalCharge:£0.00}\n");

        public void AddFrequentRenterPoints(int points)
            => _sb.Append($"You earned {points} frequent renter points\n");

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
                => _sb.Append($"\t{title}");

            public void AddCharge(decimal charge)
                => _sb.Append($"\t{charge:£0.00}\n");

            public string Build() => _sb.ToString();
        }
    }
}
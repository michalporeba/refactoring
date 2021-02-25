namespace Step10
{
    public class Rental
    {
        public interface Statement
        {
            void AddMovie(string title, decimal charge);
            string Build();
        }
        
        public Movie Movie { get; }
        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public string ToStatement(Statement builder)
        {
            builder.AddMovie(Movie.Title, GetCharge());
            return builder.Build();
        }

        public decimal GetCharge()
            => Movie.GetCharge(DaysRented);

        public int GetFrequentRenterPoints()
            => Movie.GetFrequentRenterPoints(DaysRented);
    }
}
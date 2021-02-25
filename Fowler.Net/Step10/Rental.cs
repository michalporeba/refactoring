namespace Step10
{
    public class Rental
    {
        public interface Statement
        {
            void AddMovie(Movie movie, int daysRented);
            string Build();
        }
        
        public Movie Movie { get; }
        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        internal string ToStatement(Statement builder)
        {
            builder.AddMovie(Movie, DaysRented);
            return builder.Build();
        }

        internal decimal GetCharge()
            => Movie.GetCharge(DaysRented);

        internal int GetFrequentRenterPoints()
            => Movie.GetFrequentRenterPoints(DaysRented);
    }
}
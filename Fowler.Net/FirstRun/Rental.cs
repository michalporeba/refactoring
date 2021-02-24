namespace FirstRun
{
    public class Rental
    {
        public Movie Movie { get; private set; }
        public int DaysRented { get; private set; }

        public Rental(Movie movie, int daysRented)
        {
            this.Movie = movie;
            this.DaysRented = daysRented;
        }

        public decimal GetCharge()
            => this.Movie.GetCharge(DaysRented);

        public int GetFrequentRenterPoints()
            => this.Movie.GetFrequentRenterPoints(DaysRented);

        internal void ContributeTo(StatementBuilder builder)
        {
            //builder.
        }
    }
}
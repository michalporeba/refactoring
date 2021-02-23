namespace Step09
{
    public class Rental
    {
        public Movie Movie { get; }
        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public decimal GetCharge()
            => Movie.GetCharge(DaysRented);

        public int GetFrequentRenterPoints()
            => Movie.GetFrequentRenterPoints(DaysRented);
    }
}
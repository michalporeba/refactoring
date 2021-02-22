namespace Step06
{
    public class Rental
    {
        private Movie _movie;
        public Movie Movie => _movie;

        private int _daysRented;
        public int DaysRented => _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public decimal GetCharge()
            => Movie.GetCharge(DaysRented);

        public int GetFrequentRenterPoints()
            => Movie.GetFrequentRenterPoints(DaysRented);
    }
}
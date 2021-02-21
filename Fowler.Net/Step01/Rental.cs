namespace Step01
{
    public class Rental
    {
        private Movie _movie;
        public Movie Movie
        {
            get { return _movie; }
        }

        private int _daysRented;
        public int DaysRented
        {
            get { return _daysRented; }
        }

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
    }
}
namespace Step04
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
        {
            var result = 0m;
            switch (Movie.PriceCode)
            {
                case Movie.PriceCodes.Regular:
                    result += 2;
                    if (DaysRented > 2)
                        result += (DaysRented - 2) * 1.5m;
                    break;
                case Movie.PriceCodes.NewRelease:
                    result += DaysRented * 3;
                    break;
                case Movie.PriceCodes.Children:
                    result += 1.5m;
                    if (DaysRented > 3)
                        result += (DaysRented - 3) * 1.5m;
                    break;
            }

            return result;
        }

        public int GetFrequentRenterPoints()
        {
            if ((Movie.PriceCode == Movie.PriceCodes.NewRelease)
                && (DaysRented > 1))
                return 2;
            return 1;
        }
    }
}
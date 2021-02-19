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
        
        public double GetCharge()
        {
            double result = 0;
            switch (Movie.PriceCode)
            {
                case Movie.PriceCodes.Regular:
                    result += 2;
                    if (DaysRented > 2)
                        result += (DaysRented - 2) * 1.5;
                    break;
                case Movie.PriceCodes.NewRelease:
                    result += DaysRented * 3;
                    break;
                case Movie.PriceCodes.Childrens:
                    result += 1.5;
                    if (DaysRented > 3)
                        result += (DaysRented - 3) * 1.5;
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
namespace Step11
{
    public class Rental
    {
        public interface Statement
        {
            void AddMovie(Movie movie, int daysRented);
            string Build();
        }

        private readonly Movie _movie;
        private readonly int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        internal string ToStatement(Statement builder)
        {
            builder.AddMovie(_movie, _daysRented);
            return builder.Build();
        }

        internal decimal GetCharge()
            => _movie.GetCharge(_daysRented);

        internal int GetFrequentRenterPoints()
            => _movie.GetFrequentRenterPoints(_daysRented);
    }
}
namespace Step11
{
    internal class NewReleasePrice : Price
    {
        internal override Movie.PriceCodes GetPriceCode()
            => Movie.PriceCodes.NewRelease;
        
        internal override decimal GetCharge(int daysRented)
            => daysRented * 3;

        internal override int GetFrequentRenterPoints(int daysRented)
            => (daysRented > 1) ? 2 : 1;
    }
}
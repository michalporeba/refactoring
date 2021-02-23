namespace Step09
{
    internal abstract class Price
    {
        internal abstract Movie.PriceCodes GetPriceCode();
        internal abstract decimal GetCharge(int daysRented);

        internal virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}
namespace Step08
{
    internal class ChildrenPrice : Price
    {
        internal override Movie.PriceCodes GetPriceCode()
            => Movie.PriceCodes.Children;

        internal override decimal GetCharge(int daysRented)
        {
            var result = 1.5m;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5m;
            return result;
        }
    }
}
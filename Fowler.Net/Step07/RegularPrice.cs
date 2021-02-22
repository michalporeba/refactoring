namespace Step07
{
    internal class RegularPrice : Price
    {
        internal override Movie.PriceCodes GetPriceCode()
            => Movie.PriceCodes.Regular;
        
        internal override decimal GetCharge(int daysRented)
        {
            var result = 2m;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5m;
            return result;
        }
    }
}
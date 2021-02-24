namespace FirstRun
{
    internal abstract class Price
    {
        public abstract Movie.PriceCodes GetPriceCode();

        public abstract decimal GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    internal class ChildrensPrice : Price
    {
        public override Movie.PriceCodes GetPriceCode() => Movie.PriceCodes.Childrens;

        public override decimal GetCharge(int daysRented)
        {
            var result = 1.5m;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5m;
            return result;
        }
    }
    
    internal class NewReleasePrice : Price
    {
        public override Movie.PriceCodes GetPriceCode() => Movie.PriceCodes.NewRelease;
        public override decimal GetCharge(int daysRented)
        {
            return daysRented * 3.0m;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
    
    internal class RegularPrice : Price
    {
        public override Movie.PriceCodes GetPriceCode() => Movie.PriceCodes.Regular;
        public override decimal GetCharge(int daysRented)
        {
            var result = 2.0m;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5m;
            return result;
        }
    }
}
namespace FirstRun
{
    internal abstract class Price
    {
        public abstract Movie.PriceCodes GetPriceCode();

        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    internal class ChildrensPrice : Price
    {
        public override Movie.PriceCodes GetPriceCode() => Movie.PriceCodes.Childrens;

        public override double GetCharge(int daysRented)
        {
            var result = 1.5;
            if (daysRented > 3)
                result += (daysRented - 3) * 1.5;
            return result;
        }
    }
    
    internal class NewReleasePrice : Price
    {
        public override Movie.PriceCodes GetPriceCode() => Movie.PriceCodes.NewRelease;
        public override double GetCharge(int daysRented)
        {
            return daysRented * 3.0;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }
    
    internal class RegularPrice : Price
    {
        public override Movie.PriceCodes GetPriceCode() => Movie.PriceCodes.Regular;
        public override double GetCharge(int daysRented)
        {
            var result = 2.0;
            if (daysRented > 2)
                result += (daysRented - 2) * 1.5;
            return result;
        }
    }
}
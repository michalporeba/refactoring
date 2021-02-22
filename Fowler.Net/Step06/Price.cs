namespace Step06
{
    internal abstract class Price
    {
        internal abstract Movie.PriceCodes GetPriceCode();
    }

    internal class ChildrenPrice : Price
    {
        internal override Movie.PriceCodes GetPriceCode()
            => Movie.PriceCodes.Children;
    }

    internal class RegularPrice : Price
    {
        internal override Movie.PriceCodes GetPriceCode()
            => Movie.PriceCodes.Regular;
    }

    internal class NewReleasePrice : Price
    {
        internal override Movie.PriceCodes GetPriceCode()
            => Movie.PriceCodes.NewRelease;
    }
}
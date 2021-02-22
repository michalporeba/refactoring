using System;

namespace Step06
{
    public class Movie
    {
        public enum PriceCodes
        {
            Children,
            Regular,
            NewRelease
        }

        private string _title;
        public string Title => _title;

        private Price _price;
        public PriceCodes PriceCode => _price.GetPriceCode();

        public Movie(string title, PriceCodes priceCode)
        {
            _title = title;
            _price = PriceFor(priceCode);
        }
        
        public decimal GetCharge(int daysRented)
        {
            var result = 0m;
            switch (PriceCode)
            {
                case PriceCodes.Regular:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5m;
                    break;
                case PriceCodes.NewRelease:
                    result += daysRented * 3;
                    break;
                case PriceCodes.Children:
                    result += 1.5m;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5m;
                    break;
            }

            return result;
        }
        
        public int GetFrequentRenterPoints(int daysRented)
        {
            if ((PriceCode == PriceCodes.NewRelease)
                && (daysRented > 1))
                return 2;
            return 1;
        }

        private Price PriceFor(PriceCodes priceCode)
        {
            switch (priceCode)
            {
                case PriceCodes.Children: return new ChildrenPrice();
                case PriceCodes.Regular: return new RegularPrice();
                case PriceCodes.NewRelease: return new NewReleasePrice();
                default:
                    throw new ArgumentOutOfRangeException(nameof(priceCode), priceCode, null);
            }
        }
    }
}
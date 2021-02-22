using System;

namespace Step07
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
            => _price.GetCharge(daysRented);

        public int GetFrequentRenterPoints(int daysRented)
            => _price.GetFrequentRenterPoints(daysRented);

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
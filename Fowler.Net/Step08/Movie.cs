using System;

namespace Step08
{
    public class Movie
    {
        public enum PriceCodes
        {
            Children,
            Regular,
            NewRelease
        }

        public string Title { get; }

        private Price _price;
        public PriceCodes PriceCode
        {
            get => _price.GetPriceCode();
            set => _price = PriceFor(value);
        }

        public Movie(string title, PriceCodes priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }
        
        public decimal GetCharge(int daysRented)
            => _price.GetCharge(daysRented);

        public int GetFrequentRenterPoints(int daysRented)
            => _price.GetFrequentRenterPoints(daysRented);

        private static Price PriceFor(PriceCodes priceCode)
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
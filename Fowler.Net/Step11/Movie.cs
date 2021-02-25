using System;

namespace Step11
{
    public class Movie
    {
        public enum PriceCodes
        {
            Children,
            Regular,
            NewRelease
        }

        internal interface Statement
        {
            void AddTitle(string title);
            void AddCharge(decimal charge);
            string Build();
        }

        private readonly string _title;

        private Price _price;
        public PriceCodes PriceCode
        {
            get => _price.GetPriceCode();
            set => _price = PriceFor(value);
        }

        public Movie(string title, PriceCodes priceCode)
        {
            _title = title;
            PriceCode = priceCode;
        }

        internal string ToStatement(Statement builder, int daysRented)
        {
            builder.AddTitle(_title);
            builder.AddCharge(GetCharge(daysRented));
            return builder.Build();
        }
        
        internal decimal GetCharge(int daysRented)
            => _price.GetCharge(daysRented);

        internal int GetFrequentRenterPoints(int daysRented)
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
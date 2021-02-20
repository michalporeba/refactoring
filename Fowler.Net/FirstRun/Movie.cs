using System;

namespace FirstRun
{
    public class Movie
    {
        public enum PriceCodes
        {
            Childrens,
            Regular,
            NewRelease
        }

        private readonly Price _price;
        public string Title { get; private set; }
        
        public Movie(string title, PriceCodes priceCode)
        {
            this.Title = title;
             _price = GetPrice(priceCode);
        }

        public double GetCharge(int daysRented)
            => _price.GetCharge(daysRented);

        public int GetFrequentRenterPoints(int daysRented)
            => _price.GetFrequentRenterPoints(daysRented);
        
        private Price GetPrice(PriceCodes priceCode)
        {
            switch (priceCode)
            {
                case PriceCodes.Regular: return new RegularPrice();
                case PriceCodes.NewRelease: return new NewReleasePrice();
                case PriceCodes.Childrens: return new ChildrensPrice();
                default:
                    throw new ArgumentOutOfRangeException(nameof(priceCode), priceCode, null);
            }
        }

    }
}
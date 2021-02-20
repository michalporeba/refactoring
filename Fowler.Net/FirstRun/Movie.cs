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

        public string Title { get; private set; }

        private Price _price = new RegularPrice();

        public PriceCodes PriceCode
        {
            get => _price.GetPriceCode();
            private set
            {
                switch (value)
                {
                    case PriceCodes.Regular: 
                        _price = new RegularPrice();
                        break;
                    case PriceCodes.NewRelease:
                        _price = new NewReleasePrice();
                        break; 
                    case PriceCodes.Childrens: 
                        _price = new ChildrensPrice();
                        break;
                }
            }
        }

        public Movie(string title, PriceCodes priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }

        public double GetCharge(int daysRented)
            => _price.GetCharge(daysRented);

        public int GetFrequentRenterPoints(int daysRented)
            => _price.GetFrequentRenterPoints(daysRented);
    }
}
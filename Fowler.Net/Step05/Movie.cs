namespace Step05
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

        private PriceCodes _priceCode;
        public PriceCodes PriceCode => _priceCode;

        public Movie(string title, PriceCodes priceCode)
        {
            _title = title;
            _priceCode = priceCode;
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
    }
}
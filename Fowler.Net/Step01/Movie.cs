namespace Step01
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
        public string Title
        {
            get { return _title; }
        }

        private PriceCodes _priceCode;
        public PriceCodes PriceCode
        {
            get { return _priceCode; }
        }

        public Movie(string title, PriceCodes priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
    }
}
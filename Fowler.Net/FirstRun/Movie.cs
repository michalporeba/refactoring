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
        public PriceCodes PriceCode { get; set; }

        public Movie(string title, PriceCodes priceCode)
        {
            this.Title = title;
            this.PriceCode = priceCode;
        }
    }
}
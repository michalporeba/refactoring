using System.Collections.Generic;
using System.Text;

namespace FirstRun
{
    public class Experiment
    {
        class Customer
        {
            public interface StatementBuilder
            {
                void AddName(string name);
                void AddRental(Rental rental);
            }
            
            private readonly string _name;
            private readonly List<Rental> _rentals = new List<Rental>();
            public Customer(string name) => _name = name;
            public void AddRental(Rental rental) => _rentals.Add(rental);

            public void ToStatement(StatementBuilder builder)
            {
                builder.AddName(_name);
                _rentals.ForEach(rental => builder.AddRental(rental));
            }
        }

        class Rental
        {
            public interface StatementBuilder
            {
                void AddRental(int days);
                string Build();
            }
            
            private Movie _movie;
            private int _days;
            public Rental(int days, Movie movie)
            {
                _days = days;
                _movie = movie;
            }

            public string ToStatement(StatementBuilder builder)
            {
                builder.AddRental(_days);
                return builder.Build();
            }
        }

        class Movie
        {
            private readonly string _title;
            public Movie(string title) => _title = title;
        }

        class PlainBuilder : Customer.StatementBuilder
        {
            private StringBuilder sb = new StringBuilder();
            public void AddName(string name) => sb.AppendLine(name);
            public void AddRental(Rental rental) 
                => sb.Append(rental.ToStatement(new RentalBuilder()));

            public string Build() => sb.ToString();
            
            private class RentalBuilder : Rental.StatementBuilder
            {
                private StringBuilder sb = new StringBuilder();

                public void AddRental(int days)
                    => sb.AppendLine(days.ToString());

                public string Build() => sb.ToString();
            }
        }
        public string Do()
        {
            var customer = new Customer("CustomerName");
            customer.AddRental(new Rental(2, new Movie("Twin Town")));
            customer.AddRental(new Rental(3, new Movie("Tin Town")));
            
            var builder = new PlainBuilder();
            customer.ToStatement(builder);

            return builder.Build();
        }
    }
}
using System;
using FirstRun;

namespace Client
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var e = new Experiment();
            Console.WriteLine(e.Do());
            
            /*
             Console.WriteLine("A sample client our our library");
            
            var customer = new Customer("Michal Poreba");
            customer.AddRental(new Rental(new Movie("Octonauts", Movie.PriceCodes.Children), 5));
            customer.AddRental(new Rental(new Movie("Twin Town", Movie.PriceCodes.Regular), 3));
            
            Console.WriteLine(customer.GetStatement());
            */
        }
    }
}
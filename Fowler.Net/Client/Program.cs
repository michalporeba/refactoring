using System;
using Step01;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("A sample client our our library");
            
            var customer = new Customer("Michal Poreba");
            customer.AddRental(new Rental(new Movie("Octonauts", Movie.PriceCodes.Childrens), 5));
            customer.AddRental(new Rental(new Movie("Twin Town", Movie.PriceCodes.Regular), 3));
            
            Console.WriteLine(customer.GetStatement());
        }
    }
}
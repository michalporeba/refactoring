using System;
using NUnit.Framework;
using Step08;

namespace Tests
{
    public class CustomerShould
    {
        [TestCase(typeof(TestCustomerA), "Arthur Bowen")]
        [TestCase(typeof(TestCustomerB), "Ceri Davies")]
        public void ContainTheNameInStatment(Type customerType, string expectedName)
        {
            var customer = (Customer)Activator.CreateInstance(customerType);
            Assert.That(customer.GetStatement(), Contains.Substring(expectedName));
        }

        [TestCase(typeof(TestCustomerA), "Octonauts", 1.5)]
        [TestCase(typeof(TestCustomerA), "Twin Town", 3.5)]
        [TestCase(typeof(TestCustomerA), "New Thing", 21)]
        [TestCase(typeof(TestCustomerB), "Sali Mali", 4.5)]
        [TestCase(typeof(TestCustomerB), "Patagonia", 2)]
        public void HaveExpectedFilmsListed(Type customerType, string title, decimal charge)
        {
            var customer = (Customer)Activator.CreateInstance(customerType);
            var statement = customer.GetStatement();
            Assert.That(statement, Contains.Substring(title), "Title should be included in the statement");
            Assert.That(statement, Contains.Substring(charge.ToString("£0.00")), "Price should be included");
        }
        
        private class TestCustomerA : Customer
        {
            public TestCustomerA()
                : base("Arthur Bowen")
            {
                AddRental(new Rental(new Movie("Octonauts", Movie.PriceCodes.Children), 1));
                AddRental(new Rental(new Movie("Twin Town", Movie.PriceCodes.Regular), 3));
                AddRental(new Rental(new Movie("New Thing", Movie.PriceCodes.NewRelease), 7));
            }
        }
        
        private class TestCustomerB : Customer
        {
            public TestCustomerB()
                : base("Ceri Davies")
            {
                AddRental(new Rental(new Movie("Sali Mali", Movie.PriceCodes.Children), 5));
                AddRental(new Rental(new Movie("Patagonia", Movie.PriceCodes.Regular), 1));
            }
        }
    }
}
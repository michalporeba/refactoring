using System;
using NUnit.Framework;
using Step09;

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

        [TestCase(typeof(TestCustomerB))]
        public void HaveExactOutputString(Type customerType)
        {
            var customer = (Customer)Activator.CreateInstance(customerType);
            var expected = ((ITestCustomerWithOutcome) customer)?.ExpectedString;
            Assert.That(customer?.GetStatement(), Is.EqualTo(expected));
        }
        
        [TestCase(typeof(TestCustomerB))]
        public void HaveExactOutputHtml(Type customerType)
        {
            var customer = (Customer)Activator.CreateInstance(customerType);
            var expected = ((ITestCustomerWithOutcome) customer)?.ExpectedHtml;
            Assert.That(customer?.GetStatement(new HtmlStatement()), Is.EqualTo(expected));
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

        private interface ITestCustomerWithOutcome
        {
            string ExpectedString { get; }
            string ExpectedHtml { get; }
        }
        
        private class TestCustomerB : Customer, ITestCustomerWithOutcome
        {
            public string ExpectedString 
                => "Rental Record for Ceri Davies\n\tSali Mali\t£4.50\n\tPatagonia\t£2.00\nAmount owed is £6.50\nYou earned 2 frequent renter points\n";
            public string ExpectedHtml 
                => "<p>Rental Record for Ceri Davies</p><p>Sali Mali for £4.50</p><p>Patagonia for £2.00</p><p>Amount owed is £6.50</p><p>You earned 2 frequent renter points</p>";
            
            public TestCustomerB()
                : base("Ceri Davies")
            {
                AddRental(new Rental(new Movie("Sali Mali", Movie.PriceCodes.Children), 5));
                AddRental(new Rental(new Movie("Patagonia", Movie.PriceCodes.Regular), 1));
            }
        }
    }
}
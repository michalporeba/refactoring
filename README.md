# refactoring

I am starting this repository after a discussion about the Refactoring - Improving the Design of Existing Code book by Martin Fowler. The book is almost 22 years old by now, but I find it still very relevant and the techniques described there useful. But the example written in Java 1.1 is perhaps not very convincing. So I will try to update it and translate it to C# and see if can make it more convincing for 2021. However, only the code will be updated, not the example, so we are still going to look at video rental shop. 

The example is very simple and even after translation looks outdated. That is the purpose, we will improve the code as we follow the example, and perhaps move further. 

## Structure of the solution

The `Step00` contains the translated example. The `Tests` project contains simple NUnit tests to support the refactoring. Finally the `Client` project is a console application using the library, which will be useful when we look at what can be changed and what shouldn't when refactoring APIs. 

## First Half

### Step 01 - Variable types and strings 

First a quick modernisation, some variable types, some readonly properties and string interpolation

### Step 02 - Extract Method

`Customer.AmountFor`
`Customer.FrequentRenterPointsFor`

### Step 03 - Move Method

`Rental.GetCharge()`
`Rental.GetFrequentRenterPoints()`

### Step 04 - Replace Temp with Query

`thisAmount`
`frequentRenterPoints`
`totalAmount`

## GetHtmlStatement

At this point it would be possible, as in the original example, to easily createa new method to generate HTML statement.

```c#
public string GetHtmlStatement()
{
	var result = "<h1>Rentals for <em>" + Name + "</em></h1><p>" + Environment.NewLine;
	foreach (var rental in _rentals)
	{
		result += rental.Movie.Title + ": " + rental.GetCharge() + "<br>" + Environment.NewLine;
	}
	
	result += "</p><p>You owe <em>" + TotalCharge() + "</em></p>";
	result += "<p>You earned " + FrequentRenterPoints() + " frequent renter points</p>";

	return result;
}
```

However, I would like to continue improving my code a little bit longer before I look at how to extend the functionality. 

### Step 05 - Move Method - again

`Rental.GetCharge()` still has references to Movie, especially in the switch statement is supicious. 

Still there is some interaction, data is now passed from Rental to Movie (the `daysRented` parameter). This is preferable because type information tends to change more frequently, and this is what is driving the switch. 

### Step 06 - Replace Type COde with State

those new classes should be internal
is it a state or a strategy pattern? 

First, Replace Type Code with State/Strategy

switch statment must have throw new `ArgumentOutOfRange` which cannot be tested unless we introduce possiblity for a mistake
 
### Step 07 - Move, and replace conditional with Polymorphysm

Replace temp with query too

The test coverage drops down a little, showing that we are clearly exposing some properties which are not necessarily public in our desired implication. We cannot remove them without changing the API - that's something that goes beyond refactoring into 'earlier bad design'. 

Finally, we split the Price file.

### Step 08 - Final tidy up

Auto properties, string builder, `_rentals.ForEach()` instaed of a bigger loop

## The end of the original example. 

The original example ends here, we can simply add the GetHtmlStatement method. 

The code looks more complex already, but how does our future work with it looks? 

How difficult it would be? What would happen if we had to add GetJsonStatment, GetXmlStatement methods to it? What if we had to add more types of movies, or perhaps modify rules for a specific type? How would it look before? 

```c#
public string GetHtmlStatement()
{
	var sb = new StringBuilder($"<p>Rental Record for {Name}\n</p>");

	_rentals.ForEach(rental => sb.AppendLine($"<p>{rental.Movie.Title} for {rental.GetCharge():£0.00}</p>"));

	sb.AppendLine($"<p>Amount owed is {GetTotalCharge():£0.00}</p>");
	sb.AppendLine($"<p>You earned {GetFrequentRenterPoints()} frequent renter points</p>");
	
	return sb.ToString();
}
```

This is good if we consider changes to pricing model, but not for different outputs. 


## Quotes

Any fool can write code tha a computer can understand. Good programmers write code that humans can understand. 
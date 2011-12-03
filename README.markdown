CodeGuard
=========

A simple Guard and validator library made in c#.

Example of usage:
-----------------
	
	// --- using Guard.That(...) ---
	// Guard.That that will throw an exception, when some condition is not met

	public void SomeMethod(int arg1, int arg2)
	{
		// This line will throw an exception when the arg1 is less or equal to arg2
		Guard.That(() => arg1).IsGreaterThan(arg2);

		// This will check that arg1 is not null and that is in some range 1..100
		Guard.That(arg2).IsNotNull().IsInRange(1,100);

		// Several checks can be added.
		Guard.That(arg1).IsInRange(100,1000).IsEven().IsTrue(x => x > 50, "Must be over 500");

		// Do stuff
	}

	// --- using Validate.That(...) ---
	// Validate.That makes is possible to get a list of all error conditions

	public void OtherMethod(int arg1)
	{
		// Get a list of errors
		List<string> errors = Validate.That(() => arg1).IsNotNull().GetResult();
	}


Incomplete list of checks:
--------------------------

The following checks are available. But the best documentation is currently the tests.
New checks can easily be made by creating a extension method.

For object:

* Is<Type> 
* IsNotDefault 

For bool:

* IsTrue
* IsFalse

For class:

* IsNotNull

For IComparable (Int32, Double, String, Char, DateTime and other classes implementing the interface)

* IsEqual
* IsNotEqual
* IsGreatherThan
* IslessThan
* IsInRange

For int and long:

* IsOdd
* IsEven
* IsPrime

For string:

* IsNotEmpty
* IsNotNullOrEmpty
* StartsWith
* EndsWith
* Length
* Contains
* IsMatch

For IEnumerable:

* IsNotEmpty
* Length
* Conatins

For Guid:

* IsNotEmpty


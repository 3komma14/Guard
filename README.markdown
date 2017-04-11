CodeGuard
=========
![Build status](https://ci.appveyor.com/api/projects/status/ryogp49hiwp37hfr?svg=true) ![Test status](http://teststatusbadge.azurewebsites.net/api/status/vik_borisov/guard)

A simple Guard and validator library made in c#.
Library also available at NuGet.

Need more checks?? Please contribute or contact me.

Example of usage:
-----------------
	
	// --- using Guard.That(...) ---
	// Guard.That that will throw an exception, when some condition is not met

	public void SomeMethod(int arg1, int arg2)
	{
		// This will check that arg1 is not null and that is in some range 1..100
		Guard.That(arg2).IsNotNull().IsInRange(1,100);

		// Several checks can be added.
		Guard.That(arg1).IsInRange(100,1000).IsEven().IsTrue(x => x > 50, "Must be over 500");

		// Do stuff
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


Benchmarks of checks:
---------------------

|Check                   | Max. overhead |
|------------------------|---------------|
|*Enumerable*            |               |
| IsNotEmpty             | x1.75         |
| Length                 | x1.75         |
| Contains by value      | x1.1          |
| Contains by predicate  | x1.1          |
|*Array*                 |               |
| IsNotEmpty             | x8.6          |
| CountIs                | x8.9          |
|*Boolean*               |               |
| IsTrue                 | x5.4          |
| IsFalse                | x5.4          |
|*Collection*            |               |
| IsNotEmpty             | x3.5          |


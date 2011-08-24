CodeGuard
=========

A simple Guard library made in c#.

Example of usage:
-----------------

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


Incomplete list of checks:
--------------------------

The following checks are available. But the best documentation is currently the tests.
New checks can easily be made by creating a extension method.

* Is<Type> (object)
* IsTrue (bool)
* IsFalse (bool)
* IsNotNull (class)
* IsEqual (IComparable)
* IsGreatherThan (IComparable)
* IslessThan (IComparable)
* IsInRange (IComparable)
* IsOdd (int,long)
* IsEven (int,long)
* IsPrime (int,long)
* IsNotDefault (object)
* IsNotEmpty (string)
* IsNotNullOrEmpty (string)
* StartsWith (string>
* EndsWith (string)
* Length (string)
* Contains (string)
* IsMatch (string)


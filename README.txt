CodeGuard
---------------

A simple Guard library made in c#

Example of usage:

void SomeMethod(int arg1, int arg2)
{
	// This line will throw an exception when the arg1 is less or equal to arg2
	Guard.Check(() => arg1).IsGreaterThan(arg2);

	// This will check that arg1 is not null and that is in some range 1..100
	Guard.Check(() => arg2).IsNotNull().IsInRange(1,100);

	// Do stuff
}

The following checks are available. But the best documentation is currently the tests.

General:
Is<Type>
IsNotNull
IsNotDefault
IsTrue

String:
IsNotEmpty
IsNotNullOrEmpty

IComparable:
IsEqual
IsGreatherThan
IslessThan
IsInRange



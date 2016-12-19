#Working with tasks#

##Problem##
Write a program which simulates a car race. The program consists of two main classes:

A class which can return Randomized numbers in a synchronized manner.

```
#!c#

public sealed class SynchronizedRandomGenerator
{
	// Initialize the random number generator.
	// Instantiate a &quot;System.Random&quot; object internally to
	// generate
	// random numbers.

	public SynchronizedRandomGenerator(
	int minValue, int maxValue);
	// Use the &quot;Next(minValue, maxValue)&quot; method on
	// a &quot;System.Random&quot; object to get a random number
	// within the requested range.
	// Note that the &quot;System.Random&quot; object itself is not thread
	// safe.

	public int Next();
}

```

And an abstraction for a Race Car.


```
#!c#

public sealed class Car
{
	// Initialize the car with a random generator
	// and destination number of kilomteres required
	// to finish the race.

	public Car(int carId, SynchronizedRandomGenerator randomGenerator,int destKm);
	// A car should (in a loop):
	// 1. Generate a random number of kilometers
	// past by using the random generator.
	// 2. Sum the number of kilometers past,
	// and write an update to the console.
	// 3. Sleep for 10 milliseconds (Thread.Sleep(10)).
	// 4. Once the destination number of kilometers is
	// achieved - write the name of the car to the
	// console stating that it finished.
	// Note that this method should be executed on a dedicated
	// thread.
	public void Race();
}
```
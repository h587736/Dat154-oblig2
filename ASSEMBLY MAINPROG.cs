using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	public static void Main()
	{
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Star("Sun", 0.0046491),
			new Planet("Mercury", 0.3870989),
			new Planet("Venus", 0.723331),
			new Planet("Terra", 1),
			new Moon("The moon", 0.00257),
			//Task 2
            new DwarfPlanet("Pluto", 0.039482),
            new Comet("Anita cox's Comet", 6.2),
            new Asteroid("Ann al", 2.5),
            new AsteroidBelt("Main Belt", 2.7)
        };
		foreach (SpaceObject @obj in solarSystem)
		{
			obj.Draw();
		}
		Console.ReadLine();
	}
}

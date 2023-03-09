using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	public static void Main()
	{
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Star("Sun", 110852,0,0,0,"White"),
			new Planet("Mercury", 9212,0,0,0,"Slate gray"),
			new Planet("Venus", 17238,0,0,0,"Yellow-white"),
			new Planet("Terra", 23737,0,0,0,"Blue-green"),
			new Moon("The moon", 61,0,0,0,"off-white brown-gray"),
			//Task 2
            new DwarfPlanet("Pluto", 940,0,0,0,"white, tan and brownish-red"),
            new Comet("Anita cox's Comet", 500000,0,0,0,"Green"),
            new Asteroid("Ann al", 200000,0,0,0,"White"),
            new AsteroidBelt("Main Belt", 419354175,0,0,0,"Gray")
        };
		foreach (SpaceObject @obj in solarSystem)
		{
			obj.Draw();
		}
		Console.ReadLine();
	}
}

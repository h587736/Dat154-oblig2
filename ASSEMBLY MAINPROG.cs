using System;
using System.Collections.Generic;
using SpaceSim;

class Astronomy {
	public static void Main()
	{
		List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Star("Sun", 110852,0,695508,25,"White"),
			new Planet("Mercury", 9212,88,2440,59,"Slate gray"),
			new Planet("Venus", 17238,225,6052,243,"Yellow-white"),
			new Planet("Terra", 23737,365,6371,1,"Blue-green"),
			new Moon("The moon", 61,27,1737,27,"off-white brown-gray"),
			//Task 2
            new DwarfPlanet("Pluto", 940,248,1188,6,"white, tan and brownish-red"),
            new Comet("Anita cox's Comet", 500000,18250,1,0,"Green"),
            new Asteroid("Ann al", 200000,1228,3,0,"White"),
            new AsteroidBelt("Main Belt", 419354175,4,50,0,"Gray")
        };
		foreach (SpaceObject @obj in solarSystem)
		{
			obj.Draw();
		}
		Console.ReadLine();
	}
}

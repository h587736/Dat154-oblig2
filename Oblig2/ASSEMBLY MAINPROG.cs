﻿using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.Remoting;
using SpaceSim;

class Astronomy {
	public static void Main(String[] args)
	{
      
        List<SpaceObject> solarSystem = new List<SpaceObject>
		{
			new Star("The Sun", 0,0,695508,25,"White"),
			new Planet("Mercury", 0.387,88,2440,59,"Slate gray"),
            new Planet("Mars", 1.52,687,3390,1,"Red"),
            new Planet("Venus", 0.723,225,6052,243,"Yellow-white"),
			new Planet("Terra", 1,365,6371,1,"Blue-green"),
            new Planet("Jupiter", 5.2,12,69911,10,"Orange and white"),
            new Planet("Saturn", 9.54,10759,58232,0.45,"Pale gold"),
            new Planet("Uranus", 19.19,84,25362,0.74,"Pale blue"),
            new Planet("Neptune", 30.07,60190,24622,0.67,"Dep blue"),
            new Moon("The Moon", 0.00257, 27, 1737, 27, "off-white brown-gray"),
            new Moon("Phobos", 0.0000151, 0.31891, 11.1, 0.31891, "Gray"),
            new Moon("Deimos", 0.0000234, 1.263, 6.2, 1.263, "Reddish"),
            new Moon("Io", 0.00282, 1.769, 3643, 1.769, "Sulfur yellow"),
            new Moon("Europa", 0.00449, 3.551, 3122, 3.551, "Whitish"),
            new Moon("Ganymede", 0.00716, 7.155, 5262, 7.155, "Gray"),
            new Moon("Callisto", 0.01258, 16.689, 4820, 16.689, "Brown-gray"),
            new Moon("Mimas", 0.0000196, 0.942, 198, 0.942, "Gray"),
            new Moon("Enceladus", 0.000031, 1.37, 252, 1.37, "White"),
            new Moon("Tethys", 0.000051, 1.888, 1062, 1.888, "Gray"),
            new Moon("Dione", 0.000084, 2.736, 1123, 2.736, "White"),
            new Moon("Rhea", 0.000228, 4.518, 1529, 4.518, "White"),
            new Moon("Titan", 0.00817, 15.95, 5149, 15.95, "Orange-brown"),
            new Moon("Iapetus", 0.00287, 79.3215, 1436, 79.3215, "Two-tone"),
            new Moon("Miranda", 0.00000142, 1.413, 235, 1.413, "Gray"),
            new Moon("Ariel", 0.0000131, 2.52, 1158, 2.52, "Pale orange"),
            new Moon("Umbriel", 0.0000164, 4.144, 1170, 4.144, "Dark gray"),
            new Moon("Titania", 0.0000437, 8.706, 1577, 8.706, "Gray"),
            new Moon("Oberon", 0.0000527, 13.463, 1523, 13.463, "Gray"),
            new Moon("Triton", 0.00237, 5.87685, 2707, -5.87685, "Pink"),
            new Moon("Nereid", 0.0364, 360.136, 170, 360.136, "Dark gray"),
            new Moon("Proteus", 0.000112, 1.122, 420, 1.122, "Gray"),
            new DwarfPlanet("Pluto", 39.5,248,1188,6,"white, tan and brownish-red"),
            new DwarfPlanet("Ceres", 2.767,1682.5,590,9.07,"Brown-grey"),
            new DwarfPlanet("Haumea", 43.13,285.4,620,0.1625,"Gray wtih reddish tint"),
            new DwarfPlanet("Makemake", 45.791,113.187,715,22.5,"Reddish-brown"),
            new DwarfPlanet("Eris", 67.668,558.04,1163,1.079,"Brown"),
            new Comet("Anita cox's Comet", 500000,18250,1,0,"Green"),
            new Asteroid("Ann al", 200000,1228,3,0,"White"),
            new AsteroidBelt("Main Belt", 419354175,4,50,0,"Gray"),
            new AsteroidBelt("Kirkwood Gaps", 2.5, 218223748, 4, 50, "Gray"),
            new AsteroidBelt("Hungaria Group", 2.06, 143509583, 3.9, 11, "Gray"),
            new AsteroidBelt("Phocaea Group", 2.4, 265912905, 4.3, 20, "Gray"),
            new AsteroidBelt("Alinda Group", 2.5, 394738481, 5.5, 30, "Gray"),
            new AsteroidBelt("Griqua Group", 2.74, 362764778, 5.7, 30, "Gray"),
            new AsteroidBelt("Cybele Group", 3.3, 524804102, 7, 200, "Gray"),
            new AsteroidBelt("Hilda Group", 3.7, 590644063, 7.4, 200, "Gray"),
            new AsteroidBelt("Thule Group", 4.25, 928302812, 8.6, 100, "Gray"),
            new AsteroidBelt("Distant", 5.2, 1846162169, 11.9, 100, "Gray")

        };
        Console.Write("Enter time (days since time 0): ");
        int time = int.Parse(Console.ReadLine());
        Console.Write("Enter space object name (or leave blank for the sun): ");
        string objectName = Console.ReadLine();

        // Oppdaterer time i libraryet
        foreach (SpaceObject @obj in solarSystem)
        {
            obj.SetTime(time);
        }

        // Printer Solen og planeter når brukeren ikke gir input
        bool objectExists = false;
        if (string.IsNullOrEmpty(objectName))
        {
            foreach (SpaceObject @obj in solarSystem)
            { if (obj is Star) {
                    obj.Draw(); 
                    }
                if (obj is Planet)
                {
                    obj.Draw();
                }
            }
        }
        // Dersom det blir gitt input sjekker om dette matcher noe i listen
        else
        {
            foreach (SpaceObject @obj in solarSystem)
            {
                if (obj.GetName().Equals(objectName, StringComparison.OrdinalIgnoreCase))
                {
                    objectExists = true;
                    obj.Draw();
                }
            }
        }
        // Dersom objekt ikke er i listen får man error og programmet avslutter
        if (!objectExists)
        {
            Console.WriteLine("The object " + objectName + " does not exist in the solar system.");
        }
        Console.ReadLine();
	}
}
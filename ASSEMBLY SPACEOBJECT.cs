using SpaceSim;
using System;

namespace SpaceSim
{
    public class SpaceObject {

        protected String name;
        protected double OrbRadius;


    public SpaceObject(string name, double OrbRadius)
    {
        this.name = name;
        this.OrbRadius = OrbRadius; 
    }
    public virtual void Draw()
    {
        Console.WriteLine(name);
    }
}

public class Star : SpaceObject
{
    public Star(string name, double OrbRadius) : base(name, OrbRadius) { }
    public override void Draw()
    {
        Console.Write("Star: ");
        base.Draw();
    }
}

public class Planet : SpaceObject
{
    public Planet(string name, double OrbRadius) : base(name, OrbRadius) { }
    public override void Draw()
    {
        Console.Write("Planet: ");
        base.Draw();
    }
}

public class Moon : Planet
{
    public Moon(string name, double OrbRadius) : base(name, OrbRadius) { }

    public override void Draw()
    {
        Console.Write("Moon: ");
        base.Draw();
    }
}
    //Task 2
    public class Comet : SpaceObject
    {
        public Comet(string name, double OrbRadius) : base(name, OrbRadius) { }

        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(string name, double OrbRadius) : base(name, OrbRadius) { }

        public override void Draw()
        {
            Console.Write("Asteroid: ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(string name, double OrbRadius) : base(name, OrbRadius) { }

        public override void Draw()
        {
            Console.Write("Asteroid Belt: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(string name, double OrbRadius) : base(name, OrbRadius) { }

        public override void Draw()
        {
            Console.Write("Dwarf Planet: ");
            base.Draw();
        }
    }

}

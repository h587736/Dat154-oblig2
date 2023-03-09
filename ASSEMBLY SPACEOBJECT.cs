using SpaceSim;
using System;

namespace SpaceSim
{
    public class SpaceObject {

        protected String name;
    


    public SpaceObject(string name)
    {
        this.name = name;
    }
    public virtual void Draw()
    {
        Console.WriteLine(name);
    }
}

public class Star : SpaceObject
{
    public Star(string name) : base(name) { }
    public override void Draw()
    {
        Console.Write("Star: ");
        base.Draw();
    }
}

public class Planet : SpaceObject
{
    public Planet(string name) : base(name) { }
    public override void Draw()
    {
        Console.Write("Planet: ");
        base.Draw();
    }
}

public class Moon : Planet
{
    public Moon(string name) : base(name) { }

    public override void Draw()
    {
        Console.Write("Moon: ");
        base.Draw();
    }
}
    //Task 2
    public class Comet : SpaceObject
    {
        public Comet(string name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(string name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Asteroid: ");
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(string name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Asteroid Belt: ");
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(string name) : base(name) { }

        public override void Draw()
        {
            Console.Write("Dwarf Planet: ");
            base.Draw();
        }
    }

}

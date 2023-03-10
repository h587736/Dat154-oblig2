﻿using SpaceSim;
using System;

namespace SpaceSim
{
    public class SpaceObject {

        protected String name;
        protected double OrbRadius;
        protected double OrbPeriod;
        protected double ObjRadius;
        protected double RotPeriod;
        protected String ObjColor;
        protected double ObjPos =  0;

    public SpaceObject(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor)
        {
            this.name = name;
            this.OrbRadius = OrbRadius;
            this.OrbPeriod = OrbPeriod;
            this.ObjRadius = ObjRadius;
            this.RotPeriod = RotPeriod;
            this.ObjColor = ObjColor;
        }

        public virtual void PlanPos()
        {
            Console.WriteLine("Position of" + name + ": " + ObjPos);
        }

        public virtual void Draw()
    {
        Console.WriteLine(name 
            + "\n Orbital Radius in KM: " + OrbRadius 
            + "\n Orbital Period (Earh days): " + OrbPeriod
            + "\n Object Radius (Km): " + ObjRadius
            + "\n Rotational Period (Earth days): " + RotPeriod
            + "\n Object Color: " + ObjColor + "\n");
        }
}

public class Star : SpaceObject
{
    public Star(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }
    public override void Draw()
    {
        Console.Write("Star: ");
             base.Draw();
           
    }
}

public class Planet : SpaceObject
{
    public Planet(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }
        public override void Draw()
    {
        Console.Write("Planet: ");
             base.Draw();
            
        }
}

public class Moon : Planet
{
    public Moon(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }

    public override void Draw()
    {
        Console.Write("Moon: ");
            // base.Draw();
            base.Draw();
        }
}
    //Task 2
    public class Comet : SpaceObject
    {
        public Comet(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }

        public override void Draw()
        {
            Console.Write("Comet: ");
            // base.Draw();
            base.Draw();
        }
    }

    public class Asteroid : SpaceObject
    {
        public Asteroid(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }

        public override void Draw()
        {
            Console.Write("Asteroid: ");
            // base.Draw();
            base.Draw();
        }
    }

    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }

        public override void Draw()
        {
            Console.Write("Asteroid Belt: ");
            // base.Draw();
            base.Draw();
        }
    }

    public class DwarfPlanet : SpaceObject
    {
        public DwarfPlanet(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor) : base(name, OrbRadius, OrbPeriod, ObjRadius, RotPeriod, ObjColor) { }

        public override void Draw()
        {
            Console.Write("Dwarf Planet: ");
           // base.Draw();
            base.Draw();
        }
    }

}

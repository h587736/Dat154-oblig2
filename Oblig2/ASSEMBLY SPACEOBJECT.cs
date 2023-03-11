﻿using SpaceSim;
using System;

namespace SpaceSim
{
    public class SpaceObject {

        private String name;
        protected double OrbRadius;
        protected double OrbPeriod;
        protected double ObjRadius;
        protected double RotPeriod;
        protected String ObjColor;
        protected int time = 0;

        public string GetName()
        {
            return name;
        }
        public int GetTime()
        {
            return time;
        }

        public void SetTime(int time)
        {
            this.time = time;
        }

        public SpaceObject(string name, double OrbRadius, double OrbPeriod, double ObjRadius, double RotPeriod, String ObjColor)
        {
            this.name = name;
            this.OrbRadius = OrbRadius;
            this.OrbPeriod = OrbPeriod;
            this.ObjRadius = ObjRadius;
            this.RotPeriod = RotPeriod;
            this.ObjColor = ObjColor;
        }

        public double PlanPos(double time)
        {
            double angularVelocity = 2 * Math.PI / OrbPeriod;
            double angle = angularVelocity * time;
            double x = OrbRadius * Math.Cos(angle);
            double y = OrbRadius * Math.Sin(angle);
            return x;
        }

        public virtual void Draw()
    {
        Console.WriteLine(name 
            + "\n Orbital Radius in AU: " + OrbRadius 
            + "\n Orbital Period (Earh days): " + OrbPeriod
            + "\n Object Radius (Km): " + ObjRadius
            + "\n Rotational Period (Earth days): " + RotPeriod
            + "\n Object Color: " + ObjColor 
            + "\n Planet position: " + PlanPos(time)
            + "\n");
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
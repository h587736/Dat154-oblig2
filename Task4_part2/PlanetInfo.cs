using SpaceSim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_part2
{
    public partial class PlanetInfo : Form
    {
        public SpaceObject selectedPlanet;
        public PlanetInfo(SpaceObject planet)
        {
            InitializeComponent();
            this.selectedPlanet = planet;
            this.Text = planet.GetName();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            List<SpaceObject> solarSystem = Astronomy.solarSystem;
            this.ClientSize = new Size(900, 900);
            base.OnPaint(e);

            float pixelPerAU = 100f;
            float planetSize = (float)selectedPlanet.GetObjRadius() / 800;
            float planetDistance = (float)(selectedPlanet.GetOrbRadius() * pixelPerAU);
            float centerX = this.Width / 2;
            float centerY = this.Height / 2;
            Brush planetBrush = new SolidBrush(Color.FromName(selectedPlanet.GetObjColor()));
            e.Graphics.FillEllipse(planetBrush, centerX - planetSize, centerY - planetSize, planetSize * 2, planetSize * 2);

            // Display the planet's name
            Font nameFont = new Font(FontFamily.GenericSansSerif, 16);
            SizeF nameSize = e.Graphics.MeasureString(selectedPlanet.GetName(), nameFont);
            float nameX = centerX - nameSize.Width / 2;
            float nameY = centerY - planetSize - nameSize.Height;
            e.Graphics.DrawString(selectedPlanet.GetName(), nameFont, Brushes.White, nameX, nameY);

            List<Moon> moons = solarSystem.OfType<Moon>().Where(moon => moon.GetParent().Equals(selectedPlanet.GetName(), StringComparison.OrdinalIgnoreCase)).ToList();

            // Filter out moons that are too small or too far away
            moons = moons.Where(moon => moon.GetObjRadius() > 1 && moon.GetOrbRadius() <= selectedPlanet.GetOrbRadius() * 5).ToList();

            // Sort the moons by their orbital period
            moons.Sort((moon1, moon2) => moon1.GetOrbPeriod().CompareTo(moon2.GetOrbPeriod()));

            // Place the moons relative to the planet and each other
            double planetPosition = selectedPlanet.PlanPos(selectedPlanet.GetTime());
            double angleBetweenMoons = Math.PI * 2 / moons.Count;
            double moonAngle = 0;

            foreach (Moon moon in moons)
            {
                // calculate moon position
                double moonSize = moon.GetObjRadius();
                moonSize /= 400;
                double moonOrbitRadius = moon.GetOrbRadius();
                double planetOrbitRadius = selectedPlanet.GetOrbRadius();
                double orbitRadius = (planetOrbitRadius + moonOrbitRadius) * pixelPerAU;
                double moonPosition = selectedPlanet.PlanPos(selectedPlanet.GetTime());
                double orbitPosition = moon.PlanPos(selectedPlanet.GetTime());
                double moonX = centerX + (orbitRadius * Math.Cos(orbitPosition + planetPosition + moonAngle)) - planetDistance;
                double moonY = centerY + (orbitRadius * Math.Sin(orbitPosition + planetPosition + moonAngle));
                Brush moonBrush = new SolidBrush(Color.FromName(moon.GetObjColor()));
                if (moonSize < 1)
                {
                    moonSize = 1;
                }
                Console.WriteLine("moon size" + moonSize);
                Console.WriteLine("moon x" + moonX);
                Console.WriteLine("moon y" + moonY);
                e.Graphics.FillEllipse(moonBrush, (float)(moonX - moonSize), (float)(moonY - moonSize), (float)moonSize * 2, (float)moonSize * 2);

                // Display the moon's name
                SizeF moonNameSize = e.Graphics.MeasureString(moon.GetName(), nameFont);
                float moonNameX = (float)(moonX - moonNameSize.Width / 2);
                float moonNameY = (float)(moonY - moonSize - moonNameSize.Height);
                e.Graphics.DrawString(moon.GetName(), nameFont, Brushes.White, moonNameX, moonNameY);

                moonAngle += angleBetweenMoons;
            }
        }
        }
    }

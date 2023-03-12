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
            this.ClientSize = new Size(900, 700);
            base.OnPaint(e);

            float pixelPerAU = 100f;
            float planetSize = (float)selectedPlanet.GetObjRadius() / 500;
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

            // Sort the moons by their orbital period
            moons.Sort((moon1, moon2) => moon1.GetOrbPeriod().CompareTo(moon2.GetOrbPeriod()));

            // Place the moons relative to the planet and each other
            double planetPosition = selectedPlanet.PlanPos(selectedPlanet.GetTime());
            foreach (Moon moon in moons)
            {

                Console.WriteLine(moon.GetName());
                float moonDistance = (float)(moon.GetOrbRadius() * 2 * pixelPerAU);
                float moonSize = (float)moon.GetObjRadius() / 1000;
                double moonPosition = moon.PlanPos(selectedPlanet.GetTime());
                double moonX = centerX + planetDistance * Math.Cos(planetPosition) + moonDistance * Math.Cos(moonPosition - planetPosition);
                double moonY = centerY + planetDistance * Math.Sin(planetPosition) + moonDistance * Math.Sin(moonPosition - planetPosition);
                Console.WriteLine(moonDistance);
                Console.WriteLine(moonSize);
                Brush moonBrush = new SolidBrush(Color.FromName(moon.GetObjColor()));
                e.Graphics.FillEllipse(moonBrush, (float)(moonX - moonSize), (float)(moonY - moonSize), moonSize * 2, moonSize * 2);

                // Display the moon's name
                SizeF moonNameSize = e.Graphics.MeasureString(moon.GetName(), nameFont);
                float moonNameX = (float)(moonX - moonNameSize.Width / 2);
                float moonNameY = (float)(moonY - moonSize - moonNameSize.Height);
                e.Graphics.DrawString(moon.GetName(), nameFont, Brushes.White, moonNameX, moonNameY);
            }
        }
    }
}
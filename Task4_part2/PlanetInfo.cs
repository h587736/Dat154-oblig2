using SpaceSim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4_part2
{
    public partial class PlanetInfo : Form
    {
        public PlanetInfo()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            this.ClientSize = new Size(900, 700);
            base.OnPaint(e);
            List<SpaceObject> solarSystem = Astronomy.solarSystem;
            float centerX = this.Width / 2;
            float centerY = this.Height / 2;

            float sunRadius = 30;
            Brush sunBrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(sunBrush, centerX - sunRadius, centerY - sunRadius, sunRadius * 2, sunRadius * 2);

            if (obj is Planet planet)
            {
                float pixelPerAU = 100f;
                float planetDistance = (float)(planet.GetOrbRadius() * pixelPerAU);
                int planetSize = (int)(planet.GetObjRadius() / 500);


                float planetX = centerX + planetDistance * (float)Math.Cos(planet.PlanPos(planet.GetTime()));
                float planetY = centerY + planetDistance * (float)Math.Sin(planet.PlanPos(planet.GetTime()));
                Brush planetBrush = new SolidBrush(Color.FromName(planet.GetObjColor()));
                e.Graphics.FillEllipse(planetBrush, planetX - planetSize, planetY - planetSize, planetSize * 2, planetSize * 2);
            }
        }
        */
    }
}

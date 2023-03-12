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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Task4_part2
{
    public partial class Form1 : Form
    {
        int time = 0;
        public Form1()
        {
    
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            List<SpaceObject> solarSystem = Astronomy.solarSystem;

            float centerX = this.Width / 2;
            float centerY = this.Height / 2;

            float sunRadius = 30;
            Brush sunBrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(sunBrush, centerX - sunRadius, centerY - sunRadius, sunRadius * 2, sunRadius * 2);

            foreach (SpaceObject obj in solarSystem)
            {
                if (obj is Planet planet)
                {
                    float planetDistance = (float)(planet.GetOrbRadius() / 50);
                    int planetSize = (int)(planet.GetObjRadius() / 5000);
     

                    float planetX = centerX + planetDistance * (float)Math.Cos(planet.PlanPos(planet.GetTime()));
                    float planetY = centerY + planetDistance * (float)Math.Sin(planet.PlanPos(planet.GetTime()));
                    Brush planetBrush = new SolidBrush(Color.FromName(planet.GetObjColor()));
                    e.Graphics.FillEllipse(planetBrush, planetX - planetSize, planetY - planetSize, planetSize * 2, planetSize * 2);
                    Console.WriteLine(planetSize);
                }
            }
        }
    }
}
    


﻿using SpaceSim;
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
        public Form1()
        {
    
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
           
        }
        private void planetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string planetName = planetComboBox.SelectedItem.ToString();
            PlanetInfo planetInfoForm = new PlanetInfo(planetName);
            planetInfoForm.Show();
            this.Hide();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.ClientSize = new Size(900, 700);
            base.OnPaint(e);
            ComboBox planetComboBox = new ComboBox();
            List<string> planetNames = new List<string>()
{
    "Mercury", "Venus", "Terra", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"
};
            planetComboBox.Items.AddRange(planetNames.ToArray());
            planetComboBox.SelectedIndexChanged += new EventHandler(planetComboBox_SelectedIndexChanged);
            this.Controls.Add(planetComboBox);
            List<SpaceObject> solarSystem = Astronomy.solarSystem;

            float centerX = this.Width / 2;
            float centerY = this.Height / 2;

            float sunRadius = 30;
            Brush sunBrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(sunBrush, centerX - sunRadius, centerY - sunRadius, sunRadius * 2, sunRadius * 2);

            foreach (SpaceObject obj in solarSystem)
            {
                if (obj is Planet planet && !(obj is Moon))
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
        }
    }
}
    


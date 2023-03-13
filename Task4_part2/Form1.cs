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
        private SpaceSimulation simulation;
        public Form1()
        {
            InitializeComponent();
            simulation = new SpaceSimulation(Astronomy.solarSystem);
            simulation.StartSimulation();
            
            this.AutoScaleMode = AutoScaleMode.None;
         
        }
        private void planetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selectedPlanet = comboBox.SelectedItem.ToString();

            // Find the selected planet in the solar system
            SpaceObject selectedObj = Astronomy.solarSystem.Find(obj => obj.GetName() == selectedPlanet);

            // Create a new instance of the second form
            PlanetInfo form2 = new PlanetInfo(selectedObj);

            // Show the second form
            form2.Show();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.ClientSize = new Size(1200, 1000);
            base.OnPaint(e);
            // Dropdown box
            ComboBox planetComboBox = new ComboBox();
            List<string> planetNames = new List<string>()
{
    "Mercury", "Venus", "Terra", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"
};
            planetComboBox.Items.AddRange(planetNames.ToArray());
            planetComboBox.SelectedIndexChanged += new EventHandler(planetComboBox_SelectedIndexChanged);
            this.Controls.Add(planetComboBox);

            List<SpaceObject> solarSystem = Astronomy.solarSystem;

            // Creates  the sun with label
            float centerX = this.Width / 2;
            float centerY = this.Height / 2;
            float sunRadius = 30;
            Brush sunBrush = new SolidBrush(Color.Yellow);
            e.Graphics.FillEllipse(sunBrush, centerX - sunRadius, centerY - sunRadius, sunRadius * 2, sunRadius * 2);
            string sunLabel = "The Sun";
            Font sunFont = new Font("Arial", 10);
            Brush sunLabelBrush = new SolidBrush(Color.Black);
            SizeF sunLabelSize = e.Graphics.MeasureString(sunLabel, sunFont);   
            e.Graphics.DrawString(sunLabel,sunFont,sunLabelBrush,centerX - sunLabelSize.Width / 2, centerY + sunRadius);

            // Draws planets with labels
            foreach (SpaceObject obj in solarSystem)
            {
                if (obj is Planet planet && !(obj is Moon))
                {
                    float pixelPerAU = 150;
                    float planetDistance = (float)(planet.GetOrbRadius() * pixelPerAU);
                    int planetSize = (int)(planet.GetObjRadius() / 750);
     

                    float planetX = centerX + planetDistance * (float)Math.Cos(planet.PlanPos(planet.GetTime()));
                    float planetY = centerY + planetDistance * (float)Math.Sin(planet.PlanPos(planet.GetTime()));
                    Brush planetBrush = new SolidBrush(Color.FromName(planet.GetObjColor()));
                    e.Graphics.FillEllipse(planetBrush, planetX - planetSize, planetY - planetSize, planetSize * 2, planetSize * 2);

                    string planetLabel = planet.GetName();
                    Font labelFont = new Font("Arial", 10);
                    Brush labelBrush = new SolidBrush(Color.Black);
                    SizeF labelSize = e.Graphics.MeasureString(planetLabel, labelFont);
                    e.Graphics.DrawString(planetLabel, labelFont, labelBrush, planetX - labelSize.Width / 2, planetY + planetSize);
                }
            }

        }
    }
}
    


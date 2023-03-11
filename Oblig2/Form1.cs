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

namespace Oblig2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Brush b = new SolidBrush(Color.Yellow);

            g.FillEllipse(b, 100, 100, 100, 100);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCardCove
{
    public partial class Form1 : Form
    {

        Graphics g; //declare a graphics object called g
        Cards card = new Cards(); //create the object, planet1

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Planet class&#39;s DrawPlanet method to draw the image cards
            card.DrawCards(g);
        }
    }
}

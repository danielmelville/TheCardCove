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
                                  // declare space for an array of 7 objects called Cards 
        Cards[] card = new Cards[7];

        Random yspeed = new Random();


        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 7; i++)
            {
                int x = 10 + (i * 75);
                card[i] = new Cards(x);
            }

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
            //call the Card class' Drawcard method to draw the image cards
            for (int i = 0; i < 7; i++)
            {

                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = yspeed.Next(5, 20);
                card[i].y += rndmspeed;


                //call the  class's draw method to draw the images
                card[i].DrawCards(g);
            }

        }

        private void tmrCards_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                card[i].MoveCards();

                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (card[i].y >= panel1.Height)
                {
                    card[i].y = 30;
                }


            }
            panel1.Invalidate();//makes the paint event fire to redraw the panel
        }
    }
}

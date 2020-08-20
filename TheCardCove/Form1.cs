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
        King king = new King();
        bool left, right;
        string move;
        int score;
        int lives;


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
            king.DrawKing(g);
        }

        private void TmrKing_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                king.MoveKing(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                king.MoveKing(move);
            }

        }

        private void tmrCards_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
            {
                card[i].MoveCards();

                if (king.spaceRec.IntersectsWith(card[i].CardsRec))
                {
                    //reset planet[i] back to top of panel
                    card[i].y = 30; // set  y value of planetRec
                    lives -= 1;// lose a life
                    lblLives.Text = lives.ToString();// display number of lives
                    Checklives();
                }


                //if a planet reaches the bottom of the Game Area reposition it at the top
                if (card[i].y >= panel1.Height)
                {
                    score += 1;//update the score
                    lblScore.Text = score.ToString();// display score
                    card[i].y = 30;
                }


            }
            panel1.Invalidate();//makes the paint event fire to redraw the panel
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }

        }

        private void Checklives()
        {

            if (lives == 0)
            {
                tmrCards.Enabled = false; //disable tmrCards
                tmrKing.Enabled = false; //disable tmrKing
                MessageBox.Show("Game Over");
            }
        }

      

      

        private void mnuStart_Click(object sender, EventArgs e)
        {
            score = 0; //set score to 0
            lblScore.Text = score.ToString();
            lives = int.Parse(lblLives.Text);// pass lives entered from textbox to lives variable
            tmrCards.Enabled = true; //enable tmrCards
            tmrKing.Enabled = true; //enable tmrKing
        }

        private void mnuStop_Click(object sender, EventArgs e)
        {
            tmrCards.Enabled = false; //disable tmrCards
            tmrKing.Enabled = false; //disable tmrKing
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("instructions display here");
     //       txtName.Focus();

            tmrCards.Enabled = false; //disable tmrCards
            tmrKing.Enabled = false; //disable tmrKing
        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace TheCardCove
{
    public partial class Form1 : Form
    {

        Graphics g; //declare a graphics object called g
                    // declare space for an array of 7 objects called Cards 
        Cards[] card = new Cards[16];

        Random yspeed = new Random();
        Random xspeed = new Random();
        King king = new King();
        bool left, right, up, down;
        string move;
        int score;
        int lives;


        public Form1()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });

            for (int i = 0; i < 16; i++) //for all 16 cards
            {

                if (i < 4) //for the first four cards
                {
                    int x = 75 + (i * 150); //evenly space the cards, and stagger them against the cards on the oposite side
                    card[i] = new Cards(x, 10, 0, 1);
                }
                else if (i < 8) //for the next four cards
                {
                    int x = 25 + ((i - 4) * 150); //evenly space the cards, and stagger them against the cards on the oposite side
                    card[i] = new Cards(x, 300, 0, 1);
                }
                else if (i < 12) //for the next four cards
                {
                    int y = 25 + ((i - 8) * 100); //evenly space the cards, and stagger them against the cards on the oposite side
                    card[i] = new Cards(10, y, 1, 0);
                }
                else if (i < 16) //for the last four cards
                {
                    int y = 25 + ((i - 12) * 100); //evenly space the cards, and stagger them against the cards on the oposite side
                    card[i] = new Cards(600, y, 1, 0);
                }
            }

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Card class' Drawcard method to draw the image cards
            for (int i = 0; i < 4; i++) //where "i" is from 0 to 4
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((score / 5000) + 2) * yspeed.Next(1, 3); //make the average speed of thr cards increase as the score increases
                card[i].y += rndmspeed * card[i].ySpeed; //assign the speed to the cards

            }
            for (int i = 4; i < 8; i++) //where "i" is from 0 to 8
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((score / 5000) + 2) * yspeed.Next(1, 3); //make the speed of thr cards increase as the score increases
                card[i].y -= rndmspeed * card[i].ySpeed; //assign the speed to the cards
            }
            for (int i = 8; i < 12; i++) //where "i" is from 0 to 8
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((score / 5000) + 2) * xspeed.Next(1, 3); //make the speed of thr cards increase as the score increases
                card[i].x += rndmspeed * card[i].xSpeed; //assign the speed to the cards
            }
            for (int i = 12; i < 16; i++) //where "i" is from 0 to 8
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((score / 5000) + 2) * yspeed.Next(1, 3); //make the speed of thr cards increase as the score increases
                card[i].x -= rndmspeed * card[i].xSpeed; //assign the speed to the cards
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
            if (up)
            {
                move = "up";
                king.MoveKing(move);
            }
            if (down) // if left arrow key pressed
            {
                move = "down";
                king.MoveKing(move);
            }

        }


        private void tmrCards_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                // card[i].MoveCards();

                //if (king.spaceRec.IntersectsWith(card[i].CardsRec))
                //{
                //    Reset_Card();
                //    lives -= 1;// lose a life
                //    lblLives.Text = lives.ToString();// display number of lives
                //    Checklives();
                //}


                //if a card reaches the bottom of the Game Area reposition it at the top
                if (card[i].y >= panel1.Height)
                {
                    card[i].y = 25;
                }
                if (card[i].y <= 0)
                {
                    card[i].y = panel1.Height - 25;
                }
                if (card[i].x >= panel1.Width)
                {
                    card[i].x = 25;
                }
                if (card[i].x <= 0)
                {
                    card[i].x = panel1.Width - 25;
                }

                //    score += 1;//update the score
                //    lblScore.Text = score.ToString();// display score

            }





            panel1.Invalidate();//makes the paint event fire to redraw the panel
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }
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
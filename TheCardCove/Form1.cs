using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        Random yspeed = new Random(); //random variable called yspeed
        Random xspeed = new Random(); //random variable called xspeed
        King king = new King();
        bool left, right, up, down;
        string move;
        int score; //integer called score
        int progress; //integer called progress
        string binPath = Application.StartupPath + @"\highscores.txt"; //fetch highscores doccument
        List<Highscores> highScores = new List<Highscores>(); //declear list for highscores


        public void DisplayHighScores()
        {
            lstBoxName.Items.Clear(); //clear list of names
            lstBoxScore.Items.Clear(); //clear list of scores

            foreach (Highscores s in highScores)
            {
                lstBoxName.Items.Add(s.Name); //add list of names
                lstBoxScore.Items.Add(s.Score); //add list of scores

            }
        }

        private void ReadScores()
        {

            var reader = new StreamReader(binPath);
            // While the reader still has something to read, this code will execute.
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                // Split into the name and the score.
                var values = line.Split(','); //add a split between 2 lines
                highScores.Add(new Highscores(values[0], Int32.Parse(values[1])));
            }
            reader.Close();
        }


        public void SortHighScores()
        {
            highScores = highScores.OrderByDescending(hs => hs.Score).Take(10).ToList(); //sort list in decending order
        }

        public void SaveHighScores()
        {
            StringBuilder builder = new StringBuilder();
            foreach (Highscores score in highScores) //for each highscore
            {
                //{0} is for the Name, {1} is for the Score and {2} is for a new line
                builder.Append(string.Format("{0},{1}{2}", score.Name, score.Score, Environment.NewLine));
            }
            File.WriteAllText(binPath, builder.ToString());
            //Clear current lists
            lstBoxName.Items.Clear();
            lstBoxScore.Items.Clear();
            // ReadScores();
            // SortHighScores();
            DisplayHighScores();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int lowestScore = highScores[(highScores.Count - 1)].Score; //integer for lowest score

            if (int.Parse(lblProgress.Text) > lowestScore) //see if user made top 10
                {
                 highScores.Add(new Highscores(txtName.Text, int.Parse(lblProgress.Text)));
                 }
            SortHighScores();
            SaveHighScores();
            DisplayHighScores();
        }

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
                int rndmspeed = ((progress / 500) + 1) * yspeed.Next(1, 3); //make the average speed of the cards increase as the score increases
                card[i].y += rndmspeed * card[i].ySpeed; //assign the speed to the cards

            }
            for (int i = 4; i < 8; i++) //where "i" is from 0 to 8
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((progress / 500) + 1) * yspeed.Next(1, 3); //make the average speed of the cards increase as the score increases
                card[i].y -= rndmspeed * card[i].ySpeed; //assign the speed to the cards
            }
            for (int i = 8; i < 12; i++) //where "i" is from 0 to 8
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((progress / 500) + 1) * yspeed.Next(1, 3); //make the average speed of the cards increase as the score increases
                card[i].x += rndmspeed * card[i].xSpeed; //assign the speed to the cards
            }
            for (int i = 12; i < 16; i++) //where "i" is from 0 to 8
            {

                //call the card class's drawcard method to draw the images
                card[i].DrawCards(g);

                // generate a random number from 1 to 3 and put it in rndmspeed
                int rndmspeed = ((progress / 500) + 1) * yspeed.Next(1, 3); //make the average speed of the cards increase as the score increases
                card[i].x -= rndmspeed * card[i].xSpeed; //assign the speed to the cards
            }
            king.DrawKing(g);

        }


        private void TmrKing_Tick(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right"; //call "right"
                king.MoveKing(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left"; //call "left"
                king.MoveKing(move);
            }
            if (up)
            {
                move = "up"; //call "up"
                king.MoveKing(move);
            }
            if (down) // if left arrow key pressed
            {
                move = "down"; //call "down"
                king.MoveKing(move);
            }

        }


        private void tmrCards_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++) //for the first 4 cards
            {
                if (king.spaceRec.IntersectsWith(card[i].CardsRec))
                {
                    card[i].y = 25; //go to y=25
                    score -= ((progress / 5) + 1);// lose a point
                    lblScore.Text = score.ToString();// display score
                    Checkpoints();
                }
            }

            for (int i = 5; i < 8; i++) //for the next 4 cards
            {
                if (king.spaceRec.IntersectsWith(card[i].CardsRec))
                {
                    card[i].y = panel1.Height - 25; //go to 25 from the panel hight
                    score -= ((progress / 5) + 1);// lose a point
                    lblScore.Text = score.ToString();// display score
                    Checkpoints();
                }
            }

            for (int i = 9; i < 12; i++) //for the next 4 cards
            {
                if (king.spaceRec.IntersectsWith(card[i].CardsRec))
                {
                    card[i].x = 25; //go to x=25
                    score -= ((progress/5) + 1);// lose a point/s
                    lblScore.Text = score.ToString();// display score
                    Checkpoints();
                }
            }

            for (int i = 13; i < 16; i++) //for the finalk 4 cards
            {
                if (king.spaceRec.IntersectsWith(card[i].CardsRec))
                {
                    card[i].x = panel1.Width - 25; //go to 25 from the panel width
                    score -= ((progress / 5) + 1);// lose a point
                    lblScore.Text = score.ToString();// display score
                    Checkpoints();
                }
            }


            for (int i = 0; i < 16; i++) //for all cards

            {
                if (card[i].y >= panel1.Height) //if card gets to the end
                {
                    card[i].y = 25; //reset position
                    score += 1; //add a point
                    lblScore.Text = score.ToString(); // display number of points
                }
                if (card[i].y <= 0) //if card gets to the end
                {
                    card[i].y = panel1.Height - 25; //reset position
                    score += 1; //add a point
                    lblScore.Text = score.ToString(); // display number of points
                }
                if (card[i].x >= panel1.Width) //if card gets to the end
                {
                    card[i].x = 25; //reset position
                    score += 1; //add a point
                    lblScore.Text = score.ToString(); // display number of points
                }
                if (card[i].x <= 0) //if card gets to the end
                {
                    card[i].x = panel1.Width - 25; //reset position
                    score += 1; //add a point
                    lblScore.Text = score.ToString(); // display number of points
                }

            }

            panel1.Invalidate();//makes the paint event fire to redraw the panel
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e) //for when keys are pressed
        {
            if (e.KeyData == Keys.Left) { left = true; } //make "left" true when left key is pressed
            if (e.KeyData == Keys.Right) { right = true; } //make "right" true when right key is pressed
            if (e.KeyData == Keys.Up) { up = true; } //make "up" true when up key is pressed
            if (e.KeyData == Keys.Down) { down = true; } //make "down" true when down key is pressed
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; } //make "left" false when left key is released
            if (e.KeyData == Keys.Right) { right = false; } //make "right" false when right key is released
            if (e.KeyData == Keys.Up) { up = false; } //make "up" false when up key is released
            if (e.KeyData == Keys.Down) { down = false; } //make "down" false when down key is released
        }

        private void Checkpoints() //call method "Checkponits"
        {

            if (score <= 0) //if score goes below 0
            {
                lstBoxName.Enabled = true; //enable high score names
                lstBoxScore.Enabled = true; //enable high scores
                btnSave.Enabled = true; //enable save button
                tmrCards.Enabled = false; //disable tmrCards
                tmrKing.Enabled = false; //disable tmrKing
                tmrProgress.Enabled = false; //disable tmrProgress
                score = 0; //set score to 0
                lblScore.Text = score.ToString();
                int lowest_score = highScores[(highScores.Count - 1)].Score;

                if (int.Parse(lblScore.Text) < lowest_score) //if player makes top 10
                {
                    MessageBox.Show("Game Over, you lasted " + progress + " seconds!" + Environment.NewLine + "You have made the Top Ten! Well Done!"); //show messsage                  
                }
                else //if not
                {
                    MessageBox.Show("Game Over, you lasted " + progress + " seconds!" + Environment.NewLine + "Keep trying to make the top ten!"); //show messsage
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmrProgress_Tick(object sender, EventArgs e)
        {
            progress += 1; //add a point
            lblProgress.Text = progress.ToString();
            lblLiveLoss.Text = ((progress / 5) + 1).ToString();
        }

        private void mnuStart_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Equals("")) //if text box is empty
            {
                MessageBox.Show("You must enter a name before starting!");
            }
            else
            {
                score = 0; //set score to 0
                lblScore.Text = score.ToString();
                progress = 0;
                lblProgress.Text = progress.ToString();
                score = int.Parse(lblScore.Text);// pass score entered from textbox to score variable
                tmrCards.Enabled = true; //enable tmrCards
                tmrKing.Enabled = true; //enable tmrKing
                tmrProgress.Enabled = true; //enable tmrProgress
                txtName.Enabled = false; //disable textbox
            }
        }

        private void mnuPause_Click_1(object sender, EventArgs e)
        {
            tmrCards.Enabled = false; //disable tmrCards
            tmrKing.Enabled = false; //disable tmrKing
            tmrProgress.Enabled = false; //enable tmrProgress
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Move the arrow keys to rotate and move the king! \n You will gain one point every time a card reaches the end of the gamebboard." +
                "\n You lose points when you hit a card. \n The cards will get faster as the game goes on! \n Try to last as long as possible without dying to make it into the top 10!");
            //display instructions

            tmrCards.Enabled = false; //disable tmrCards
            tmrKing.Enabled = false; //disable tmrKing
            tmrProgress.Enabled = false; //disabe tmrProgress

            ReadScores();
            SortHighScores();
            DisplayHighScores();
        }



    }
}
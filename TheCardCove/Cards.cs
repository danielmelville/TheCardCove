﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Media;
using System.Reflection;

namespace TheCardCove
{
    class Cards
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the cards
        public Image card;//variable for the card's image
        public int xSpeed, ySpeed;
        public Rectangle CardsRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)) hi from ty!
        public Cards(int startx, int starty, int xspd, int yspd)
        {

            xSpeed = xspd; //set the "x" speeds to equal
            ySpeed = yspd; //set the "y" speeds to equal
            x = startx; //set the "x" postition to equal
            y = starty; //set the "x" postition to equal
            width = 20;
            height = 20;

            //planetImage contains the plane1.png image
            card = Image.FromFile("card.png");
            CardsRec = new Rectangle(x, y, width, height);
        }

        // Methods for the Cards class
        public void DrawCards(Graphics g)
        {
            CardsRec = new Rectangle(x, y, width, height);
            g.DrawImage(card, CardsRec);
        }

        public void MoveCards()
        {  
            CardsRec.Location = new Point(x, y);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TheCardCove
{
    class King
    {
        // declare fields to use in the class

        public int x, y, width, height;//variables for the rectangle
        public Image king;//variable for the planet's image

        public Rectangle spaceRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public King()
        {
            x = 200;
            y = 200;
            width = 40;
            height = 40;
            king = Image.FromFile("king.png");
            spaceRec = new Rectangle(x, y, width, height);
        }
        //methods
        public void DrawKing(Graphics g)
        {
            spaceRec = new Rectangle(x, y, width, height);
            g.DrawImage(king, spaceRec);
 
        }

    }
}
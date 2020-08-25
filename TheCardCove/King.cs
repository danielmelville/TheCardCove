using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Reflection;

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
        public void MoveKing(string move)
        {
            spaceRec.Location = new Point(x, y);

            if (move == "right")
            {
                if (spaceRec.Location.X > 650) // is spaceship within 50 of right side
                {

                    x = 650;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x += 5;
                    spaceRec.Location = new Point(x, y);
                }

            }

            if (move == "left")
            {
                if (spaceRec.Location.X < 10) // is spaceship within 10 of left side
                {

                    x = 10;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x -= 5;
                    spaceRec.Location = new Point(x, y);
                }


            }

            if (move == "right")
            {
                if (spaceRec.Location.X > 650) // is spaceship within 50 of right side
                {

                    x = 650;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x += 5;
                    spaceRec.Location = new Point(x, y);
                }

            }
            if (move == "up")
                 {
                if (spaceRec.Location.Y < 10) // is spaceship within 10 of top
                {

                    y = 10;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    y -= 5;
                    spaceRec.Location = new Point(x, y);
                }

                }

                if (move == "down")
                {
                    if (spaceRec.Location.Y > 300)
                    {

                        y = 300;
                        spaceRec.Location = new Point(x, y);
                    }
                    else
                    {
                        y += 5;
                        spaceRec.Location = new Point(x, y);
                    }

                }

          
        }
    }
}
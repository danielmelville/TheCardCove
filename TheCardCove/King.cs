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
        public int angle; //declare "angle" variable
        public Rectangle spaceRec;//variable for a rectangle to place our image in

        //Create a constructor (initialises the values of the fields)
        public King()
        {
            x = 200;
            y = 200;
            width = 40;
            height = 40;
            angle = 0;
            king = Image.FromFile("king.png");
            spaceRec = new Rectangle(x, y, width, height);
        }
        //methods
        public void DrawKing(Graphics g)
        {
            spaceRec = new Rectangle(x, y, width, height);
            float moveX = width / 2f + spaceRec.Left; //Set translation to center of image (legnth ways)
            float moveY = height / 2f + spaceRec.Top; //Set translation to center of image (hight ways)

            g.TranslateTransform(moveX, moveY); //move poiot of translation to the center of the image 
            g.RotateTransform(angle); //apply rotation around point of translation
            g.TranslateTransform(-moveX, -moveY); //move point of translation back
            g.DrawImage(king, spaceRec); //draw the image
        }
        public void MoveKing(string move)
        {
            spaceRec.Location = new Point(x, y);

            if (move == "right") //if the user presses the right arrow key
            {
                angle += 7; //add 7 to "angle"
                angle = angle % 360;
            }
            if (move == "left") //if the user presses the right arrow key
            {
                angle -= 7; //take 7 from "angle"
                if (angle < 0)
                {
                    angle += 360;
                }
            }



            if (move == "up")
                 {
                if (angle >= 0 && angle <= 90) //if the "angle" variable is from 0 to 90
                {
                    //right movement
                    x += Convert.ToInt32(5* Math.Sin(angle * Math.PI / 180));

                    //up movement
                    y -= Convert.ToInt32(5 * Math.Cos(angle * Math.PI / 180));

                }
                else if (angle >= 90 && 5 <= 180) //if the "angle" variable is from 90 to 180
                {
                    //up movement
                    y += Convert.ToInt32(5 * Math.Sin((angle - 90) * Math.PI / 180));

                    //right movement
                    x += Convert.ToInt32(5 * Math.Cos((angle - 90) * Math.PI / 180));
                }
                else if (angle >= 180 && angle <= 270) //if the "angle" variable is from 180 to 270
                {
                    //right movement
                    x -= Convert.ToInt32(5 * Math.Sin((angle - 180) * Math.PI / 180));

                    //up movement
                    y += Convert.ToInt32(5 * Math.Cos((angle - 180) * Math.PI / 180));
                }
                else if (angle >= 270 && angle <= 360) //if the "angle" variable is from 270 to 360
                {
                    //up movement
                    y -= Convert.ToInt32(5 * Math.Sin((angle - 270) * Math.PI / 180));

                    //right movement
                    x -= Convert.ToInt32(5 * Math.Cos((angle - 270) * Math.PI / 180));
                }



                spaceRec.Location = new Point(x, y);

            }

                if (move == "down")
                {
                if (angle >= 0 && angle <= 90) //if the "angle" variable is from 0 to 90
                {
                    //right movement
                    x -= Convert.ToInt32(5 * Math.Sin(angle * Math.PI / 180));

                    //up movement
                    y += Convert.ToInt32(5 * Math.Cos(angle * Math.PI / 180));

                }
                else if (angle >= 90 && angle <= 180) //if the "angle" variable is from 90 to 180
                {
                    //up movement
                    y -= Convert.ToInt32(5 * Math.Sin((angle - 90) * Math.PI / 180));

                    //right movement
                    x -= Convert.ToInt32(5 * Math.Cos((angle - 90) * Math.PI / 180));
                }
                else if (angle >= 180 && angle <= 270) //if the "angle" variable is from 180 to 270
                {
                    //right movement
                    x += Convert.ToInt32(5 * Math.Sin((angle - 180) * Math.PI / 180));

                    //up movement
                    y -= Convert.ToInt32(5 * Math.Cos((angle - 180) * Math.PI / 180));
                }
                else if (angle >= 270 && angle <= 360) //if the "angle" variable is from 270 to 360
                {
                    //up movement
                    y += Convert.ToInt32(5 * Math.Sin((angle - 270) * Math.PI / 180));

                    //right movement
                    x += Convert.ToInt32(5 * Math.Cos((angle - 270) * Math.PI / 180));
                }

            }

          
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TheCardCove
{
    class Dice
    {
        public int x, y, width, height;

        public double xSpeed, ySpeed;
        public Image dice;//variable for the missile's image
        public int missileRotated;
        public Rectangle diceRec;//variable for a rectangle to place our image in
        public Matrix matrixMissile; //matrix to enable us to rotate missile in the same angle as the king
        Point centreDice;

        // in the following constructor we pass in the values of spaceRec and the rotation angle of the king
        // this gives us the position of the spaceship which we can then use to place the
        // missile where the spaceship is located and at the correct angle
        public Dice(Rectangle diceRec, int angle)
        {
            // if (missileRotate > 360) { missileRotate -= 360; } //if rotation angle is greater than 360 (ie. 361) take away 360 (so it equals 1)
            // if (missileRotate < 0) { missileRotate += 360; }//if rotation angle is negative, make it positive
            width = 10;
            height = 20;
            dice = Image.FromFile("dice.png");
            diceRec = new Rectangle(x, y, width, height);
            xSpeed = 30 * (Math.Cos((angle - 90) * Math.PI / 180));
            ySpeed = 30 * (Math.Sin((angle + 90) * Math.PI / 180));
            x = diceRec.X + diceRec.Width / 2; // move missile to middle of spaceship
            y = diceRec.Y + diceRec.Height / 2;
            missileRotated = angle;

        }

        public void draw(Graphics g)
        {

            centreDice = new Point(x, y);
            matrixMissile = new Matrix();
            matrixMissile.RotateAt(missileRotated, centreDice);
            g.Transform = matrixMissile;
            g.DrawImage(dice, diceRec);

        }

        public void moveMissile(Graphics g)
        {
            x += (int)xSpeed;
            y -= (int)ySpeed;
            diceRec.Location = new Point(x, y);

        }
    }
}

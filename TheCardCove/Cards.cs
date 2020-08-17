using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Media;

namespace TheCardCove
{
    class Cards
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the cards
        public Image card;//variable for the card's image
        public Rectangle CardsRec;//variable for a rectangle to place our image in
        public int score;
        //Create a constructor (initialises the values of the fields)
        public Cards()
        {
            x = 10;
            y = 10;
            width = 20;
            height = 20;

            //planetImage contains the plane1.png image
            card = Image.FromFile("card.png");
            CardsRec = new Rectangle(x, y, width, height);
        }

        // Methods for the Cards class
        public void DrawCards(Graphics g)
        {
            g.DrawImage(card, CardsRec);
        }
    }
}

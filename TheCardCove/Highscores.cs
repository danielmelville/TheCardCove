using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCardCove
{
    class Highscores
    {
        //we create a Constructor with 2 overloads, 1 for the player's name and one for their score
        public Highscores(string name, int progress)
        {
            Name = name;
            Score = progress;
        }

        //set properties so we can access the name and score
        public string Name { get; set; }
        public int Score { get; set; }
    }
}

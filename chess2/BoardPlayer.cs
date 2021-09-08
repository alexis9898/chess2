using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    abstract class Player
    {
        public string Name;
        public string Color;
        public int NumberOfPlayer;
        public Player()
        {

        }
        public Player(string name,string color)
        {
            Name = name;
            Color = color;
        }

        public override string ToString()
        {
            return "name: " + Name + ", " + "color: " + Color;
        }
        public abstract void ThePlayerLOse();
        public abstract void FirstLocation(int[,] matrix);
        public abstract void GetdetailWhite();

        public abstract void GetdetailsBlack();


    }
}

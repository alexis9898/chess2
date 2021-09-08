using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    class Queen : Player
    {
        public override void FirstLocation(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (NumberOfPlayer == (int)ColorShape.WhiteQueen && i == 7 && (j == 3))
                        matrix[i, j] = (int)ColorShape.WhiteQueen;
                    if (NumberOfPlayer == (int)ColorShape.BlackQueen && i == 0 && (j == 3))
                        matrix[i, j] = (int)ColorShape.BlackQueen;
                }
            }
        }

        public override void GetdetailsBlack()
        {
            Name = ColorShape.BlackQueen.ToString(); ;
            Color = "black";
            NumberOfPlayer = (int)ColorShape.BlackQueen;
        }

        public override void GetdetailWhite()
        {
            Name = ColorShape.WhiteQueen.ToString();
            Color = "white";
            NumberOfPlayer = (int)ColorShape.WhiteQueen;
        }

        public static void move()
        {
            throw new NotImplementedException();
        }

        public override void ThePlayerLOse()
        {
            throw new NotImplementedException();
        }
    }
}

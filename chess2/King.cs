using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    class King : Player
    {
        public override void FirstLocation(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (NumberOfPlayer == (int)ColorShape.WhiteKing && i == 7 && (j == 4))
                        matrix[i, j] = (int)ColorShape.WhiteKing;
                    if (NumberOfPlayer == (int)ColorShape.BlackKing && i == 0 && (j == 4))
                        matrix[i, j] = (int)ColorShape.BlackKing;
                }
            }
        }

        public override void GetdetailsBlack()
        {
            Name = ColorShape.BlackKing.ToString();
            Color = "black";
            NumberOfPlayer = (int)ColorShape.BlackKing;
        }

        public override void GetdetailWhite()
        {
            Name = ColorShape.WhiteKing.ToString();
            Color = "white";
            NumberOfPlayer = (int)ColorShape.WhiteKing;
        }

        public static bool move(int[,] matrix, string user1, string user2)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");
            for (int y = 1; y <=1; y++)
            {
                if (i1 + y < 0 || i1 + y >= matrix.GetLength(0))
                    continue;
                for (int x = -1; x <= 1; x++)
                {
                    if (j1 + x < 0 || j1 + x >= matrix.GetLength(1) || (x==0 && y==0))
                        continue;
                    if (i1 + y == i2 && j1 + x == j2)
                        return true;
                }
            }
            return false;
        }

        public override void ThePlayerLOse()
        {
            throw new NotImplementedException();
        }
    }
}

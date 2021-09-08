using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    class Knight : Player
    {
        public override void FirstLocation(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (NumberOfPlayer == (int)ColorShape.WhiteKnight && i == 7 && (j == 2 || j == 5))
                        matrix[i, j] = (int)ColorShape.WhiteKnight;
                    if (NumberOfPlayer == (int)ColorShape.BlackKnight && i == 0 && (j == 2 || j == 5))
                        matrix[i, j] = (int)ColorShape.BlackKnight;
                }
            }
        }

        public override void GetdetailsBlack()
        {
            Color = "black";
            Name = ColorShape.BlackKnight.ToString();
            NumberOfPlayer = (int)ColorShape.BlackKnight;
        }

        public override void GetdetailWhite()
        {
            Name = ColorShape.WhiteKnight.ToString();
            Color = "white";
            NumberOfPlayer = (int)ColorShape.WhiteKnight;
        }

        public static bool move(int[,] matrix,string user1, string user2)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");
            for (int y = -2; y <= 2; y++)
            {
                if (i1 + y < 0 || i1 + y >= matrix.GetLength(0))
                    continue;
                for (int x =-2; x <= 2; x++)
                {
                    if (j1 + x < 0 || j1 + x >= matrix.GetLength(1))
                        continue;
                    if (y ==  x || y == - x || y == 0 || x == 0)
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

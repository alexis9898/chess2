using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    class Bishop : Player
    {
        public override void FirstLocation(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (NumberOfPlayer == (int)ColorShape.WhiteBishop && i == 7 && (j == 1 || j == 6))
                        matrix[i, j] = (int)ColorShape.WhiteBishop;
                    if (NumberOfPlayer == (int)ColorShape.BlackBishop && i == 0 && (j == 1 || j == 6))
                        matrix[i, j] = (int)ColorShape.BlackBishop;
                }
            }
        }

        public override void GetdetailsBlack()
        {
            Name = ColorShape.BlackBishop.ToString(); ;
            Color ="black";
            NumberOfPlayer = (int)ColorShape.BlackBishop;
        }

        public override void GetdetailWhite()
        {
            Name = ColorShape.WhiteBishop.ToString();
            Color = "white";
            NumberOfPlayer = (int)ColorShape.WhiteBishop;
        }

        public static bool move(int[,] matrix, string user1, string user2)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");
            for (int y = -matrix.GetLength(0)+1; y < matrix.GetLength(0); y++)
            {
                if (i1 + y < 0 || i1 + y >= matrix.GetLength(0))
                    continue;
                for (int x = -matrix.GetLength(1)+1; x < matrix.GetLength(1); x++)
                {
                    if (j1 + x < 0 || j1 + x >= matrix.GetLength(1) || (x==0 && y==0))
                        continue;
                    int addy = y > 0 ? -1 : 1;
                    int addx = x > 0 ? -1 : 1;
                    if (y==x || y==-x)
                    {
                        if (i1+y==i2 && j1+x==j2)
                        {
                            while (i1+y+addy!=i1 && j1+x+addx!=j1)
                            {
                                if (matrix[i1 + y + addy, j1 + x + addx] != 0)
                                    return false;
                                addy += y > 0 ? -1 : 1;
                                addx += x > 0 ? -1 : 1;
                            }
                            return true;
                        }
                    }
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

using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    class Simple: Player
    {
        public static bool move(int[,] matrix,string user1, string user2)
        {
            int j1 = int.Parse(user1[0]+""); //j=user1
            int i1 = int.Parse(user1[1] + ""); //i=user1
            int j2 = int.Parse(user2[0] + ""); //j=user2
            int i2 = int.Parse(user2[1] + ""); //i=user2
            int yy = 1;
            if (i1 == 1 || i1 == 6)
                yy = 2;
                
            for (int y=-yy ; y <= yy ; y++)
            {
                if (i1 + y < 0 || i1 + y >= matrix.GetLength(0))
                    continue;
                for (int x = -1; x <= 1; x++)
                {
                    if (j1 + x < 0 || j1 + x >= matrix.GetLength(0))
                        continue;
                    if ((matrix[i1,j1]/10==1 && (y==-yy || y==-1)) || ((matrix[i1, j1] / 10 == 2 && (y == yy || y==1)))) //white or black
                    {
                        if (x==0)
                        {
                            if (matrix[i1 + y, j1 + x] / 10 == 0)
                                if (i1 + y == i2 && j1 + x == j2)
                                    return true;
                        }
                        else
                        {
                            if (matrix[i1 + y, j1 + x] / 10 != 0 && matrix[i1 + y, j1 + x] / 10 != matrix[i1,j1]/10)
                                if (i1 + y == i2 && j1 + x == j2)
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

        public override void FirstLocation( int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (NumberOfPlayer==(int)ColorShape.WhiteSimple && i==6 )
                        matrix[i, j] = (int)ColorShape.WhiteSimple;
                    if (NumberOfPlayer == (int)ColorShape.BlackSimple && i == 1)
                        matrix[i, j] = (int)ColorShape.BlackSimple;
                    
                }
            }
        }
        public override void GetdetailWhite()
        {
            Name = ColorShape.WhiteSimple.ToString();
            Color = "white";
            NumberOfPlayer = (int)ColorShape.WhiteSimple;
        }
        public override void GetdetailsBlack()
        {
            Name = ColorShape.BlackSimple.ToString();
            Color = "black";
            NumberOfPlayer = (int)ColorShape.BlackSimple;
        }


    }
}

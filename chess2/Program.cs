using System;

namespace chess2
{
    enum ColorShape { Empty, WhiteSimple=11  , WhiteRook=12 , WhiteBishop=13 , WhiteKnight=14 , WhiteQueen=15, WhiteKing=16,
        BlackSimple =21 , BlackRook=22 , BlackBishop=23, BlackKnight=24, BlackQueen=25, BlackKing=26 }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[,] board = Board.InitBoard();
                Player[] player = new Player[32];
                for (int i = 0; i < player.Length; i++)
                {
                    if (i <= 15)
                    {
                        player[i] = new Simple();
                        if (i < 8)
                            player[i].GetdetailWhite();
                        if (i >= 8)
                            player[i].GetdetailsBlack();
                        player[i].FirstLocation(board);
                    }
                    if (i >= 16 && i <= 19)
                    {
                        player[i] = new Rook();
                        if (i <= 17)
                            player[i].GetdetailWhite();
                        else
                            player[i].GetdetailsBlack();
                        player[i].FirstLocation(board);
                    }
                    if (i >= 20 && i <= 23)
                    {
                        player[i] = new Bishop();
                        if (i <= 21)
                            player[i].GetdetailWhite();
                        else
                            player[i].GetdetailsBlack();
                        player[i].FirstLocation(board);
                    }
                    if (i >= 24 && i <= 27)
                    {
                        player[i] = new Knight();
                        if (i <= 25)
                            player[i].GetdetailWhite();
                        else
                            player[i].GetdetailsBlack();
                        player[i].FirstLocation(board);
                    }
                    if (i >= 28 && i <= 29)
                    {
                        player[i] = new Queen();
                        if (i == 28)
                            player[i].GetdetailWhite();
                        else
                            player[i].GetdetailsBlack();
                        player[i].FirstLocation(board);
                    }
                    if (i >= 30 && i <= 31)
                    {
                        player[i] = new King();
                        if (i <= 30)
                            player[i].GetdetailWhite();
                        else
                            player[i].GetdetailsBlack();
                        player[i].FirstLocation(board);
                    }
                }

                Console.WriteLine("If you want to castling press on the king and then on the rook");
                Console.WriteLine("if you want to leave press 0");
                Board.DrawBoard(board);
                string user1 = "";
                string user2 = "";
                int blackCounter = 0; //for castling
                int whiteCounter = 0;
                for (int i = 0; true; i++)
                {
                    while (i % 2 == 0) //white turn
                    {
                        Console.WriteLine("white player turn");
                        if (IfKingThreatened(board, 1))
                            Console.WriteLine("shah on white!!!");
                        stringToint(ref user1);
                        if (user1 == 0 + "")
                            break;
                        user1 = Location(user1);
                        if (IfYouBlack(UserToMatrix(board, user1)) || IfYouEmpty(UserToMatrix(board, user1)))
                        {
                            Console.WriteLine("choose only white player!");
                            continue;
                        }
                        Console.WriteLine("move to");
                        stringToint(ref user2);
                        user2 = Location(user2);
                        if (IfUserWantCastling(board, user1, user2))
                            if (IfYouCanDoCastling(board, user1, user2, whiteCounter))
                                DoCastling(board, user1, user2);
                        if (IfYouWhite(UserToMatrix(board, user2)))
                        {
                            Console.WriteLine("invalid number, try again");
                            continue;
                        }
                        if (PlayerMove(board, user1, user2, UserToMatrix(board, user1)) == false)
                        {
                            Console.WriteLine("invalid move, try again");
                            continue;
                        }
                        AddCounter(board, user1, ref whiteCounter);
                        DoEating(board, user1, user2);
                        break;

                    }
                    while (i % 2 == 1) //black turn
                    {
                        Console.WriteLine("black player turn");
                        if (IfKingThreatened(board, 2))
                            Console.WriteLine("shah on black!!!");
                        stringToint(ref user1);
                        if (user1 == 0 + "")
                            break;
                        user1 = Location(user1);
                        if (IfYouWhite(UserToMatrix(board, user1)) || IfYouEmpty(UserToMatrix(board, user1)))
                        {
                            Console.WriteLine("choose only black player!");
                            continue;
                        }
                        Console.WriteLine("move to");
                        stringToint(ref user2);
                        user2 = Location(user2);
                        if (IfUserWantCastling(board, user1, user2))
                            if (IfYouCanDoCastling(board, user1, user2, blackCounter))
                                DoCastling(board, user1, user2);
                        if (IfYouBlack(UserToMatrix(board, user2)))
                        {
                            Console.WriteLine("invalid number, try again");
                            continue;
                        }
                        if (PlayerMove(board, user1, user2, UserToMatrix(board, user1)) == false)
                        {
                            Console.WriteLine("invalid move, try again");
                            continue;
                        }
                        AddCounter(board, user1, ref blackCounter);
                        DoEating(board, user1, user2);
                        break;
                    }
                    Board.DrawBoard(board);
                    if (user1 == 0 + "")
                        break;
                    SimpleToQueen(board);
                    if (IfWinnerIs1(board) || IfWinnerIs2(board))
                    {
                        user1 = 0 +"";
                        break;
                    }
                }
                if(user1==0+"")
                {
                    Console.WriteLine("Do you want play again?");
                    string playagin = Console.ReadLine();
                    if (playagin == "yes")
                        continue;
                    else
                        break;
                }
            }


        }
        static void stringToint(ref string user)
        {
            bool Bdika = true; ;
            while (Bdika)
            {
                Console.WriteLine("choose number of column and number of row and press Enter");
                user = Console.ReadLine();
                if (user == "0")
                {
                    Bdika = false;
                    break;
                }
                if (user.Length != 2)
                {
                    Console.WriteLine("Try again");
                    Bdika = true;
                    continue;
                }
                for (int i = 0; i < user.Length; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (user[i] + "" == j + "")
                        {
                            Bdika = false;
                            break;
                        }
                        if (j == 8)
                            Bdika = true;
                    }
                    if (Bdika)
                        break;
                }
            }
        }
        static string Location(string user)
        {
            int j = int.Parse(user[0] + "");
            int i = int.Parse(user[1] + "");
            return ((j - 1) + "" + (i - 1));
        } //return ji
        static int UserToMatrix(int[,] matrix, string locationuser)
        {
            int j = int.Parse(locationuser[0] + "");
            int i = int.Parse(locationuser[1] + "");
            return matrix[i, j];
        }
        static void DoEating(int[,] matrix, string user1, string user2)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");
            matrix[i2, j2] = matrix[i1, j1];
            matrix[i1, j1] = (int)ColorShape.Empty;
        }
        static bool IfYouWhite(int matrixUser)
        {
            if (matrixUser / 10 == 1)
                return true;
            else
                return false;
        }
        static bool IfYouBlack(int matrixUser)
        {

            if (matrixUser / 10 == 2)
                return true;
            else
                return false;
        }
        static bool IfYouEmpty(int matrixUser)
        {
            if (matrixUser == 0)
                return true;
            else
                return false;
        }
        static bool PlayerMove(int[,] matrix, string user1, string user2, int UserMatrix1)
        {
            int player = UserMatrix1 % 10;
            if (player == 1)
                return Simple.move(matrix, user1, user2);
            if (player == 2)
                return Rook.move(matrix, user1, user2);
            if (player == 3)
                return Bishop.move(matrix, user1, user2);
            if (player == 4)
                return Knight.move(matrix, user1, user2);
            if (player == 5)
                return Rook.move(matrix, user1, user2) || Bishop.move(matrix, user1, user2);
            if (player == 6)
                return King.move(matrix, user1, user2);
            
            
                return false;
        }
        static void SimpleToQueen(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == 0 && matrix[i, j] == (int)ColorShape.WhiteSimple)
                        matrix[i, j] = (int)ColorShape.WhiteQueen;
                    if (i == matrix.GetLength(0)-1 && matrix[i, j] == (int)ColorShape.BlackSimple)
                        matrix[i, j] = (int)ColorShape.BlackQueen;
                }
            }
        }
        static bool IfWinnerIs1(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == (int)ColorShape.WhiteKing)
                        return false;
                }
            }
            Console.WriteLine("the winner is player2");
            return true;
        }
        static bool IfWinnerIs2(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == (int)ColorShape.BlackKing)
                        return false;
                }
            }
            Console.WriteLine("the winner is player1");
            return true;
        }
        static bool IfUserWantCastling(int[,] matrix, string user1, string user2)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");
            if (matrix[i1, j1] / 10 == matrix[i2, j2] / 10 && matrix[i1, j1] % 10 == 6 && matrix[i2, j2] % 10 == 2 )
                return true;
            else
                return false;
        }
        static bool IfYouCanDoCastling(int[,] matrix, string user1, string user2, int Counter) //check if no player between and if no move with the players
        {

            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");
            int x = j1 < j2 ? 1 : -1;
            if (((i1==0 && i2==0) || (i1==7 && i2==7)) && Counter==0)
            {
                while (j1 + x != j2)
                {
                    if (matrix[i1, j1 + x] != 0)
                        return false;
                    x += j1 < j2 ? 1 : -1;
                }
                return true;
            }
            return false;
        }
        static void DoCastling(int[,] matrix, string user1, string user2)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            int j2 = int.Parse(user2[0] + "");
            int i2 = int.Parse(user2[1] + "");

            if (j1-j2==4)
            {
                matrix[i1, j1 - 2] = matrix[i1, j1];
                matrix[i1, j1] = 0;
                matrix[i2, j2 + 3] = matrix[i2, j2];
                matrix[i2, j2] = 0;
            }
            if(j1-j2==-3)
            {
                matrix[i1, j1 + 2] = matrix[i1, j1];
                matrix[i1, j1] = 0;
                matrix[i2, j2 - 2] = matrix[i2, j2];
                matrix[i2, j2] = 0;
            }
        }
        static void AddCounter(int[,]matrix,string user1,ref int counter)
        {
            int j1 = int.Parse(user1[0] + "");
            int i1 = int.Parse(user1[1] + "");
            if (matrix[i1, j1] % 10 == 2 || matrix[i1, j1] % 10 == 6)
                counter++;
        }
        static string WherAreTheKing(int[,] matrix, int king)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == king)
                        return j + "" + i;
                }
            }
            return "";
        }
        static bool IfKingThreatened(int[,] matrix, int color)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j]/10 == 1 && color==2)
                    {
                        string anyplayer = j + "" + i;
                        if (PlayerMove(matrix, anyplayer, WherAreTheKing(matrix, (int)ColorShape.BlackKing), matrix[i, j]) == false)
                            continue;
                        return PlayerMove(matrix, anyplayer, WherAreTheKing(matrix, (int)ColorShape.BlackKing), matrix[i, j]);
                    }
                    if (matrix[i, j]/10 == 2 && color==1)
                    {
                        string anyplayer = j + "" + i;
                        if (PlayerMove(matrix, anyplayer, WherAreTheKing(matrix, (int)ColorShape.WhiteKing), matrix[i, j]) == false)
                            continue;
                        return PlayerMove(matrix, anyplayer, WherAreTheKing(matrix, (int)ColorShape.WhiteKing), matrix[i, j]);
                    }
                }
            }
            return false;
        }
    }

}

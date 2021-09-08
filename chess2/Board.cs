using System;
using System.Collections.Generic;
using System.Text;

namespace chess2
{
    class Board
    {
        //public static void Print(int[,] matrix)
        //{
        //for (int i = 0; i<matrix.GetLength(0); i++)
        //{
        //    for (int j = 0; j<matrix.GetLength(1); j++)
        //    {

        //    }
        //}
        //}
     
        
        public static  int[,] InitBoard()
        {
            int[,] matrix = new int[8, 8];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   matrix[i, j] = (int)ColorShape.Empty;

                }
            }
            return matrix;
        }

        public static void PrintBoard(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3}",matrix[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void PrintDrawBoard(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                Console.Write("{0,12}",i+1);
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,13}", matrix[i, j]);
                    if(j==matrix.GetLength(1)-1 && i%2==0)
                        Console.Write("   "+(i/2+1));
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void DrawBoard(int[,] matrix)
        {
            string[,] board = new string[matrix.GetLength(0) * 2 - 1, matrix.GetLength(1)];
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i%2==1)
                        board[i, j] = "------------";
                    else
                    {
                        switch (matrix[i/2,j])
                        {
                            case (int)ColorShape.Empty:
                                board[i, j] ="           |";
                                break;
                            case (int)ColorShape.WhiteSimple:
                                board[i, j] =  ColorShape.WhiteSimple.ToString()+"|";
                                break;
                            case (int)ColorShape.WhiteRook:
                                board[i, j] =ColorShape.WhiteRook.ToString() + "|";
                                break;
                            case (int)ColorShape.WhiteQueen:
                                board[i, j] =ColorShape.WhiteQueen.ToString() + "|";
                                break;
                            case (int)ColorShape.WhiteKnight:
                                board[i, j] = ColorShape.WhiteKnight.ToString() + "|";
                                break;
                            case (int)ColorShape.WhiteKing:
                                board[i, j] =ColorShape.WhiteKing.ToString() + "|";
                                break;
                            case (int)ColorShape.WhiteBishop:
                                board[i, j] = ColorShape.WhiteBishop.ToString() + "|";
                                break;
                            case (int)ColorShape.BlackSimple:
                                board[i, j] = ColorShape.BlackSimple.ToString() + "|";
                                break;
                            case (int)ColorShape.BlackRook:
                                board[i, j] = ColorShape.BlackRook.ToString() + "|";
                                break;
                            case (int)ColorShape.BlackQueen:
                                board[i, j] =  ColorShape.BlackQueen.ToString() + "|";
                                break;
                            case (int)ColorShape.BlackKnight:
                                board[i, j] =  ColorShape.BlackKnight.ToString() + "|";
                                break;
                            case (int)ColorShape.BlackKing:
                                board[i, j] =  ColorShape.BlackKing.ToString() + "|";
                                break;
                            case (int)ColorShape.BlackBishop:
                                board[i, j] =   ColorShape.BlackBishop.ToString() + "|";
                                break;
                        }
                    }
                    
                }
            }
            PrintDrawBoard(board);
        }
    }
}

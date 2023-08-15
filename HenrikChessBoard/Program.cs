using System;

namespace HenrikChessBoard
{
    internal class Program
    {
        // Definér enum for skakbrikker
        enum ChessPiece
        {
            Empty,
            BlackRook,
            BlackKnight,
            BlackBishop,
            BlackQueen,
            BlackKing,
            BlackPawn,
            WhiteRook,
            WhiteKnight,
            WhiteBishop,
            WhiteQueen,
            WhiteKing,
            WhitePawn
        }

        static void Main(string[] args)
        {
            int size = 8;
            int topMargin = 5;
            int sideMargin = (Console.WindowWidth - (size * 2)) / 2;

            ChessPiece[,] chessboard = CreateChessboardWithPieces(size);

            Draw(chessboard, topMargin, sideMargin);
        }

        static ChessPiece[,] CreateChessboardWithPieces(int size)
        {
            ChessPiece[,] chessboard = new ChessPiece[size, size];

            // Initialisér skakbrættet med tomme felter
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    chessboard[y, x] = ChessPiece.Empty;
                }
            }

            // Tilføj skakbrikker til det første hold (sorte brikker)
            chessboard[0, 0] = ChessPiece.BlackRook;
            chessboard[0, 1] = ChessPiece.BlackKnight;
            chessboard[0, 2] = ChessPiece.BlackBishop;
            chessboard[0, 3] = ChessPiece.BlackQueen;
            chessboard[0, 4] = ChessPiece.BlackKing;
            chessboard[0, 5] = ChessPiece.BlackBishop;
            chessboard[0, 6] = ChessPiece.BlackKnight;
            chessboard[0, 7] = ChessPiece.BlackRook;

            for (int x = 0; x < size; x++)
            {
                chessboard[1, x] = ChessPiece.BlackPawn;
            }

            // Tilføj skakbrikker til det andet hold (hvide brikker)
            chessboard[7, 0] = ChessPiece.WhiteRook;
            chessboard[7, 1] = ChessPiece.WhiteKnight;
            chessboard[7, 2] = ChessPiece.WhiteBishop;
            chessboard[7, 3] = ChessPiece.WhiteQueen;
            chessboard[7, 4] = ChessPiece.WhiteKing;
            chessboard[7, 5] = ChessPiece.WhiteBishop;
            chessboard[7, 6] = ChessPiece.WhiteKnight;
            chessboard[7, 7] = ChessPiece.WhiteRook;

            for (int x = 0; x < size; x++)
            {
                chessboard[6, x] = ChessPiece.WhitePawn;
            }

            return chessboard;
        }

        static void Draw(ChessPiece[,] chessboard, int topMargin, int sideMargin)
        {
            for (int i = 0; i < topMargin; i++)
            {
                Console.WriteLine();
            }

            int size = chessboard.GetLength(0);

            for (int y = 0; y < size; y++)
            {
                Console.Write(new string(' ', sideMargin));

                for (int x = 0; x < size; x++)
                {
                    if ((y + x) % 2 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    ChessPiece piece = chessboard[y, x];
                    Console.Write($" {GetPieceSymbol(piece)} ");
                }

                Console.ResetColor();
                Console.WriteLine();
            }
        }

        // Hjælpefunktion til at returnere symbol baseret på skakbrikken
        static string GetPieceSymbol(ChessPiece piece)
        {
            switch (piece)
            {
                case ChessPiece.BlackRook:
                    return "R";
                case ChessPiece.BlackKnight:
                    return "N";
                case ChessPiece.BlackBishop:
                    return "B";
                case ChessPiece.BlackQueen:
                    return "Q";
                case ChessPiece.BlackKing:
                    return "K";
                case ChessPiece.BlackPawn:
                    return "P";
                case ChessPiece.WhiteRook:
                    return "r";
                case ChessPiece.WhiteKnight:
                    return "n";
                case ChessPiece.WhiteBishop:
                    return "b";
                case ChessPiece.WhiteQueen:
                    return "q";
                case ChessPiece.WhiteKing:
                    return "k";
                case ChessPiece.WhitePawn:
                    return "p";
                default:
                    return " ";
            }
        }
    }
}

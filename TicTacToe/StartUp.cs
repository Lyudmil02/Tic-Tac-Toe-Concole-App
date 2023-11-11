using System;

namespace TicTacToe
{
    class StartUp
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                DrawBoard();
                int move = GetPlayerMove();
                board[move] = currentPlayer;

                if (CheckWin())
                {
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    gameEnded = true;
                }
                else if (CheckDraw())
                {
                    Console.WriteLine("It's a draw!");
                    gameEnded = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}   ");
            Console.WriteLine("     |     |      ");
        }

        static int GetPlayerMove()
        {
            int move = -1;
            bool validMove = false;

            while (!validMove)
            {
                Console.Write($"Player {currentPlayer}, enter your move (0-8): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out move) && move >= 0 && move < 9 && board[move] == ' ')
                {
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Invalid move. Please try again.");
                }
            }

            return move;
        }

        static bool CheckWin()
        {
            // Check rows
            for (int i = 0; i < 9; i += 3)
            {
                if (board[i] != ' ' && board[i] == board[i + 1] && board[i] == board[i + 2])
                {
                    return true;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                {
                    return true;
                }
            }

            // Check diagonals
            if (board[0] != ' ' && board[0] == board[4] && board[0] == board[8])
            {
                return true;
            }

            if (board[2] != ' ' && board[2] == board[4] && board[2] == board[6])
            {
                return true;
            }

            return false;
        }

        static bool CheckDraw()
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}


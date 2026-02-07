using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Game
    {
        public void Print(int[] board)
        {
            int count = 1;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] >= 0)
                {
                    Console.Write("." + "\t");
                }
                if (board[i] == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("X" + "\t");
                }
                if (board[i] == -2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("O" + "\t");
                }

                if (count % 3 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                count++;
                Console.ResetColor();
            }
        }

        // Conditions  - start

        // Conditions For Win - start
        public bool IsTheXWins(int i, int[] board, int[,] winningPositions)
        {
            bool winning = false;
            if (board[winningPositions[i, 0]] == -1 && board[winningPositions[i, 1]] == -1 && board[winningPositions[i, 2]] == -1)
            {
                winning = true;
            }

            return winning;
        }

        public bool IsTheOWins(int i, int[] board, int[,] winningPositions)
        {
            bool winning = false;
            if (board[winningPositions[i, 0]] == -2 && board[winningPositions[i, 1]] == -2 && board[winningPositions[i, 2]] == -2)
            {
                winning = true;
            }

            return winning;
        }
        // Conditions For Win - end

        // Conditions For O Logic - start
        public bool CanAttackToTheLastField(int i, int[] board, int[,] winningPositions)
        {
            bool t = false;
            if (board[winningPositions[i, 0]] == -2 && board[winningPositions[i, 1]] == -2 && board[winningPositions[i, 2]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanAttackToTheFirstField(int i, int[] board, int[,] winningPositions)
        {
            bool t = false;
            if (board[winningPositions[i, 1]] == -2 && board[winningPositions[i, 2]] == -2 && board[winningPositions[i, 0]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanAttackToTheMiddleField(int i, int[] board, int[,] winningPositions)
        {
            bool t = false;
            if (board[winningPositions[i, 0]] == -2 && board[winningPositions[i, 2]] == -2 && board[winningPositions[i, 1]] >= 0)
            {
                t = true;
            }

            return t;
        }


        public bool CanBeDefendedByTheLastField(int i, int[] board, int[,] winningPositions)
        {
            bool t = false;
            if (board[winningPositions[i, 0]] == -1 && board[winningPositions[i, 1]] == -1 && board[winningPositions[i, 2]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanBeDefendedByTheFirstField(int i, int[] board, int[,] winningPositions)
        {
            bool t = false;
            if (board[winningPositions[i, 1]] == -1 && board[winningPositions[i, 2]] == -1 && board[winningPositions[i, 0]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanBeDefendedByTheMiddleField(int i, int[] board, int[,] winningPositions)
        {
            bool t = false;
            if (board[winningPositions[i, 0]] == -1 && board[winningPositions[i, 2]] == -1 && board[winningPositions[i, 1]] >= 0)
            {
                t = true;
            }

            return t;
        }
        // Conditions For O Logic - end

        // Conditions - end

        public bool IsDraw(int[] board, int[,] winningPositions)
        {
            List<int> nullFields = new List<int>();
            bool will_win = false;
            int nullCount = 0;
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] >= 0)
                {
                    nullCount++;
                    nullFields.Add(i);
                }
            }

            if (nullCount == 0 || nullCount > 2)
            {
                will_win = true;
            }

            if (will_win == false)
            {
                if (nullCount == 2)
                {
                    board[nullFields[0]] = -1;
                    board[nullFields[1]] = -2;

                    for (int i = 0; i < 8; i++)
                    {
                        if (IsTheXWins(i, board, winningPositions))
                        {
                            will_win = true;
                            break;
                        }
                        else if (IsTheOWins(i, board, winningPositions))
                        {
                            will_win = true;
                            break;
                        }
                    }

                    if (will_win == false)
                    {
                        board[nullFields[0]] = -2;
                        board[nullFields[1]] = -1;

                        for (int i = 0; i < 8; i++)
                        {
                            if (IsTheXWins(i, board, winningPositions))
                            {
                                will_win = true;
                                break;
                            }
                            else if (IsTheOWins(i, board, winningPositions))
                            {
                                will_win = true;
                                break;
                            }
                        }
                    }

                    board[nullFields[0]] = nullFields[0];
                    board[nullFields[1]] = nullFields[1];
                }
            }

            if (will_win == false)
            {
                if (nullCount == 1)
                {
                    board[nullFields[0]] = -1;

                    for (int i = 0; i < 8; i++)
                    {
                        if (IsTheXWins(i, board, winningPositions))
                        {
                            will_win = true;
                            break;
                        }
                    }

                    board[nullFields[0]] = nullFields[0];
                }
            }

            bool isDraw = (will_win == true) ? false : true;

            return isDraw;
        }

        public (int[], bool winX) TurnX(int[] board, int[,] winningPositions, int input, bool winX)
        {
            board[input] = -1;

            for (int i = 0; i < 8; i++)
            {
                if (IsTheXWins(i, board, winningPositions))
                {
                    winX = true;
                    break;
                }
            }

            return (board, winX);
        }

        public (int[], bool winY) TurnO(int[] board, int[,] winningPositions, bool winX, bool winY)
        {
            // O logic - start
            if (winX == false)
            {
                bool isPlayed = false;
                bool attack = false;
                bool defend = false;
                for (int i = 0; i < 8; i++)
                {
                    if (CanAttackToTheLastField(i, board, winningPositions))
                    {
                        board[winningPositions[i, 2]] = -2;
                        winY = true;
                        attack = true;
                        isPlayed = true;
                        break;
                    }
                    if (CanAttackToTheFirstField(i, board, winningPositions))
                    {
                        board[winningPositions[i, 0]] = -2;
                        winY = true;
                        attack = true;
                        isPlayed = true;
                        break;
                    }
                    if (CanAttackToTheMiddleField(i, board, winningPositions))
                    {
                        board[winningPositions[i, 1]] = -2;
                        winY = true;
                        attack = true;
                        isPlayed = true;
                        break;
                    }
                }

                if (attack == false)
                {
                    if (defend == false)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (CanBeDefendedByTheLastField(i, board, winningPositions))
                            {
                                board[winningPositions[i, 2]] = -2;
                                isPlayed = true;
                                defend = true;
                                break;
                            }
                            if (CanBeDefendedByTheFirstField(i, board, winningPositions))
                            {
                                board[winningPositions[i, 0]] = -2;
                                isPlayed = true;
                                defend = true;
                                break;
                            }
                            if (CanBeDefendedByTheMiddleField(i, board, winningPositions))
                            {
                                board[winningPositions[i, 1]] = -2;
                                isPlayed = true;
                                defend = true;
                                break;
                            }
                        }
                    }

                    if (defend == false)
                    {
                        if (board[4] == -1 && board[8] > 0)
                        {
                            board[8] = -2;
                            isPlayed = true;
                        }
                        else if (board[4] > 0)
                        {
                            board[4] = -2;
                            isPlayed = true;
                        }
                    }
                }

                if (attack == false && defend == false && isPlayed == false && board[6] >= 0)
                {
                    if (board[1] == -1 && board[5] == -1)
                    {
                        board[2] = -2;
                    }
                    else
                    {
                        board[6] = -2;
                    }
                    isPlayed = true;
                }

                for (int i = 0; i < board.Length; i++)
                {
                    if (attack == false && defend == false && isPlayed == false && board[i] >= 0)
                    {
                        board[i] = -2;
                        isPlayed = true;
                        break;
                    }
                }
            }

            // O logic - end

            return (board, winY);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] board = new int[9];
            for (int i = 0; i < 9; i++)
            {
                board[i] = i;
            }

            Game game = new Game();

            int[,] winningPositions =
            {
                {0, 1, 2 },
                {3, 4, 5 },
                {6, 7, 8 },
                {0, 3, 6 },
                {1, 4, 7 },
                {2, 5, 8 },
                {0, 4, 8 },
                {6, 4, 2 }
            };

            bool winX = false;
            bool winY = false;
            bool isDraw = false;

            while (winX == false && winY == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("=====================");
                Console.WriteLine("=== X TicTacToe O ===");
                Console.WriteLine("=====================");
                Console.ResetColor();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This is your positions in numbers.");
                Console.WriteLine();
                Console.WriteLine("0 | 1 | 2");
                Console.WriteLine("--|---|---");
                Console.WriteLine("3 | 4 | 5");
                Console.WriteLine("--|---|---");
                Console.WriteLine("6 | 7 | 8");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("This is the board.");
                Console.WriteLine();
                game.Print(board);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Your turn!");
                Console.Write("> ");
                Console.ResetColor();
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    int input = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    Console.WriteLine();
                    if (input >= 0 && input < 9 && board[input] >= 0)
                    {
                        (board, winX) = game.TurnX(board, winningPositions, input, winX);
                        isDraw = game.IsDraw(board, winningPositions);
                        if (isDraw == false)
                        {
                            (board, winY) = game.TurnO(board, winningPositions, winX, winY);
                        }
                        isDraw = game.IsDraw(board, winningPositions);

                        game.Print(board);

                        if (isDraw == true)
                        {
                            break;
                        }
                    }
                }
                catch (Exception) { Console.Clear(); }
                ;
            }
            if (winX == true && winY == false && isDraw == false)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Great! You have WON the match!");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (winX == false && winY == true && isDraw == false)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Oo... You have lose the game.");
                Console.ResetColor();
                Console.WriteLine();
            }

            if (isDraw == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Draw!");
                Console.ResetColor();
            }
        }
    }
}
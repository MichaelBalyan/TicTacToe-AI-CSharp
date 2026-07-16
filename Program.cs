using System;
using System.Collections.Generic;

namespace TicTacToe
{
    class GameManagement
    {
        private bool winX = false;
        private bool winY = false;
        private bool draw = false;

        private int[,] winningPositions =
            {
                    {0, 1, 2},
                    {3, 4, 5},
                    {6, 7, 8},
                    {0, 3, 6},
                    {1, 4, 7},
                    {2, 5, 8},
                    {0, 4, 8},
                    {6, 4, 2}
            };

        private int[] board = new int[9];

        public int[] CreateBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = i;
            }
            return board;
        }

        public void Print(int[] board)
        {
            if (board == null)
            {
                throw new ArgumentNullException("board is null");
            }

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

        // Conditions for exceptions handling - start
    public void CheckExIndex(int i){
        if(i < 0 || i > 8){
            throw new IndexOutOfRangeException("index i is out of bounds");
        }
    }

    public void CheckExBoard(int[] board){
        if(board == null || board.Length == 0) {
            throw new ArgumentNullException("board is null");
        }
    }

    public void CheckExWinningPos(int[,] winningPositions){
        if(winningPositions == null || winningPositions.Length == 0) {
            throw new ArgumentNullException("winningPositions is null");
        }
    }

    public void CheckExInput(int input){
        if(input < 0 || input > 8) {
            throw new IndexOutOfRangeException("input is out of bounds");
        }
    }

    public void CheckExceptionsIndBW(int i, int[] board, int[,]winningPositions){
        CheckExIndex(i);
        CheckExBoard(board);
        CheckExWinningPos(winningPositions);
    }

    public void CheckExceptionsBW(int[] board, int[,] winningPositions){
        CheckExBoard(board);
        CheckExWinningPos(winningPositions);
    }

    public void CheckExceptionsBInpW(int[] board, int input, int[,] winningPositions){
        CheckExBoard(board);
        CheckExInput(input);
        CheckExWinningPos(winningPositions);
    }

    // Conditions for exceptions handling - end

        // Conditions For Win - start
        public bool IsTheXWins(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);
            bool winning = false;
            if (board[winningPositions[i, 0]] == -1 && board[winningPositions[i, 1]] == -1 && board[winningPositions[i, 2]] == -1)
            {
                winning = true;
            }

            return winning;
        }

        public bool IsTheOWins(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);
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
            CheckExceptionsIndBW(i, board, winningPositions);

            bool t = false;
            if (board[winningPositions[i, 0]] == -2 && board[winningPositions[i, 1]] == -2 && board[winningPositions[i, 2]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanAttackToTheFirstField(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);

            bool t = false;
            if (board[winningPositions[i, 1]] == -2 && board[winningPositions[i, 2]] == -2 && board[winningPositions[i, 0]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanAttackToTheMiddleField(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);

            bool t = false;
            if (board[winningPositions[i, 0]] == -2 && board[winningPositions[i, 2]] == -2 && board[winningPositions[i, 1]] >= 0)
            {
                t = true;
            }

            return t;
        }

        public bool CanBeDefendedByTheLastField(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);

            bool t = false;
            if (board[winningPositions[i, 0]] == -1 && board[winningPositions[i, 1]] == -1 && board[winningPositions[i, 2]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanBeDefendedByTheFirstField(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);

            bool t = false;
            if (board[winningPositions[i, 1]] == -1 && board[winningPositions[i, 2]] == -1 && board[winningPositions[i, 0]] >= 0)
            {
                t = true;
            }

            return t;
        }
        public bool CanBeDefendedByTheMiddleField(int i, int[] board, int[,] winningPositions)
        {
            CheckExceptionsIndBW(i, board, winningPositions);

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
            CheckExceptionsBW(board, winningPositions);

            List<int> nullFields = new List<int>();
            bool willWin = false;
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
                willWin = true;
            }

            if (!willWin)
            {
                if (nullCount == 2)
                {
                    board[nullFields[0]] = -1;
                    board[nullFields[1]] = -2;

                    for (int i = 0; i < 8; i++)
                    {
                        if (IsTheXWins(i, board, winningPositions))
                        {
                            willWin = true;
                            break;
                        }
                        else if (IsTheOWins(i, board, winningPositions))
                        {
                            willWin = true;
                            break;
                        }
                    }

                    if (!willWin)
                    {
                        board[nullFields[0]] = -2;
                        board[nullFields[1]] = -1;

                        for (int i = 0; i < 8; i++)
                        {
                            if (IsTheXWins(i, board, winningPositions))
                            {
                                willWin = true;
                                break;
                            }
                            else if (IsTheOWins(i, board, winningPositions))
                            {
                                willWin = true;
                                break;
                            }
                        }
                    }

                    board[nullFields[0]] = nullFields[0];
                    board[nullFields[1]] = nullFields[1];
                }
            }

            if (!willWin)
            {
                if (nullCount == 1)
                {
                    board[nullFields[0]] = -1;

                    for (int i = 0; i < 8; i++)
                    {
                        if (IsTheXWins(i, board, winningPositions))
                        {
                            willWin = true;
                            break;
                        }
                    }

                    board[nullFields[0]] = nullFields[0];
                }
            }

            if (willWin)
            {
                draw = false;
            }
            else
            {
                draw = true;
            }

            return draw;
        }

        public int[] TurnX(int[] board, int input, int[,] winningPositions)
        {
            CheckExceptionsBInpW(board, input, winningPositions);

            board[input] = -1;

            for (int i = 0; i < 8; i++)
            {
                if (IsTheXWins(i, board, winningPositions))
                {
                    winX = true;
                    break;
                }
            }

            return board;
        }

        public int[] TurnO(int[] board, int[,] winningPositions)
        {
            CheckExceptionsBW(board, winningPositions);

            // O logic - start
            if (!winX)
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

                if (!attack)
                {
                    if (!defend)
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

                    if (!defend)
                    {
                        if (board[4] == -1 && board[8] == 8)
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

                if (!attack && !defend && !isPlayed && ((board[0] == -1 && board[5] == -1) || (board[1] == -1 && board[8] == -1)))
                {
                    if (board[2] == 2)
                    {
                        board[2] = -2;
                    }
                    else if(board[1] == 1)
                    {
                        board[1] = -2;
                    }
                    isPlayed = true;
                }

                if(!attack && !defend && !isPlayed && (board[5] == -1 && board[6] == -1))
                {
                    if (board[8] == 8)
                    {
                        board[8] = -2;
                    }
                    else if (board[7] == 7)
                    {
                        board[7] = -2;
                    }
                    isPlayed = true;
                }

                if (!attack && !defend && !isPlayed)
                {
                    if ((board[0] == -1 && board[8] == -1) || (board[2] == -1 && board[6] == -1))
                    {
                        board[7] = -2;
                        defend = true;
                        isPlayed = true;
                    }
                }

                if (!attack && !defend && !isPlayed && board[6] == 6)
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

            return board;
        }

        public void PrintHeaderAndBoard()
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
            Print(board);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Your turn!");
            Console.Write("> ");
            Console.ResetColor();
        }

        public void Play()
        {
            while (winX == false && winY == false)
            {
                PrintHeaderAndBoard();

                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    int input = int.Parse(Console.ReadLine());
                    Console.ResetColor();
                    Console.WriteLine();
                    if (input >= 0 && input < 9 && board[input] >= 0)
                    {
                        board = TurnX(board, input, winningPositions);
                        IsDraw(board, winningPositions);
                        if (!draw)
                        {
                            board = TurnO(board, winningPositions);
                            if (winY)
                            {
                                Print(board);
                                break;
                            }
                        }
                        IsDraw(board, winningPositions);
                        Print(board);

                        if (draw)
                        {
                            break;
                        }
                    }
                }
                catch (Exception) { Console.Clear(); }

            }
        }

        public void CheckWinner()
        {

            if (winX && !winY && !draw)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Great! You have WON the match!");
                Console.ResetColor();
                Console.WriteLine();
            }
            else if (!winX && winY && !draw)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("Oo... You have lose the game.");
                Console.ResetColor();
                Console.WriteLine();
            }

            if (draw)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Draw!");
                Console.ResetColor();
            }
        }

        public void StartGame()
        {
            CreateBoard();
            Play();
            CheckWinner();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManagement gameManagement = new GameManagement();
            gameManagement.StartGame();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

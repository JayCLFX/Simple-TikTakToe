namespace TikTakToe
{
    public class Program
    {
        private static char[,] Game_Board = new char[3, 3];
        private static char current_Player = 'X';

        static void Main()
        {
            Console.WriteLine("Lets Play a game of Tik Tak Toe!\n\n\n");
            Thread.Sleep(1000);
            Console.Clear();

            InitializeBoardGame();
            bool gameOver = false;

            while (!gameOver)
            {
                DisplayBoard();
                int[] move = GetPlayerMove();
                MakeMove(move[0], move[1]);

                if (CheckWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"Player {current_Player} wins!");
                    gameOver = true;
                }
                else if (CheckDraw())
                {
                    DisplayBoard();
                    Console.WriteLine("It's a draw!");
                    gameOver = true;
                }

                SwitchPlayer();
            }
        }

        static void InitializeBoardGame()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Game_Board[row, col] = '-';
                }
            }
        }

        static void DisplayBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(Game_Board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[] GetPlayerMove()
        {
            Console.WriteLine($"Player {current_Player}'s turn. Enter row and column (e.g., '0 1'):");
            string[] input = Console.ReadLine().Split(' ');
            int[] move = Array.ConvertAll(input, int.Parse);
            return move;
        }

        static void MakeMove(int row, int col)
        {
            if (Game_Board[row, col] == '-')
            {
                Game_Board[row, col] = current_Player;
            }
            else
            {
                Console.WriteLine("Invalid Move Try again!");
                int[] move = GetPlayerMove();
                MakeMove(move[0], move[1]);
            }
        }

        static bool CheckWin()
        {
            return CheckRows() || CheckColumns() || CheckDiagonals();
        }

        static bool CheckRows()
        {
            for (int row = 0; row < 3; row++)
            {
                if (Game_Board[row, 0] != '-' && Game_Board[row, 0] == Game_Board[row, 1] && Game_Board[row, 1] == Game_Board[row, 2])
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckColumns()
        {
            for (int col = 0; col < 3; col++)
            {
                if (Game_Board[0, col] != '-' && Game_Board[0, col] == Game_Board[1, col] && Game_Board[1, col] == Game_Board[2, col])
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckDiagonals()
        {
            return (Game_Board[0, 0] != '-' && Game_Board[0, 0] == Game_Board[1, 1] && Game_Board[1, 1] == Game_Board[2, 2])
                || (Game_Board[0, 2] != '-' && Game_Board[0, 2] == Game_Board[1, 1] && Game_Board[1, 1] == Game_Board[2, 0]);
        }

        static bool CheckDraw()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Game_Board[row, col] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void SwitchPlayer()
        {
            current_Player = (current_Player == 'X') ? 'O' : 'X';
        }
    }
}

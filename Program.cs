using System;

namespace OOP
{
    internal class Program
    {
        public static bool CheckWinner(ref char[,] grid, char token)
        {
            for(int i = 0; i < 3; i++)
            {
                if (grid[i, 0] != '-' & grid[i,0] == token & grid[i, 0] == grid[i, 1] & grid[i, 0] == grid[i, 2])
                    return true;
                else if (grid[0, i] != '-' & grid[0, i] == token & grid[0, i] == grid[1, i] & grid[0, i] == grid[2, i])
                    return true;               
            }
            if (grid[0, 0] != '-' & grid[0, 0] == token & grid[0, 0] == grid[1, 1] & grid[0, 0] == grid[2, 2])
                return true;
            else if (grid[0, 2] != '-' & grid[0, 2] == token & grid[0, 2] == grid[1, 1] & grid[0, 2] == grid[2, 0])
                return true;
            else
                return false;
        }
        public static void UserMove(ref char[,] grid, ref int row, ref int col)
        {
            bool validInput = false;
            int count = 0;

            while (!validInput)
            {
                do {
                    if (count == 1) 
                        Console.WriteLine(" \n Invalid Input! Try Again! \n");
                    count = 1;
                    Console.Write("Enter your row(1-3): ");
                    row = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Write("Enter your column(1-3): ");
                    col = Convert.ToInt32(Console.ReadLine()) - 1;

                } while (!(row < 3 & col < 3)) ;

                if ((row < 3 & col < 3) & grid[row, col] == '-')
                {
                    grid[row, col] = 'X';
                    validInput = true;
                }
            } 
        }

        public static void ComputerMove(ref char[,] grid, ref int crow, ref int ccol)
        {
            Random r = new Random();
            bool validInput = false;

            while(validInput != true)
            {
                crow = r.Next(3);
                ccol = r.Next(3);
                if (grid[crow, ccol] == '-' )
                {
                    grid[crow, ccol] = 'O';
                    validInput = true;
                }
            }
        }

        public static void PrintGrid(ref char[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(" " + grid[i, j] + " |");
                }

                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("-------------");
            }
            Console.WriteLine("\n\n");
        }
        static void Main(string[] args)
        {
            string playAgain = "n";
            do
            {
                bool winner = false;
                int row = 4, col = 4, counter = 0;
                char[,] grid = {    { '-', '-', '-' },
                                    { '-', '-', '-' },
                                    { '-', '-', '-' }
                         };
                while (winner != true && (counter < 5))
                {
                    UserMove(ref grid, ref row, ref col);
                    Console.WriteLine("");
                    if (CheckWinner(ref grid, 'X') == true)
                    {
                        PrintGrid(ref grid);
                        Console.WriteLine("Congrats you Won! \n");
                        winner = true;
                        
                        break;
                    }
                    if (counter <= 3)
                        ComputerMove(ref grid, ref row, ref col);
                    if (CheckWinner(ref grid, 'O') == true)
                    {
                        PrintGrid(ref grid);
                        Console.WriteLine("Better luck next time! Computer Wins!");
                        winner = true;
                        break;
                    }
                    PrintGrid(ref grid);
                    counter++;
                    if(counter == 5)
                    {
                        Console.WriteLine("Draw!");
                    }
                }
                Console.Write("\n\nDo you want to play again? (y/n):");
                playAgain = Console.ReadLine();
            } while (playAgain != "n");

            if (playAgain == "n") Console.WriteLine("Thanks for Playing!");

        }   
    }

    
}
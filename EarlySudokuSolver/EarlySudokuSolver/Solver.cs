using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySudokuSolver
{
    class Solver
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);
              
            Console.WriteLine("   _____ _    _ _____   ____  _  ____   __   _____  ____  _ __      ________ _____");
            Console.WriteLine("  / ____| |  | |  __ \\ / __ \\| |/ / |  | |  / ____|/ __ \\| |\\ \\    / / ____ |  __ \\ "); 
            Console.WriteLine(" | (___ | |  | | |  | | |  | | ' /| |  | | | (___ | |  | | | \\ \\  / /| |__  | |__) |"); 
            Console.WriteLine("  \\___ \\| |  | | |  | | |  | |  < | |  | |  \\___ \\| |  | | |  \\ \\/ / |  __| | __  /");
            Console.WriteLine("  ____) | |__| | |__| | |__| | . \\| |__| |  ____) | |__| | |___\\  /  | |____| | \\ \\ ");
            Console.WriteLine(" |_____/ \\____/|_____/ \\____/|_|\\_\\____ /  |_____ /\\____/|______\\/   |______|_|  \\_\\");
            Console.WriteLine();

            bool looper = true;

            while (looper) {

                Console.WriteLine("Please enter a puzzle");
                Console.WriteLine("  - Use 1 line of numbers");
                Console.WriteLine("  - empty spaces are filled with '.'");
                Console.WriteLine("  - EX = 1..4..2.45    etc");
                Console.WriteLine("  - type 'demo' to use a predecided board");


                Board realBoard;

                var readBoard = Console.ReadLine();

                if (readBoard.Equals("demo"))
                    realBoard = new Board(9, ".69..1........9.41..187......8..6..572.....864..3..9......921..81.6........1..65.");
                else
                {
                    try
                    {
                        realBoard = new Board(9, readBoard);
                    }catch(Exception ex)
                    {
                        Console.WriteLine("Exception caught: " + ex);
                        break;
                    }
                }
                realBoard.print9by9();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Solved board:");
                Console.WriteLine();
                if (realBoard.solve() == true)
                    realBoard.print9by9();
                else
                    Console.WriteLine("Board was incalcuable");

                Console.WriteLine();
                Console.WriteLine("Type 'cont' to continue or press any key to end...");
                var end = Console.ReadLine();

                if (!end.Equals("cont"))
                    break;
            }
        }
    }
}

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

            Console.WriteLine("solver");
            Console.WriteLine();
            // Board realBoard = new Board(9, "539714.....2.6.5711..5..34.9..158.3.3.7..6.84.81.7..52.9.8.17.3.6..954.84186..2..");
            // Board realBoard = new Board(9, ".................................................................................");
            Board realBoard = new Board(9, ".69..1........9.41..187......8..6..572.....864..3..9......921..81.6........1..65.");
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
            Console.WriteLine("Press any key to end...");
            var a = Console.ReadLine();
        }
    }
}

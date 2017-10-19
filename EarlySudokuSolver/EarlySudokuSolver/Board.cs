using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySudokuSolver
{
    class Board
    {

        private List<Cell[]> board;
        private int size;

        /// <summary>
        /// Make an empty board of SIZExSIZE with 0's in it
        /// </summary>
        /// <param name="size"></param>
        public Board(int size)
        {
            for(var b = 0; b < size; b++)
            {
                board.Add(new Cell[size]);
            }


            this.size = size;
            for(var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    board[i][j] = (new Cell(0, i, j));
                }
            }
        }

        
        public Board(int size, string bString)
        {
            board = new List<Cell[]>();
            for (var b = 0; b < size; b++)
            {
                board.Add(new Cell[size]);
            }

            this.size = size;
            int stringCounter = 0;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (bString[stringCounter] == '\n')
                        break;
                    else if (bString[stringCounter] == '.')
                        board.ElementAt(i)[j] = new Cell(0, i, j);
                    else if (Char.IsNumber(bString[stringCounter]))
                        board.ElementAt(i)[j] = new Cell((int)Char.GetNumericValue(bString[stringCounter]), i, j);
                    else
                        board.ElementAt(i)[j] = new Cell(-1, i, j);
                    stringCounter++;
                }
            }
        }

        public void printBoard()
        {
            for (var r = 0; r < 9; r++)
            {
                for (var c = 0; c < 9; c++)
                {
                    Console.Write(board.ElementAt(r)[c].getValue());
                }
                Console.WriteLine();
            }
        }


        /// <summary>
        /// Horrible looking method to print stuff out nicely
        /// </summary>
        public void print9by9()
        {
            for (var r = 0; r < 9; r++)
            {
                if(r == 3 || r == 6)
                {
                    Console.Write("-------------------------");
                    Console.WriteLine();
                }
                Console.Write("  ");
                for (var c = 0; c < 9; c++)
                {
                    if (c == 2 || c == 5)
                    {
                        Console.Write(board.ElementAt(r)[c].getValue() + " | ");
                    }
                    else if (c == 8)
                    {
                        Console.Write(board.ElementAt(r)[c].getValue());
                        Console.WriteLine();
                    }
                    else
                        Console.Write(board.ElementAt(r)[c].getValue() + " ");
                }
                
            }

            for (var i = 0; i < board.Count; i++)
            {
                //if (i == 2 || c == 5)
            }
        }

        /// <summary>
        /// Return whther or not a number is in a specific row
        /// </summary>
        /// <param name="number"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool rowFree(int number, int row)
        {
            bool ret = true;
            foreach(var i in board.ElementAt(row))
            {
                if (i.getValue() == number)
                    ret = false;
            }
            return ret;
        }

        /// <summary>
        /// return whether or not a number is in a specific column
        /// </summary>
        /// <param name="number"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool colFree(int number, int col)
        {
            bool ret = true;
            foreach (var i in board)
            {
                if (i[col].getValue() == number)
                    ret = false;
            }
            return ret;
        }

        /// <summary>
        /// Return if a value is used in a box
        /// </summary>
        /// <param name="number">number to check</param>
        /// <param name="startRow"></param>
        /// <param name="startCol"></param>
        /// <returns></returns>
        public bool boxFree(int number, int startRow, int startCol) {
            bool ret = true;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board.ElementAt(row + startRow)[col + startCol].getValue() == number)
                        ret = false;
                }
            }
            return ret;
        }

        /// <summary>
        /// Is it safe to place a number in a certain spot?
        /// </summary>
        /// <param name="number">number being placed</param>
        /// <param name="row">row it's placed</param>
        /// <param name="col">column its placed</param>
        /// <returns></returns>
        public bool safePlace(int number, int row, int col)
        {
            return boxFree(number, row-row%3, col-col%3) && rowFree(number, row) && colFree(number, col);
        }


        /// <summary>
        /// Find a value, if any, that hasn't been solved
        /// </summary>
        /// <returns></returns>
        public Cell findUnassigned()
        {
            Cell temp = new Cell(-1, -1, -1);
            for (int row = 0; row < board.Count(); row++)
            {
                for (int col = 0; col < board.ElementAt(0).Count(); col++)
                {
                    if (board.ElementAt(row)[col].getValue() == 0)
                        temp = board.ElementAt(row)[col];
                }
            }
            return temp;
        }

        /// <summary>
        /// Solve the puzzle by altering the board till it fits
        /// </summary>
        /// <returns></returns>
        public bool solve()
        {
            int row, col;

            Cell un = findUnassigned();

            if (un.getValue() == -1)
                return true;
            row = un.getRow();
            col = un.getCol();

            for (int num = 1; num <= 9; num++)
            {

                if (safePlace(num, row, col))
                {
                    board.ElementAt(row)[col].setValue(num);

                    if (solve())
                        return true;

                    board.ElementAt(row)[col].setValue(0);
                }
            }
            return false;
        }

    }
}

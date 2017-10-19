using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarlySudokuSolver
{
    class Cell
    {

        private int value;
        private int row;
        private int col;

        public Cell(int val, int r, int c)
        {
            value = val;
            row = r;
            col = c;
        }

        public int getValue() { return value; }
        public int getRow() { return row; }
        public int getCol() { return col; }

        public void setValue(int val) { value = val; }
        public void setRow(int r) { row = r; }
        public void setCol(int c) { col = c; }
    }
}

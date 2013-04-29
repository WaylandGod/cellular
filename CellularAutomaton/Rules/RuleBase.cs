using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
    public abstract class RuleBase:IRule
    {
        private int boundRow;
        private int boundCol;
        protected int[,] current;
        protected int[,] next;

        public abstract void Proceed(int row, int col);

        public void Initialize(int[,] current, int[,] next)
        {

            boundRow = current.GetLength(0) - 1;
            boundCol = current.GetLength(1) - 1;
            this.current = current;
            this.next = next;
        }


        /**
         * 计算该点(row,col)的环境
         * ----------------------------------------------
         * | row-1,col-1 | row - 1,col | row - 1, col+1 |
         * ----------------------------------------------
         * | row ,col -1 |   row,col   | row , col+1    |
         * ----------------------------------------------
         * | row+1,col-1 |  row+1,col  | row +1, col+ 1 |
         * ----------------------------------------------
         */
        public  virtual  int GetEnviorment(int row, int col)
        {
            int all =
                TileStatus(row - 1, col - 1) +
                TileStatus(row, col - 1) +
                TileStatus(row + 1, col - 1) +
                TileStatus(row + 1, col) +
                TileStatus(row + 1, col + 1) +
                TileStatus(row, col + 1) +
                TileStatus(row - 1, col + 1) +
                TileStatus(row - 1, col);

            return all;
        }

     
        ///<summary>
        ///  该点的状态，如果在边界，返回0，否则 1
        /// </summary>
        protected virtual  int TileStatus(int row, int col)
        {
            if (row >= 0 && row <= boundRow && col >= 0 && col <= boundCol)
            {
                return current[row, col];
            }
            else
                return 0;
        }
        
    }
}

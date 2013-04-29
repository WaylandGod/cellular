using System;
using System.Collections.Generic;


namespace CellularAutomaton.Rules
{
    /**
     * 代表 中央 和 东南西北 五个细胞元
     * 
     * CSWNE是英文缩写，
     * 
     *           N
     *        W  C  E
     *           S
     * 
     * 
     * 这里需要重写 GetEvniorment,以判断这五个细胞元的状态
     * 
     * 还有一个状态表
     * 
     * "混沌与分形--科学的新疆界" 国防工业出版社，272-273页
     */
    public class CSWNE:RuleBase
    {
        private static Dictionary<int, int> table = new Dictionary<int, int>();

        static CSWNE() {
            table.Add(0, 0);
            table.Add(1, 0);
            table.Add(10, 0);
            table.Add(11, 0);
            table.Add(100, 1);
            table.Add(101, 1);
            table.Add(110, 1);
            table.Add(111, 1);
            table.Add(1000, 1);
            table.Add(1001, 1);
            table.Add(1010, 1);
            table.Add(1011, 1);
            table.Add(1100, 0);
            table.Add(1101, 0);
            table.Add(1110, 0);
            table.Add(1111, 0);
            table.Add(10000, 1);
            table.Add(10001, 1);
            table.Add(10010, 1);
            table.Add(10011, 1);
            table.Add(10100, 1);
            table.Add(10101, 1);
            table.Add(10110, 1);
            table.Add(10111, 1);
            table.Add(11000, 1);
            table.Add(11001, 1);
            table.Add(11010, 1);
            table.Add(11011, 1);
            table.Add(11100, 1);
            table.Add(11101, 1);
            table.Add(11110, 1);
            table.Add(11111, 1);
        }
         

        public override void Proceed(int row, int col)
        {
            next[row, col] = GetEnviorment(row, col);
        }

        public override int GetEnviorment(int row, int col)
        {
            int c = TileStatus(row,col);
            int w = TileStatus(row, col - 1);
            int s = TileStatus(row + 1, col);
            int e = TileStatus(row, col + 1);
            int n = TileStatus(row - 1, col);
            int status = c * 10000 + w * 1000 + s * 100 + w * 10 + e;
            return table[status];
        }

        
    }
}

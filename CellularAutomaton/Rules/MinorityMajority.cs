using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
    /**
     * 少数服从多数
     */
    public class MinorityMajority:RuleBase
    {

        public override void Proceed(int row, int col)
        {
            if (this.GetEnviorment(row, col) >= 5)
            {
                next[row, col] = 1;
            }
            else {
                next[row, col] = 0;
            }
        }

        public override int GetEnviorment(int row, int col)
        {
            return current[row,col] + base.GetEnviorment(row, col);
        }
    }
}

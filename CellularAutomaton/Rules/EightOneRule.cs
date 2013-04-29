using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
    public class EightOneRule:RuleBase
    {
        public override void Proceed(int row, int col)
        {
            if (GetEnviorment(row, col) == 1)
            {
                next[row, col] = 1;
            }
            else {
                next[row, col] = current[row, col];
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton.Rules
{
    /**
     *对于该点细胞的周围
     *当有两个或三个细胞活着时，它保持活着，
     *当有大于三个细胞活着时，它因为拥挤而死亡
     *当有小于两个细胞活着时，它因为孤独而死去
     *当有正好三个细胞活着时，它因此而复活
     *"混沌与分形--科学的新疆界" 国防工业出版社，270页
     **/
    public class GameOfLive:RuleBase
    {
       
        
        public override void Proceed(int row, int col)
        {
            //计算环境
            int stat = GetEnviorment(row, col);


            if (stat == 2)
            {
                if (current[row, col] == 1)
                {
                    next[row, col] = 1;
                }
            }
            else if (stat == 3)
            {
                next[row, col] = 1;
            }
            else
            {
                next[row, col] = 0;
            }
        }

        

       


    }
}

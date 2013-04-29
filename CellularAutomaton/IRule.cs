using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellularAutomaton
{
    //细胞的存活与死亡规则
    public interface IRule
    {
       
        /// <summary>
        /// 处理该点细胞
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        void Proceed(int row,int col);

        /// <summary>
        /// 初始化该规则，
        /// </summary>
        /// <param name="currnet"></param>
        /// <param name="next"></param>
        void Initialize(int[,] currnet, int[,] next);


        int GetEnviorment(int row, int col);
    }
}

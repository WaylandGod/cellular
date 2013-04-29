using System;
using System.Drawing;

namespace CellularAutomaton
{
    /// <summary>
    /// 细胞元自动机游戏
    ///  
    /// </summary>
    public sealed class CAMGame
    {
        int[,] current;
        int[,] next;
        Map map;
        IRule rule;
        //细胞的代
        int generateion;

        Color cellColor;
        Color gridColor;
        Color backgroundColor;
        public CAMGame(Color cellColor,Color gridColor,Color background)
        {
            this.cellColor = cellColor;
            this.gridColor = gridColor;
            this.backgroundColor = background;
        }

        public CAMGame SetRule(IRule rule)
        {
            this.rule = rule;
            return this;
        }

        public CAMGame SetMap(Map map) {
            this.map = map;
            return this;
        }

        public CAMGame Initialize() {
            current = new int[map.Height, map.Width];
            next = new int[map.Height, map.Width];
            rule.Initialize(current, next);
            map.Graphics.Clear(backgroundColor);
            generateion = 1;
            return this;
        }

        public CAMGame Start()
        { 
            map.Graphics.Clear(backgroundColor);
            map.DrawGrid(gridColor);
            return this;
        }

        public void AppendCell(int x, int y) {
            current[y, x] = 1;
            map.DrawTile(cellColor, x, y);
        }

        public void Remove(int x, int y) {
            current[y, x] = 0;
            map.DrawTile(backgroundColor, x, y);
        }

 

        public void Display() {
            for (int row = 0; row < current.GetLength(0); row++)
            {
                for (int col = 0; col < next.GetLength(1); col++)
                {
                    if (current[row, col] == 1)
                    {
                        map.DrawTile(cellColor, col, row);
                    }
                    else
                    {
                        map.DrawTile(backgroundColor, col, row);
                    }
                }
            }
        }

        //计算下一步
        public void Next()
        {
            generateion++;
            int boundRow = map.Height -1;
            int boundCol = map.Width - 1;
            for (int row = 0; row < current.GetLength(0); row++)
            {
                for (int col = 0; col < next.GetLength(1); col++)
                {

                    rule.Proceed(row, col);
               
                }
            }
            Array.Copy(next, current, current.Length);
        }

        /// <summary>
        /// 细胞的第n代
        /// </summary>
        public int CellGeneration {
            get {
                return generateion;
            }
        }
 
        
    }
}

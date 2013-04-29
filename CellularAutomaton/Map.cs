using System.Drawing;
using System.Windows.Forms;

namespace CellularAutomaton
{
    public class Map
    {
        Graphics graphics;
        int padding;
            
        int width; int height;

        public Map(Control control, int padding, int width, int height) {
            control.Width = padding * width + 1;
            control.Height = padding * height + 1; 
            this.graphics = control.CreateGraphics();
            this.padding = padding;
            this.width = width;
            this.height = height;
        }

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public int Padding { get { return padding; } }
        public Graphics Graphics { get { return graphics; } }
       
        /// <summary>
        /// 画一个网格
        /// </summary>
        /// <param name="color"></param>
        public void DrawGrid(Color color  )
        {
            var pen = new Pen(color);
            int x_iter = width + 1;
            int y_iter = height + 1;
            for (int x = 0; x <= x_iter; x++)
            {
                graphics.DrawLine(pen, x * padding, 0, x * padding, y_iter * padding);
            }
            for (int y = 0; y < y_iter; y++)
            {
                graphics.DrawLine(pen, 0, y * padding, x_iter * padding, y * padding);
            }
        }

        //画一个瓦片
        public void DrawTile(Color color, int x, int y)
        {
            var brush = new SolidBrush(color);
            graphics.FillRectangle(brush , x * padding +1 , y * padding +1 ,
                padding-1, padding-1);
        }
    }
}

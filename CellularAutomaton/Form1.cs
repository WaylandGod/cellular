using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CellularAutomaton
{
    public partial class Form1 : Form
    {
        //细胞元自动机 
        CAMGame game;
        //地图
        Map map;
         
        
        //边缘
        int margin = 5;
        

        public Form1()
        {
            InitializeComponent();
             
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (map != null && game!=null)
            {
                int x = e.X / map.Padding;
                int y = e.Y / map.Padding;
                if (e.Button == MouseButtons.Left)
                {

                    game.AppendCell(x, y);
                }
                else
                {
                    game.Remove(x, y);
                }
            }
        }
 
 

        private void startMenuItem_Click(object sender, EventArgs e)
        {
            nextMenuItem.Enabled = true;
            game.Initialize();
            game.Start();
            LogGeneration();
        }

        private void nextMenuItem_Click(object sender, EventArgs e)
        {
            game.Next();
            game.Display();
            LogGeneration();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            game = new CAMGame(Color.Green,Color.Black,Color.Black);
          
            settingMenuItem.Enabled = true;
            startMenuItem.Enabled = false;
            nextMenuItem.Enabled = false;
        }

        private void ResizeForm() 
        {
            pictureBox1.Top = margin + menuStrip1.Height;
            pictureBox1.Left = margin;
            ClientSize = new Size(pictureBox1.Width + 2 * margin, 
                statusStrip1.Height + pictureBox1.Height + menuStrip1.Height + 2 * margin);
            Location = new Point(
                (Screen.PrimaryScreen.WorkingArea.Width-this.Width)/2,
                (Screen.PrimaryScreen.WorkingArea.Height-this.Height)/2
            );
        }

        private void Setting(bool showForm) {
            Program.settingFrm.ShowDialog(this);
            Setting();
        }

        private void Setting() {
            
            map = new Map(pictureBox1, Program.settingFrm.GamePadding,
                Program.settingFrm.GameWidth, Program.settingFrm.GameHeight);
            game.SetMap(map).SetRule(Program.settingFrm.GameRule);
        }

        private void settingMenuItem_Click(object sender, EventArgs e)
        {
            Setting(true);
            ResizeForm();
            startMenuItem.Enabled = true;
            
        }


        private void LogGeneration() {
            generationLabel.Text = "细胞元自动机 第" + (game.CellGeneration).ToString() + "代";
                 
        }
    }
}

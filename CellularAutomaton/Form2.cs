using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CellularAutomaton.Rules;

namespace CellularAutomaton
{
    public partial class Form2 : Form
    {
        static IRule[] ruleArray =  
        {
            new GameOfLive(),
            new EightOneRule(),
            new MinorityMajority(),
            new CSWNE()
        };


        public Form2()
        {
            InitializeComponent();
        }

        int width = 10;
        int height =10;
        int padding = 20;
        IRule rule = ruleArray[0];

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out height) &&
                Int32.TryParse(textBox2.Text, out width) &&
                Int32.TryParse(textBox3.Text, out padding))
            {
                if (comboBox1.SelectedIndex != -1)
                {
                    rule = ruleArray[comboBox1.SelectedIndex];
                    Close();
                }
                else {
                    MessageBox.Show("请选择一个规则");
                }
               
            }
            else
            {
                MessageBox.Show("请输入数字");
            }
            
        }

        public int GameWidth { get { return width; } }
        public int GameHeight { get { return height; } }
        public int GamePadding { get { return padding; } }
        public IRule GameRule { get { return rule; } }



        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

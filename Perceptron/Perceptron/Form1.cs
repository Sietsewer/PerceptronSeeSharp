using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public bool[,] grid;
        int w;
        int h;
        Perceptron p;

        public Form1()
        {
            InitializeComponent();
            w = 3;
            h = 4;
            grid = new bool[w, h];
            p = new Perceptron();
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool[,] tg1 =   {{false, true, false},
                            {false, true, false},
                            {false, true, false},
                            {false, true, false}};
            Trainer t1 = new Trainer(tg1,  1);

            bool[,] tg2 =   {{false, true, false},
                            {true, true, false},
                            {false, true, false},
                            {true, true, true}};
            Trainer t2 = new Trainer(tg1, 1);

            bool[,] tg3 =   {{false, true, false},
                            {true, true, false},
                            {false, true, false},
                            {false, true, false}};
            Trainer t3 = new Trainer(tg1, 1);

            bool[,] tg4 =   {{true, true, true},
                            {true, false, true},
                            {true, false, true},
                            {true, true, true}};
            Trainer t4 = new Trainer(tg1, 0);

            bool[,] tg5 =   {{false, false, false},
                            {true, true, true},
                            {true, false, true},
                            {true, true, true}};
            Trainer t5 = new Trainer(tg1, 0);

            bool[,] tg6 =   {{true, true, true},
                            {true, false, true},
                            {true, true, true},
                            {false, false, false}};
            Trainer t6 = new Trainer(tg1, 0);

            Trainer[] trainingset = { t1, t2, t3, t4, t5, t6 };
            for (int i = 0; i < trainingset.Length; i++)
            {
                trainingset[i].grid = Rotate(trainingset[i].grid);
            }
            p.Learn(trainingset, w, h);
        }

        private bool[,] Rotate(bool[,] grid)
        {
            bool[,] res = new bool[3, 4];
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    res[j, i] = grid[i, j];
                }
            }
            return res;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grid[0, 0] = checkBox1.Checked;
            grid[1, 0] = checkBox2.Checked;
            grid[2, 0] = checkBox3.Checked;
            grid[0, 1] = checkBox4.Checked;
            grid[1, 1] = checkBox5.Checked;
            grid[2, 1] = checkBox6.Checked;
            grid[0, 2] = checkBox7.Checked;
            grid[1, 2] = checkBox8.Checked;
            grid[2, 2] = checkBox9.Checked;
            grid[0, 3] = checkBox10.Checked;
            grid[1, 3] = checkBox11.Checked;
            grid[2, 3] = checkBox12.Checked;

            Console.WriteLine(p.Evaluate(grid, w, h));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p = new Perceptron();
        }  
    }
}

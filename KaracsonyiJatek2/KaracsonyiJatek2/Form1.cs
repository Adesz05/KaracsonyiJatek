using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KaracsonyiJatek2
{
    public partial class Form1 : Form
    {
        static int seged = 0;
        static int acc = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (acc == 0)
            {
                timer1.Start();
                acc = 15;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.ugras;
            pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - acc);
            acc -= 1;

            if (pictureBox1.Location.Y >= 72)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, 72);
                acc = 0;
                pictureBox1.Image = Properties.Resources.Santa;
                timer1.Stop();
            }
            //if (seged<25)
            //{
            //    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 5);
            //}
            //else
            //{
            //    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 5);
            //}
            //if (seged>47)
            //{
            //    seged = 0;
            //    timer1.Stop();
            //}            
        }
    }
}

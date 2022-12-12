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
    public partial class Jatek : Form
    {
        static bool zuhan = false;
        static Point MikulasStartPoz = new Point(200, 350);
        static int acc = 0;
        static PictureBox santa = new PictureBox();
        static List<PictureBox> tetok = new List<PictureBox>();
        static Form kezdoform;
        static List<Image> kepek;
        static int luk = 200;
        static int Ykulonbseg = 100;
        static int Ymax;
        static int Ymin;
        public Jatek(Form ez)
        {
            kepek = new List<Image>() { Properties.Resources.teto1, Properties.Resources.teto2, Properties.Resources.teto3, Properties.Resources.negyedikhazteto };
            kezdoform = ez;
            InitializeComponent();
            MikulasGen();
            ElsoTetoGen();
            TetoMozgas.Start();
        }

        private void ElsoTetoGen()
        {
            TetoGen(Properties.Resources.negyedikhazteto, new Point(0, MikulasStartPoz.Y + santa.Height));
        }

        private void TetoGen(Image teto, Point hely)
        {
            double aranyoszto = 1.3;
            tetok.Add(new PictureBox()
            {
                Size = new Size(Convert.ToInt32(teto.Width / aranyoszto), Convert.ToInt32(teto.Height / aranyoszto)),
                Location = hely,
                Image = teto,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
            });
            pictureBox2.Controls.Add(tetok.Last());
            tetok.Last().BringToFront();
            if (pictureBox2.Height - tetok.Last().Height > tetok.Last().Location.Y)
            {
                tetok.Last().Location = new Point(tetok.Last().Location.X, pictureBox2.Height - tetok.Last().Height);
            }
            if (tetok.Last().Location.Y > pictureBox2.Height-20)
            {
                tetok.Last().Location = new Point(tetok.Last().Location.X, pictureBox2.Height - 20);
            }
        }

        private void MikulasGen()
        {
            santa = new PictureBox()
            {
                Size = new Size(300, 150),
                Location = MikulasStartPoz,
                Image = Properties.Resources.santa,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            pictureBox2.Controls.Add(santa);
            santa.BringToFront();
        }

        private void Jatek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space ||e.KeyCode==Keys.Up)
            {
                //MessageBox.Show("cica");
                if (santa.Location.Y == MikulasStartPoz.Y)
                {
                    MikulasUgras.Start();
                    acc = 15;
                }
            }
        }



        private void Jatek_FormClosing(object sender, FormClosingEventArgs e)
        {
            kezdoform.Show();
        }

        private void MikulasUgras_Tick(object sender, EventArgs e)
        {
            santa.Image = Properties.Resources.ugras;
            santa.Location = new Point(santa.Location.X, santa.Location.Y - acc);
            acc -= 1;
            //jo emlek
            //this.Location = new Point(this.Location.X, this.Location.Y + acc);
            

            if (santa.Location.Y >= MikulasStartPoz.Y)
            {
                santa.Location = MikulasStartPoz;
                acc = 0;
                santa.Image = Properties.Resources.santa;
                MikulasUgras.Stop();
            }
        }

        private void TetoMozgas_Tick(object sender, EventArgs e)
        {
            if (tetok.Last().Location.X +tetok.Last().Width + luk < pictureBox2.Size.Width)
            {
                TetoGen(kepek[new Random().Next(0, kepek.Count-1)], new Point(pictureBox2.Width, tetok.Last().Location.Y + new Random().Next(-Ykulonbseg, Ykulonbseg)));
            }

            for (int i = 0; i < tetok.Count; i++)
            {
                tetok[i].Location = new Point(tetok[i].Location.X - 10, tetok[i].Location.Y);
                if (tetok[i].Location.X + tetok[i].Width <= 0)
                {
                    pictureBox2.Controls.Remove(tetok[i]);
                    tetok.Remove(tetok[i]);
                    i--;
                }
            }
            if (zuhan)
            {
                for (int i = 0; i < tetok.Count; i++)
                {
                    santa.Location = new Point(santa.Location.X, santa.Location.Y + 5);
                    if (santa.Bounds.IntersectsWith(tetok[i].Bounds))
                    {
                        zuhan = false;
                    }
                    else
                    {
                        MikulasMozgas();
                    }
                }
                
            }
            MikulasMozgas();
        }

        private void MikulasMozgas()
        {
            for (int i = 0; i < tetok.Count; i++)
            {
                if (!santa.Bounds.IntersectsWith(tetok[i].Bounds))
                {
                    zuhan = true;
                }
                else
                {
                    zuhan = false;
                }
            }
         
        }
    }
}
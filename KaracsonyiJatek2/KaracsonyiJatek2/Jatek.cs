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
        static Point MikulasStartPoz = new Point(200, 350);
        static int acc = 0;
        static PictureBox santa = new PictureBox();
        static List<PictureBox> tetok = new List<PictureBox>();
        static Form kezdoform;
        public Jatek(Form ez)
        {
            kezdoform = ez;
            InitializeComponent();
            MikulasGen();
            TetoGen();
            //TetoMozgas.Start();
        }

        private void TetoGen()
        {
            List<Image> kepek = new List<Image>() { Properties.Resources.teto1, Properties.Resources.teto2, Properties.Resources.teto3, Properties.Resources.negyedikhazteto };
            foreach (Image item in kepek)
            {
                int szel = 800;
                int magas = Convert.ToInt32(szel * 0.23); 
                tetok.Add(new PictureBox()
                {
                    Size = new Size(szel, magas),
                    Location = new Point(999, 350),
                    Image = item,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    
                });
                pictureBox2.Controls.Add(tetok[tetok.Count-1]);
                tetok[tetok.Count - 1].BringToFront();
            }
            tetok[3].Location = new Point(0, MikulasStartPoz.Y + santa.Height);
            
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
            if (e.KeyCode == Keys.Space)
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
            tetok[tetok.Count - 1].Location = new Point(tetok[tetok.Count - 1].Location.X-2, tetok[tetok.Count - 1].Location.Y);
        }
    }
}
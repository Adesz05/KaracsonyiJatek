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
        static List<Image> kepek;
        static List<PictureBox> ajandekok = new List<PictureBox>();
        static List<PictureBox> amogaesventek = new List<PictureBox>();
        static int luk = 400;
        static int Ykulonbseg = 100;
        static bool ugras = false;
        static int pontszam = 0;
        Label pontszamLbl;
        static PictureBox ajandek;
        static PictureBox amogaesvent;
        static int tetogyorsasag = 10;
        static Panel helpPanel;
        static Image AktivSanta = Properties.Resources.santa;
        Random rand = new Random();
        public Jatek(Form ez)
        {
            kepek = new List<Image>() { Properties.Resources.teto1, Properties.Resources.teto2, Properties.Resources.teto3, Properties.Resources.negyedikhazteto };
            kezdoform = ez;
            InitializeComponent();
            PontszamGen();
            MikulasGen();
            ElsoTetoGen();
            TetoMozgas.Start();
        }

        private void PontszamGen()
        {
            pontszamLbl = new Label
            {
                Location = new Point(1100, 100),
                BackColor = Color.Transparent,
                Text = $"Pontszám: {pontszam}",
                AutoSize = true,
                Font = new Font("Calibri", 18),
                ForeColor = Color.White,
            };
            pictureBox2.Controls.Add(pontszamLbl);
        }

        private void ElsoTetoGen()
        {
            TetoGen(Properties.Resources.negyedikhazteto, new Point(0, MikulasStartPoz.Y + santa.Height));
        }
        private void TetoGen(Image teto, Point hely)
        {
            double aranyoszto = 1.3;
            PictureBox tet = new PictureBox
            {
                Size = new Size(Convert.ToInt32(teto.Width / aranyoszto), Convert.ToInt32(teto.Height / aranyoszto)),
                Location = hely,
                Image = teto,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            tetok.Add(tet);
            pictureBox2.Controls.Add(tetok.Last());
            tetok.Last().BringToFront();
            if (pictureBox2.Height - tetok.Last().Height > tetok.Last().Location.Y)
            {
                tetok.Last().Location = new Point(tetok.Last().Location.X, pictureBox2.Height - tetok.Last().Height);
            }
            if (tetok.Last().Location.Y > pictureBox2.Height - 20)
            {
                tetok.Last().Location = new Point(tetok.Last().Location.X, pictureBox2.Height - 20);
            }
            int meret = 60;
            int r = rand.Next(0, 20);
            if (r > 15)
            {
                ajandek = new PictureBox()
                {
                    Size = new Size(meret, meret),
                    Location = new Point(tetok.Last().Location.X + tetok.Last().Width / 2 - meret / 2, tetok.Last().Location.Y - 80),
                    Image = Properties.Resources.gift,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                ajandekok.Add(ajandek);
                pictureBox2.Controls.Add(ajandek);
            }
            else if (tetok.Last().Width>600 && r<2)
            {
                amogaesvent = new PictureBox()
                {
                    Size = new Size(meret*2, meret),
                    Location = new Point(tetok.Last().Location.X + tetok.Last().Width / 2 - meret / 2, tetok.Last().Location.Y - 60),
                    Image = Properties.Resources.Amoga_és_Vent,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                amogaesventek.Add(amogaesvent);
                pictureBox2.Controls.Add(amogaesvent);
            }
        }
        private void MikulasGen()
        {
            santa = new PictureBox()
            {
                Size = new Size(60, 150),
                Location = MikulasStartPoz,
                Image = AktivSanta,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.Zoom,
            };
            helpPanel = new Panel()
            {
                Location = new Point(santa.Location.X, santa.Location.Y + santa.Size.Height),
                Size = new Size(2,2),
                BackColor = Color.Transparent
            };
            pictureBox2.Controls.Add(helpPanel);
            pictureBox2.Controls.Add(santa);
            santa.BringToFront();
        }
        private void Jatek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Up)
            {
                if (!ugras)
                {
                    santa.Image = Properties.Resources.ugras;
                    ugras = true;
                    acc = 25;
                }
            }
        }
        private void Jatek_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void MikulasUgras_Tick(object sender, EventArgs e)
        {
            //jo emlek
            //this.Location = new Point(this.Location.X, this.Location.Y + acc);
        }
        private void TetoMozgas_Tick(object sender, EventArgs e)
        {
            if (pontszam>=30 && pontszam<60)
            {
                AktivSanta = Properties.Resources.santa_115;
                tetogyorsasag = 12;
            }
            else if (pontszam >= 60 && pontszam < 90)
            {
                AktivSanta= Properties.Resources.santa_130;
                tetogyorsasag = 13;
            }
            else if (pontszam >= 90)
            {
                AktivSanta= Properties.Resources.santa_145;
                tetogyorsasag = 15;
            }
            if (santa.Location.Y > 550)
            {
                TetoMozgas.Stop();
                pictureBox2.Controls.Remove(santa);
                string uzenet = "A mikulás leesett, sajnos nem tudta kivinni az ajánédkokat, és ez a te lelkeden szárad!";
                MessageBox.Show(uzenet, "Játék vége", MessageBoxButtons.OK);
                Close();
            }
            for (int i = 0; i < ajandekok.Count; i++)
            {
                ajandekok[i].Location = new Point(ajandekok[i].Location.X - tetogyorsasag, ajandekok[i].Location.Y);
            }
            for (int i = 0; i < ajandekok.Count; i++)
            {
                if (santa.Bounds.IntersectsWith(ajandekok[i].Bounds))
                {
                    pictureBox2.Controls.Remove(ajandekok[i]);
                    ajandekok.RemoveAt(i);
                    pontszam += 3;
                    pontszamLbl.Text = $"Pontszám: {pontszam}";
                }
            }
            for (int i = 0; i < amogaesventek.Count; i++)
            {
                amogaesventek[i].Location = new Point(amogaesventek[i].Location.X - tetogyorsasag, amogaesventek[i].Location.Y);
            }

            for (int i = 0; i < amogaesventek.Count; i++)
            {
                if (santa.Bounds.IntersectsWith(amogaesventek[i].Bounds))
                {
                    pictureBox2.Controls.Remove(amogaesventek[i]);
                    amogaesventek.RemoveAt(i);
                    pontszam =0;
                    pontszamLbl.Text = $"Pontszám: {pontszam}";
                }
            }
            if (tetok.Last().Location.X + tetok.Last().Width + luk < pictureBox2.Size.Width)
            {
                TetoGen(kepek[new Random().Next(0, kepek.Count)], new Point(pictureBox2.Width, tetok.Last().Location.Y + new Random().Next(-Ykulonbseg, Ykulonbseg)));
            }
            for (int i = 0; i < tetok.Count; i++)
            {
                tetok[i].Location = new Point(tetok[i].Location.X - tetogyorsasag, tetok[i].Location.Y);

                if (tetok[i].Location.X + tetok[i].Width <= 0)
                {
                    pictureBox2.Controls.Remove(tetok[i]);
                    tetok.Remove(tetok[i]);
                    pontszam++;
                    pontszamLbl.Text = $"Pontszám: {pontszam}";
                    i--;
                }
            }
            if (ugras)
            {
                santa.Location = new Point(santa.Location.X, santa.Location.Y - acc);
                helpPanel.Location = new Point(santa.Location.X, santa.Location.Y + santa.Size.Height);
                acc -= 1;
            }
            bool eshet = true;
            foreach (PictureBox tet in tetok)
            {
                if (santa.Bounds.IntersectsWith(tet.Bounds) && tet.Location.Y > santa.Location.Y + santa.Size.Height + acc - 20)
                {
                    if (ugras)
                    {
                        ugras = false;
                        acc = 0;
                        santa.Location = new Point(santa.Location.X, tet.Location.Y - santa.Size.Height);
                        santa.Image = AktivSanta;
                    }
                }
                else if (santa.Location.Y > pictureBox2.Size.Height)
                {
                    TetoMozgas.Stop();
                }
                if (helpPanel.Bounds.IntersectsWith(tet.Bounds))
                {
                    eshet = false;
                }
            }
            if (eshet)
            {
                //MessageBox.Show($"ugras: {ugras.ToString()}\neshet: {eshet.ToString()}");
                ugras = true;
            }
        }
    }
}
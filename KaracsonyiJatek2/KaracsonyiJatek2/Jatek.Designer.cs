
namespace KaracsonyiJatek2
{
    partial class Jatek
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MikulasUgras = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TetoMozgas = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // MikulasUgras
            // 
            this.MikulasUgras.Interval = 15;
            this.MikulasUgras.Tick += new System.EventHandler(this.MikulasUgras_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::KaracsonyiJatek2.Properties.Resources.hatter;
            this.pictureBox2.Location = new System.Drawing.Point(-2, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1050, 454);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // TetoMozgas
            // 
            this.TetoMozgas.Interval = 10;
            this.TetoMozgas.Tick += new System.EventHandler(this.TetoMozgas_Tick);
            // 
            // Jatek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 450);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Jatek";
            this.Text = "Jatek";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Jatek_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Jatek_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MikulasUgras;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer TetoMozgas;
    }
}
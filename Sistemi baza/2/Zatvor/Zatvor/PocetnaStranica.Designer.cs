namespace Zatvor
{
    partial class PocetnaStranica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PocetnaStranica));
            buttonOstalo = new Button();
            pictureLogo = new PictureBox();
            lblZatvorskeJedinice = new Label();
            buttonZatvorenici = new Button();
            buttonZaposleni = new Button();
            buttonZatvori = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureLogo).BeginInit();
            SuspendLayout();
            // 
            // buttonOstalo
            // 
            buttonOstalo.Location = new Point(183, 584);
            buttonOstalo.Margin = new Padding(3, 4, 3, 4);
            buttonOstalo.Name = "buttonOstalo";
            buttonOstalo.Size = new Size(135, 65);
            buttonOstalo.TabIndex = 3;
            buttonOstalo.Text = "OSTALO";
            buttonOstalo.UseVisualStyleBackColor = true;
            buttonOstalo.Click += buttonOstalo_Click;
            // 
            // pictureLogo
            // 
            pictureLogo.Image = (Image)resources.GetObject("pictureLogo.Image");
            pictureLogo.InitialImage = (Image)resources.GetObject("pictureLogo.InitialImage");
            pictureLogo.Location = new Point(136, 22);
            pictureLogo.Margin = new Padding(3, 4, 3, 4);
            pictureLogo.Name = "pictureLogo";
            pictureLogo.Size = new Size(223, 179);
            pictureLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureLogo.TabIndex = 4;
            pictureLogo.TabStop = false;
            pictureLogo.Click += pictureBox1_Click;
            // 
            // lblZatvorskeJedinice
            // 
            lblZatvorskeJedinice.AutoSize = true;
            lblZatvorskeJedinice.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblZatvorskeJedinice.Location = new Point(102, 218);
            lblZatvorskeJedinice.Name = "lblZatvorskeJedinice";
            lblZatvorskeJedinice.Size = new Size(303, 41);
            lblZatvorskeJedinice.TabIndex = 5;
            lblZatvorskeJedinice.Text = "ZATVORSKE JEDINICE";
            // 
            // buttonZatvorenici
            // 
            buttonZatvorenici.Location = new Point(183, 485);
            buttonZatvorenici.Margin = new Padding(3, 4, 3, 4);
            buttonZatvorenici.Name = "buttonZatvorenici";
            buttonZatvorenici.Size = new Size(135, 65);
            buttonZatvorenici.TabIndex = 6;
            buttonZatvorenici.Text = "ZATVORENICI";
            buttonZatvorenici.UseVisualStyleBackColor = true;
            buttonZatvorenici.Click += buttonZatvorenici_Click;
            // 
            // buttonZaposleni
            // 
            buttonZaposleni.Location = new Point(183, 383);
            buttonZaposleni.Margin = new Padding(3, 4, 3, 4);
            buttonZaposleni.Name = "buttonZaposleni";
            buttonZaposleni.Size = new Size(135, 65);
            buttonZaposleni.TabIndex = 7;
            buttonZaposleni.Text = "ZAPOSLENI";
            buttonZaposleni.UseVisualStyleBackColor = true;
            buttonZaposleni.Click += buttonZaposleni_Click;
            // 
            // buttonZatvori
            // 
            buttonZatvori.Location = new Point(183, 291);
            buttonZatvori.Margin = new Padding(3, 4, 3, 4);
            buttonZatvori.Name = "buttonZatvori";
            buttonZatvori.Size = new Size(135, 65);
            buttonZatvori.TabIndex = 8;
            buttonZatvori.Text = "ZATVORI";
            buttonZatvori.UseVisualStyleBackColor = true;
            buttonZatvori.Click += buttonZatvori_Click;
            // 
            // PocetnaStranica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 688);
            Controls.Add(buttonZatvori);
            Controls.Add(buttonZaposleni);
            Controls.Add(buttonZatvorenici);
            Controls.Add(lblZatvorskeJedinice);
            Controls.Add(pictureLogo);
            Controls.Add(buttonOstalo);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(507, 735);
            MinimizeBox = false;
            MinimumSize = new Size(507, 735);
            Name = "PocetnaStranica";
            Text = "SISTEM ZATVORSKIH JEDINICA";
            ((System.ComponentModel.ISupportInitialize)pictureLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonOstalo;
        private PictureBox pictureLogo;
        private Label lblZatvorskeJedinice;
        private Button buttonZatvorenici;
        private Button buttonZaposleni;
        private Button buttonZatvori;
    }
}
namespace Zatvor.Forme_za_OSTALO
{
    partial class FAdvokati
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
            gbxPodaci = new GroupBox();
            btnDodajAdvokata = new Button();
            btnIzmeniAdvokata = new Button();
            btnObrisiAdvokata = new Button();
            gbxZatvorenici = new GroupBox();
            btnZatvorenici = new Button();
            gbxPosete = new GroupBox();
            btnPosete = new Button();
            gbxAdvokati = new GroupBox();
            listaAdvokata = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            gbxPodaci.SuspendLayout();
            gbxZatvorenici.SuspendLayout();
            gbxPosete.SuspendLayout();
            gbxAdvokati.SuspendLayout();
            SuspendLayout();
            // 
            // gbxPodaci
            // 
            gbxPodaci.Controls.Add(btnDodajAdvokata);
            gbxPodaci.Controls.Add(btnIzmeniAdvokata);
            gbxPodaci.Controls.Add(btnObrisiAdvokata);
            gbxPodaci.Location = new Point(390, 31);
            gbxPodaci.Margin = new Padding(3, 4, 3, 4);
            gbxPodaci.Name = "gbxPodaci";
            gbxPodaci.Padding = new Padding(3, 4, 3, 4);
            gbxPodaci.Size = new Size(157, 287);
            gbxPodaci.TabIndex = 1;
            gbxPodaci.TabStop = false;
            gbxPodaci.Text = "Advokati";
            // 
            // btnDodajAdvokata
            // 
            btnDodajAdvokata.Location = new Point(10, 47);
            btnDodajAdvokata.Margin = new Padding(3, 4, 3, 4);
            btnDodajAdvokata.Name = "btnDodajAdvokata";
            btnDodajAdvokata.Size = new Size(136, 55);
            btnDodajAdvokata.TabIndex = 0;
            btnDodajAdvokata.Text = "Dodaj advokata";
            btnDodajAdvokata.UseVisualStyleBackColor = true;
            btnDodajAdvokata.Click += btnDodajAdvokata_Click;
            // 
            // btnIzmeniAdvokata
            // 
            btnIzmeniAdvokata.Location = new Point(10, 218);
            btnIzmeniAdvokata.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniAdvokata.Name = "btnIzmeniAdvokata";
            btnIzmeniAdvokata.Size = new Size(136, 55);
            btnIzmeniAdvokata.TabIndex = 2;
            btnIzmeniAdvokata.Text = "Izmeni advokata";
            btnIzmeniAdvokata.UseVisualStyleBackColor = true;
            btnIzmeniAdvokata.Click += btnIzmeniAdvokata_Click;
            // 
            // btnObrisiAdvokata
            // 
            btnObrisiAdvokata.Location = new Point(10, 136);
            btnObrisiAdvokata.Margin = new Padding(3, 4, 3, 4);
            btnObrisiAdvokata.Name = "btnObrisiAdvokata";
            btnObrisiAdvokata.Size = new Size(136, 55);
            btnObrisiAdvokata.TabIndex = 1;
            btnObrisiAdvokata.Text = "Obriši advokata";
            btnObrisiAdvokata.UseVisualStyleBackColor = true;
            btnObrisiAdvokata.Click += btnObrisiAdvokata_Click;
            // 
            // gbxZatvorenici
            // 
            gbxZatvorenici.Controls.Add(btnZatvorenici);
            gbxZatvorenici.Location = new Point(390, 335);
            gbxZatvorenici.Margin = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Name = "gbxZatvorenici";
            gbxZatvorenici.Padding = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Size = new Size(157, 95);
            gbxZatvorenici.TabIndex = 2;
            gbxZatvorenici.TabStop = false;
            gbxZatvorenici.Text = "Zatvorenici";
            // 
            // btnZatvorenici
            // 
            btnZatvorenici.Location = new Point(10, 28);
            btnZatvorenici.Margin = new Padding(3, 4, 3, 4);
            btnZatvorenici.Name = "btnZatvorenici";
            btnZatvorenici.Size = new Size(136, 55);
            btnZatvorenici.TabIndex = 0;
            btnZatvorenici.Text = "Zatvorenici";
            btnZatvorenici.UseVisualStyleBackColor = true;
            btnZatvorenici.Click += btnZatvorenici_Click;
            // 
            // gbxPosete
            // 
            gbxPosete.Controls.Add(btnPosete);
            gbxPosete.Location = new Point(390, 450);
            gbxPosete.Margin = new Padding(3, 4, 3, 4);
            gbxPosete.Name = "gbxPosete";
            gbxPosete.Padding = new Padding(3, 4, 3, 4);
            gbxPosete.Size = new Size(157, 94);
            gbxPosete.TabIndex = 3;
            gbxPosete.TabStop = false;
            gbxPosete.Text = "Posete";
            // 
            // btnPosete
            // 
            btnPosete.Location = new Point(10, 28);
            btnPosete.Margin = new Padding(3, 4, 3, 4);
            btnPosete.Name = "btnPosete";
            btnPosete.Size = new Size(136, 55);
            btnPosete.TabIndex = 0;
            btnPosete.Text = "Posete";
            btnPosete.UseVisualStyleBackColor = true;
            btnPosete.Click += btnPosete_Click;
            // 
            // gbxAdvokati
            // 
            gbxAdvokati.Controls.Add(listaAdvokata);
            gbxAdvokati.Location = new Point(12, 31);
            gbxAdvokati.Margin = new Padding(3, 4, 3, 4);
            gbxAdvokati.Name = "gbxAdvokati";
            gbxAdvokati.Padding = new Padding(3, 4, 3, 4);
            gbxAdvokati.Size = new Size(350, 513);
            gbxAdvokati.TabIndex = 0;
            gbxAdvokati.TabStop = false;
            gbxAdvokati.Text = "Lista advokata";
            // 
            // listaAdvokata
            // 
            listaAdvokata.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listaAdvokata.Dock = DockStyle.Fill;
            listaAdvokata.FullRowSelect = true;
            listaAdvokata.Location = new Point(3, 24);
            listaAdvokata.Margin = new Padding(3, 4, 3, 4);
            listaAdvokata.Name = "listaAdvokata";
            listaAdvokata.Size = new Size(344, 485);
            listaAdvokata.TabIndex = 0;
            listaAdvokata.UseCompatibleStateImageBehavior = false;
            listaAdvokata.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "JMBG";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Prezime";
            columnHeader3.Width = 120;
            // 
            // FAdvokati
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 554);
            Controls.Add(gbxAdvokati);
            Controls.Add(gbxPosete);
            Controls.Add(gbxZatvorenici);
            Controls.Add(gbxPodaci);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(577, 601);
            MinimizeBox = false;
            MinimumSize = new Size(577, 601);
            Name = "FAdvokati";
            Text = "ADVOKATI";
            Load += FAdvokati_Load;
            gbxPodaci.ResumeLayout(false);
            gbxZatvorenici.ResumeLayout(false);
            gbxPosete.ResumeLayout(false);
            gbxAdvokati.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxPodaci;
        private Button btnDodajAdvokata;
        private Button btnIzmeniAdvokata;
        private Button btnObrisiAdvokata;
        private GroupBox gbxZatvorenici;
        private Button btnZatvorenici;
        private GroupBox gbxPosete;
        private Button btnPosete;
        private GroupBox gbxAdvokati;
        private ListView listaAdvokata;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
    }
}
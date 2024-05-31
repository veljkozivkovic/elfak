namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class ZatvorskeJediniceMain
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
            listaZatvora = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            gbxLista = new GroupBox();
            buttonDodajZatvor = new Button();
            buttonObrisiZatvor = new Button();
            buttonIzmeniZatvor = new Button();
            buttonZatvorenici = new Button();
            buttonZaposleni = new Button();
            groupBoxZatvor = new GroupBox();
            groupBoxZatvorenici = new GroupBox();
            groupBoxZaposleni = new GroupBox();
            btnUpravnik = new Button();
            gbxTermini = new GroupBox();
            btnTerminiSetnje = new Button();
            btnTerminPosete = new Button();
            gbxFirme = new GroupBox();
            btnFirme = new Button();
            gbxLista.SuspendLayout();
            groupBoxZatvor.SuspendLayout();
            groupBoxZatvorenici.SuspendLayout();
            groupBoxZaposleni.SuspendLayout();
            gbxTermini.SuspendLayout();
            gbxFirme.SuspendLayout();
            SuspendLayout();
            // 
            // listaZatvora
            // 
            listaZatvora.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listaZatvora.Dock = DockStyle.Fill;
            listaZatvora.FullRowSelect = true;
            listaZatvora.GridLines = true;
            listaZatvora.Location = new Point(3, 24);
            listaZatvora.Margin = new Padding(4);
            listaZatvora.Name = "listaZatvora";
            listaZatvora.Size = new Size(694, 858);
            listaZatvora.TabIndex = 0;
            listaZatvora.UseCompatibleStateImageBehavior = false;
            listaZatvora.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "Sifra";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Naziv";
            columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Adresa";
            columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Kapacitet";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip";
            columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Period zabrane";
            columnHeader6.Width = 180;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZatvora);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 886);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zatvora";
            // 
            // buttonDodajZatvor
            // 
            buttonDodajZatvor.Location = new Point(9, 28);
            buttonDodajZatvor.Margin = new Padding(3, 4, 3, 4);
            buttonDodajZatvor.Name = "buttonDodajZatvor";
            buttonDodajZatvor.Size = new Size(125, 55);
            buttonDodajZatvor.TabIndex = 0;
            buttonDodajZatvor.Text = "Dodaj zatvor";
            buttonDodajZatvor.UseVisualStyleBackColor = true;
            buttonDodajZatvor.Click += btnDodajZatvor_Click;
            // 
            // buttonObrisiZatvor
            // 
            buttonObrisiZatvor.Location = new Point(9, 123);
            buttonObrisiZatvor.Margin = new Padding(3, 4, 3, 4);
            buttonObrisiZatvor.Name = "buttonObrisiZatvor";
            buttonObrisiZatvor.Size = new Size(125, 55);
            buttonObrisiZatvor.TabIndex = 1;
            buttonObrisiZatvor.Text = "Obriši zatvor";
            buttonObrisiZatvor.UseVisualStyleBackColor = true;
            buttonObrisiZatvor.Click += btnObrisiZatvor_Click;
            // 
            // buttonIzmeniZatvor
            // 
            buttonIzmeniZatvor.Location = new Point(9, 215);
            buttonIzmeniZatvor.Margin = new Padding(3, 4, 3, 4);
            buttonIzmeniZatvor.Name = "buttonIzmeniZatvor";
            buttonIzmeniZatvor.Size = new Size(125, 55);
            buttonIzmeniZatvor.TabIndex = 2;
            buttonIzmeniZatvor.Text = "Izmeni zatvor";
            buttonIzmeniZatvor.UseVisualStyleBackColor = true;
            buttonIzmeniZatvor.Click += btnIzmeniZatvor_Click;
            // 
            // buttonZatvorenici
            // 
            buttonZatvorenici.Location = new Point(9, 28);
            buttonZatvorenici.Margin = new Padding(3, 4, 3, 4);
            buttonZatvorenici.Name = "buttonZatvorenici";
            buttonZatvorenici.Size = new Size(125, 55);
            buttonZatvorenici.TabIndex = 0;
            buttonZatvorenici.Text = "Zatvorenici";
            buttonZatvorenici.UseVisualStyleBackColor = true;
            buttonZatvorenici.Click += btnZatvorenici_Click;
            // 
            // buttonZaposleni
            // 
            buttonZaposleni.Location = new Point(9, 29);
            buttonZaposleni.Margin = new Padding(3, 4, 3, 4);
            buttonZaposleni.Name = "buttonZaposleni";
            buttonZaposleni.Size = new Size(125, 55);
            buttonZaposleni.TabIndex = 0;
            buttonZaposleni.Text = "Zaposleni";
            buttonZaposleni.UseVisualStyleBackColor = true;
            buttonZaposleni.Click += btnZaposleni_Click;
            // 
            // groupBoxZatvor
            // 
            groupBoxZatvor.Controls.Add(buttonDodajZatvor);
            groupBoxZatvor.Controls.Add(buttonIzmeniZatvor);
            groupBoxZatvor.Controls.Add(buttonObrisiZatvor);
            groupBoxZatvor.Location = new Point(757, 31);
            groupBoxZatvor.Margin = new Padding(3, 4, 3, 4);
            groupBoxZatvor.Name = "groupBoxZatvor";
            groupBoxZatvor.Padding = new Padding(3, 4, 3, 4);
            groupBoxZatvor.Size = new Size(141, 288);
            groupBoxZatvor.TabIndex = 1;
            groupBoxZatvor.TabStop = false;
            groupBoxZatvor.Text = "Zatvor";
            // 
            // groupBoxZatvorenici
            // 
            groupBoxZatvorenici.Controls.Add(buttonZatvorenici);
            groupBoxZatvorenici.Location = new Point(757, 341);
            groupBoxZatvorenici.Margin = new Padding(3, 4, 3, 4);
            groupBoxZatvorenici.Name = "groupBoxZatvorenici";
            groupBoxZatvorenici.Padding = new Padding(3, 4, 3, 4);
            groupBoxZatvorenici.Size = new Size(141, 99);
            groupBoxZatvorenici.TabIndex = 2;
            groupBoxZatvorenici.TabStop = false;
            groupBoxZatvorenici.Text = "Zatvorenici";
            // 
            // groupBoxZaposleni
            // 
            groupBoxZaposleni.Controls.Add(btnUpravnik);
            groupBoxZaposleni.Controls.Add(buttonZaposleni);
            groupBoxZaposleni.Location = new Point(757, 462);
            groupBoxZaposleni.Margin = new Padding(3, 4, 3, 4);
            groupBoxZaposleni.Name = "groupBoxZaposleni";
            groupBoxZaposleni.Padding = new Padding(3, 4, 3, 4);
            groupBoxZaposleni.Size = new Size(141, 157);
            groupBoxZaposleni.TabIndex = 3;
            groupBoxZaposleni.TabStop = false;
            groupBoxZaposleni.Text = "Zaposleni";
            // 
            // btnUpravnik
            // 
            btnUpravnik.Location = new Point(9, 92);
            btnUpravnik.Margin = new Padding(3, 4, 3, 4);
            btnUpravnik.Name = "btnUpravnik";
            btnUpravnik.Size = new Size(125, 55);
            btnUpravnik.TabIndex = 1;
            btnUpravnik.Text = "Upravnik";
            btnUpravnik.UseVisualStyleBackColor = true;
            btnUpravnik.Click += btnUpravnik_Click;
            // 
            // gbxTermini
            // 
            gbxTermini.Controls.Add(btnTerminiSetnje);
            gbxTermini.Controls.Add(btnTerminPosete);
            gbxTermini.Location = new Point(757, 640);
            gbxTermini.Margin = new Padding(3, 4, 3, 4);
            gbxTermini.Name = "gbxTermini";
            gbxTermini.Padding = new Padding(3, 4, 3, 4);
            gbxTermini.Size = new Size(141, 157);
            gbxTermini.TabIndex = 4;
            gbxTermini.TabStop = false;
            gbxTermini.Text = "Termini";
            // 
            // btnTerminiSetnje
            // 
            btnTerminiSetnje.Location = new Point(9, 92);
            btnTerminiSetnje.Margin = new Padding(3, 4, 3, 4);
            btnTerminiSetnje.Name = "btnTerminiSetnje";
            btnTerminiSetnje.Size = new Size(125, 55);
            btnTerminiSetnje.TabIndex = 1;
            btnTerminiSetnje.Text = "Termini za šetnju";
            btnTerminiSetnje.UseVisualStyleBackColor = true;
            btnTerminiSetnje.Click += btnTerminiSetnje_Click;
            // 
            // btnTerminPosete
            // 
            btnTerminPosete.Location = new Point(9, 29);
            btnTerminPosete.Margin = new Padding(3, 4, 3, 4);
            btnTerminPosete.Name = "btnTerminPosete";
            btnTerminPosete.Size = new Size(125, 55);
            btnTerminPosete.TabIndex = 0;
            btnTerminPosete.Text = "Termini za posete";
            btnTerminPosete.UseVisualStyleBackColor = true;
            btnTerminPosete.Click += btnTerminPosete_Click;
            // 
            // gbxFirme
            // 
            gbxFirme.Controls.Add(btnFirme);
            gbxFirme.Location = new Point(757, 818);
            gbxFirme.Margin = new Padding(3, 4, 3, 4);
            gbxFirme.Name = "gbxFirme";
            gbxFirme.Padding = new Padding(3, 4, 3, 4);
            gbxFirme.Size = new Size(141, 99);
            gbxFirme.TabIndex = 5;
            gbxFirme.TabStop = false;
            gbxFirme.Text = "Firme";
            // 
            // btnFirme
            // 
            btnFirme.Location = new Point(9, 28);
            btnFirme.Margin = new Padding(3, 4, 3, 4);
            btnFirme.Name = "btnFirme";
            btnFirme.Size = new Size(125, 55);
            btnFirme.TabIndex = 0;
            btnFirme.Text = "Saradnja sa firmama";
            btnFirme.UseVisualStyleBackColor = true;
            btnFirme.Click += btnFirme_Click;
            // 
            // ZatvorskeJediniceMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 930);
            Controls.Add(gbxFirme);
            Controls.Add(gbxTermini);
            Controls.Add(gbxLista);
            Controls.Add(groupBoxZatvor);
            Controls.Add(groupBoxZatvorenici);
            Controls.Add(groupBoxZaposleni);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(936, 977);
            MinimizeBox = false;
            MinimumSize = new Size(936, 977);
            Name = "ZatvorskeJediniceMain";
            Text = "ZATVORSKE JEDINICE";
            Load += ZatvorskeJediniceMain_Load;
            gbxLista.ResumeLayout(false);
            groupBoxZatvor.ResumeLayout(false);
            groupBoxZatvorenici.ResumeLayout(false);
            groupBoxZaposleni.ResumeLayout(false);
            gbxTermini.ResumeLayout(false);
            gbxFirme.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listaZatvora;
        private GroupBox gbxLista;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button buttonDodajZatvor;
        private Button buttonObrisiZatvor;
        private Button buttonIzmeniZatvor;
        private Button buttonZatvorenici;
        private Button buttonZaposleni;
        private GroupBox groupBoxZatvor;
        private GroupBox groupBoxZatvorenici;
        private GroupBox groupBoxZaposleni;
        private ColumnHeader columnHeader6;
        private GroupBox gbxTermini;
        private Button btnTerminPosete;
        private Button btnTerminiSetnje;
        private Button btnUpravnik;
        private GroupBox gbxFirme;
        private Button btnFirme;
    }
}
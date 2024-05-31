namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class ZatvorskeJediniceZatvorenici
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
            listaZatvorenika = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            gbxLista = new GroupBox();
            btnDodajZatvorenika = new Button();
            btnObrisiZatvorenika = new Button();
            btnIzmeniZatvorenika = new Button();
            btnPremestajDodaj = new Button();
            gbxZatvorenici = new GroupBox();
            gbxPremestaj = new GroupBox();
            btnPremestajPremesti = new Button();
            gbxLista.SuspendLayout();
            gbxZatvorenici.SuspendLayout();
            gbxPremestaj.SuspendLayout();
            SuspendLayout();
            // 
            // listaZatvorenika
            // 
            listaZatvorenika.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader10, columnHeader8, columnHeader9 });
            listaZatvorenika.Dock = DockStyle.Fill;
            listaZatvorenika.FullRowSelect = true;
            listaZatvorenika.GridLines = true;
            listaZatvorenika.Location = new Point(3, 24);
            listaZatvorenika.Margin = new Padding(4);
            listaZatvorenika.Name = "listaZatvorenika";
            listaZatvorenika.Size = new Size(694, 447);
            listaZatvorenika.TabIndex = 0;
            listaZatvorenika.UseCompatibleStateImageBehavior = false;
            listaZatvorenika.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "Sifra";
            columnHeader1.Width = 80;
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
            // columnHeader4
            // 
            columnHeader4.Text = "Adresa";
            columnHeader4.Width = 240;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Pol";
            columnHeader5.Width = 40;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Status uslovnog otpusta";
            columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Datum sledećeg saslušanja";
            columnHeader7.Width = 200;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Advokat";
            columnHeader10.Width = 220;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Datum dodele advokata";
            columnHeader8.Width = 240;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Poslednji kontakt sa advokatom";
            columnHeader9.Width = 240;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZatvorenika);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 475);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zatvorenika";
            // 
            // btnDodajZatvorenika
            // 
            btnDodajZatvorenika.Location = new Point(9, 28);
            btnDodajZatvorenika.Margin = new Padding(3, 4, 3, 4);
            btnDodajZatvorenika.Name = "btnDodajZatvorenika";
            btnDodajZatvorenika.Size = new Size(125, 55);
            btnDodajZatvorenika.TabIndex = 0;
            btnDodajZatvorenika.Text = "Dodaj zatvorenika";
            btnDodajZatvorenika.UseVisualStyleBackColor = true;
            btnDodajZatvorenika.Click += btnDodajZatvorenika_Click;
            // 
            // btnObrisiZatvorenika
            // 
            btnObrisiZatvorenika.Location = new Point(9, 123);
            btnObrisiZatvorenika.Margin = new Padding(3, 4, 3, 4);
            btnObrisiZatvorenika.Name = "btnObrisiZatvorenika";
            btnObrisiZatvorenika.Size = new Size(125, 55);
            btnObrisiZatvorenika.TabIndex = 1;
            btnObrisiZatvorenika.Text = "Obriši zatvorenika";
            btnObrisiZatvorenika.UseVisualStyleBackColor = true;
            btnObrisiZatvorenika.Click += btnObrisiZatvorenika_Click;
            // 
            // btnIzmeniZatvorenika
            // 
            btnIzmeniZatvorenika.Location = new Point(9, 215);
            btnIzmeniZatvorenika.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniZatvorenika.Name = "btnIzmeniZatvorenika";
            btnIzmeniZatvorenika.Size = new Size(125, 55);
            btnIzmeniZatvorenika.TabIndex = 2;
            btnIzmeniZatvorenika.Text = "Izmeni zatvorenika";
            btnIzmeniZatvorenika.UseVisualStyleBackColor = true;
            btnIzmeniZatvorenika.Click += btnIzmeniZatvorenika_Click;
            // 
            // btnPremestajDodaj
            // 
            btnPremestajDodaj.Location = new Point(9, 28);
            btnPremestajDodaj.Margin = new Padding(3, 4, 3, 4);
            btnPremestajDodaj.Name = "btnPremestajDodaj";
            btnPremestajDodaj.Size = new Size(125, 55);
            btnPremestajDodaj.TabIndex = 0;
            btnPremestajDodaj.Text = "Dodaj iz druge jedinice";
            btnPremestajDodaj.UseVisualStyleBackColor = true;
            btnPremestajDodaj.Click += btnPremestajDodaj_Click;
            // 
            // gbxZatvorenici
            // 
            gbxZatvorenici.Controls.Add(btnDodajZatvorenika);
            gbxZatvorenici.Controls.Add(btnIzmeniZatvorenika);
            gbxZatvorenici.Controls.Add(btnObrisiZatvorenika);
            gbxZatvorenici.Location = new Point(757, 31);
            gbxZatvorenici.Margin = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Name = "gbxZatvorenici";
            gbxZatvorenici.Padding = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Size = new Size(141, 288);
            gbxZatvorenici.TabIndex = 1;
            gbxZatvorenici.TabStop = false;
            gbxZatvorenici.Text = "Zatvorenici";
            // 
            // gbxPremestaj
            // 
            gbxPremestaj.Controls.Add(btnPremestajPremesti);
            gbxPremestaj.Controls.Add(btnPremestajDodaj);
            gbxPremestaj.Location = new Point(757, 341);
            gbxPremestaj.Margin = new Padding(3, 4, 3, 4);
            gbxPremestaj.Name = "gbxPremestaj";
            gbxPremestaj.Padding = new Padding(3, 4, 3, 4);
            gbxPremestaj.Size = new Size(141, 165);
            gbxPremestaj.TabIndex = 2;
            gbxPremestaj.TabStop = false;
            gbxPremestaj.Text = "Premeštaj";
            // 
            // btnPremestajPremesti
            // 
            btnPremestajPremesti.Location = new Point(9, 101);
            btnPremestajPremesti.Margin = new Padding(3, 4, 3, 4);
            btnPremestajPremesti.Name = "btnPremestajPremesti";
            btnPremestajPremesti.Size = new Size(125, 55);
            btnPremestajPremesti.TabIndex = 1;
            btnPremestajPremesti.Text = "Premesti u drugu jedinicu";
            btnPremestajPremesti.UseVisualStyleBackColor = true;
            btnPremestajPremesti.Click += btnPremestajPremesti_Click;
            // 
            // ZatvorskeJediniceZatvorenici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 525);
            Controls.Add(gbxLista);
            Controls.Add(gbxZatvorenici);
            Controls.Add(gbxPremestaj);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(936, 572);
            MinimizeBox = false;
            MinimumSize = new Size(936, 572);
            Name = "ZatvorskeJediniceZatvorenici";
            Text = "ZATVORENICI U ZATVORU";
            Load += ZatvorskeJediniceZatvorenici_Load;
            gbxLista.ResumeLayout(false);
            gbxZatvorenici.ResumeLayout(false);
            gbxPremestaj.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listaZatvorenika;
        private GroupBox gbxLista;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnDodajZatvorenika;
        private Button btnObrisiZatvorenika;
        private Button btnIzmeniZatvorenika;
        private Button btnPremestajDodaj;
        private GroupBox gbxZatvorenici;
        private GroupBox gbxPremestaj;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Button btnPremestajPremesti;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
    }
}
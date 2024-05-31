namespace Zatvor.Forme_za_Zaposlene
{
    partial class FZaposleni
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
            gbxLista = new GroupBox();
            listaZaposlenih = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            gbxZaposleni = new GroupBox();
            btnDodajZaposlenog = new Button();
            btnIzmeniZaposlenog = new Button();
            btnObrisiZaposlenog = new Button();
            gbxZaposlenje = new GroupBox();
            btnPrikaziZaposlenja = new Button();
            gbxLekarskiPregledi = new GroupBox();
            btnLekarskiPregledi = new Button();
            gbxObuke = new GroupBox();
            btnObuke = new Button();
            gbxLista.SuspendLayout();
            gbxZaposleni.SuspendLayout();
            gbxZaposlenje.SuspendLayout();
            gbxLekarskiPregledi.SuspendLayout();
            gbxObuke.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZaposlenih);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 623);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zaposlenih";
            // 
            // listaZaposlenih
            // 
            listaZaposlenih.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listaZaposlenih.Dock = DockStyle.Fill;
            listaZaposlenih.FullRowSelect = true;
            listaZaposlenih.GridLines = true;
            listaZaposlenih.Location = new Point(3, 24);
            listaZaposlenih.Margin = new Padding(4);
            listaZaposlenih.Name = "listaZaposlenih";
            listaZaposlenih.Size = new Size(694, 595);
            listaZaposlenih.TabIndex = 0;
            listaZaposlenih.UseCompatibleStateImageBehavior = false;
            listaZaposlenih.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "JMBG";
            columnHeader1.Width = 140;
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
            columnHeader4.Text = "Datum protivpožarne obuke";
            columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip";
            columnHeader5.Width = 140;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Zanimanje";
            columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Stručna sprema";
            columnHeader7.Width = 160;
            // 
            // gbxZaposleni
            // 
            gbxZaposleni.Controls.Add(btnDodajZaposlenog);
            gbxZaposleni.Controls.Add(btnIzmeniZaposlenog);
            gbxZaposleni.Controls.Add(btnObrisiZaposlenog);
            gbxZaposleni.Location = new Point(746, 31);
            gbxZaposleni.Margin = new Padding(3, 4, 3, 4);
            gbxZaposleni.Name = "gbxZaposleni";
            gbxZaposleni.Padding = new Padding(3, 4, 3, 4);
            gbxZaposleni.Size = new Size(157, 287);
            gbxZaposleni.TabIndex = 1;
            gbxZaposleni.TabStop = false;
            gbxZaposleni.Text = "Zaposleni";
            // 
            // btnDodajZaposlenog
            // 
            btnDodajZaposlenog.Location = new Point(10, 47);
            btnDodajZaposlenog.Margin = new Padding(3, 4, 3, 4);
            btnDodajZaposlenog.Name = "btnDodajZaposlenog";
            btnDodajZaposlenog.Size = new Size(136, 55);
            btnDodajZaposlenog.TabIndex = 0;
            btnDodajZaposlenog.Text = "Dodaj novog zaposlenog";
            btnDodajZaposlenog.UseVisualStyleBackColor = true;
            btnDodajZaposlenog.Click += btnDodajZaposlenog_Click;
            // 
            // btnIzmeniZaposlenog
            // 
            btnIzmeniZaposlenog.Location = new Point(10, 218);
            btnIzmeniZaposlenog.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniZaposlenog.Name = "btnIzmeniZaposlenog";
            btnIzmeniZaposlenog.Size = new Size(136, 55);
            btnIzmeniZaposlenog.TabIndex = 2;
            btnIzmeniZaposlenog.Text = "Izmeni zaposlenog";
            btnIzmeniZaposlenog.UseVisualStyleBackColor = true;
            btnIzmeniZaposlenog.Click += btnIzmeniZaposlenog_Click;
            // 
            // btnObrisiZaposlenog
            // 
            btnObrisiZaposlenog.Location = new Point(10, 136);
            btnObrisiZaposlenog.Margin = new Padding(3, 4, 3, 4);
            btnObrisiZaposlenog.Name = "btnObrisiZaposlenog";
            btnObrisiZaposlenog.Size = new Size(136, 55);
            btnObrisiZaposlenog.TabIndex = 1;
            btnObrisiZaposlenog.Text = "Obriši zaposlenog";
            btnObrisiZaposlenog.UseVisualStyleBackColor = true;
            btnObrisiZaposlenog.Click += btnObrisiZaposlenog_Click;
            // 
            // gbxZaposlenje
            // 
            gbxZaposlenje.Controls.Add(btnPrikaziZaposlenja);
            gbxZaposlenje.Location = new Point(746, 335);
            gbxZaposlenje.Margin = new Padding(3, 4, 3, 4);
            gbxZaposlenje.Name = "gbxZaposlenje";
            gbxZaposlenje.Padding = new Padding(3, 4, 3, 4);
            gbxZaposlenje.Size = new Size(157, 95);
            gbxZaposlenje.TabIndex = 2;
            gbxZaposlenje.TabStop = false;
            gbxZaposlenje.Text = "Zaposlenje";
            // 
            // btnPrikaziZaposlenja
            // 
            btnPrikaziZaposlenja.Location = new Point(10, 28);
            btnPrikaziZaposlenja.Margin = new Padding(3, 4, 3, 4);
            btnPrikaziZaposlenja.Name = "btnPrikaziZaposlenja";
            btnPrikaziZaposlenja.Size = new Size(136, 55);
            btnPrikaziZaposlenja.TabIndex = 0;
            btnPrikaziZaposlenja.Text = "Prikaži zaposlenja";
            btnPrikaziZaposlenja.UseVisualStyleBackColor = true;
            btnPrikaziZaposlenja.Click += btnPrikaziZaposlenja_Click;
            // 
            // gbxLekarskiPregledi
            // 
            gbxLekarskiPregledi.Controls.Add(btnLekarskiPregledi);
            gbxLekarskiPregledi.Location = new Point(746, 448);
            gbxLekarskiPregledi.Margin = new Padding(3, 4, 3, 4);
            gbxLekarskiPregledi.Name = "gbxLekarskiPregledi";
            gbxLekarskiPregledi.Padding = new Padding(3, 4, 3, 4);
            gbxLekarskiPregledi.Size = new Size(157, 94);
            gbxLekarskiPregledi.TabIndex = 3;
            gbxLekarskiPregledi.TabStop = false;
            gbxLekarskiPregledi.Text = "Lekarski pregledi";
            // 
            // btnLekarskiPregledi
            // 
            btnLekarskiPregledi.Location = new Point(10, 28);
            btnLekarskiPregledi.Margin = new Padding(3, 4, 3, 4);
            btnLekarskiPregledi.Name = "btnLekarskiPregledi";
            btnLekarskiPregledi.Size = new Size(136, 55);
            btnLekarskiPregledi.TabIndex = 0;
            btnLekarskiPregledi.Text = "Lekarski pregledi";
            btnLekarskiPregledi.UseVisualStyleBackColor = true;
            btnLekarskiPregledi.Click += btnLekarskiPregledi_Click;
            // 
            // gbxObuke
            // 
            gbxObuke.Controls.Add(btnObuke);
            gbxObuke.Location = new Point(746, 560);
            gbxObuke.Margin = new Padding(3, 4, 3, 4);
            gbxObuke.Name = "gbxObuke";
            gbxObuke.Padding = new Padding(3, 4, 3, 4);
            gbxObuke.Size = new Size(157, 94);
            gbxObuke.TabIndex = 4;
            gbxObuke.TabStop = false;
            gbxObuke.Text = "Obuke";
            // 
            // btnObuke
            // 
            btnObuke.Location = new Point(10, 28);
            btnObuke.Margin = new Padding(3, 4, 3, 4);
            btnObuke.Name = "btnObuke";
            btnObuke.Size = new Size(136, 55);
            btnObuke.TabIndex = 0;
            btnObuke.Text = "Obuke";
            btnObuke.UseVisualStyleBackColor = true;
            btnObuke.Click += btnObuke_Click;
            // 
            // FZaposleni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 664);
            Controls.Add(gbxObuke);
            Controls.Add(gbxLekarskiPregledi);
            Controls.Add(gbxZaposlenje);
            Controls.Add(gbxZaposleni);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(934, 711);
            MinimizeBox = false;
            MinimumSize = new Size(934, 711);
            Name = "FZaposleni";
            Text = "ZAPOSLENI";
            Load += FZaposleni_Load;
            gbxLista.ResumeLayout(false);
            gbxZaposleni.ResumeLayout(false);
            gbxZaposlenje.ResumeLayout(false);
            gbxLekarskiPregledi.ResumeLayout(false);
            gbxObuke.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaZaposlenih;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private GroupBox gbxZaposleni;
        private Button btnDodajZaposlenog;
        private Button btnIzmeniZaposlenog;
        private Button btnObrisiZaposlenog;
        private GroupBox gbxZaposlenje;
        private Button btnPrikaziZaposlenja;
        private GroupBox gbxLekarskiPregledi;
        private Button btnLekarskiPregledi;
        private GroupBox gbxObuke;
        private Button btnObuke;
    }
}
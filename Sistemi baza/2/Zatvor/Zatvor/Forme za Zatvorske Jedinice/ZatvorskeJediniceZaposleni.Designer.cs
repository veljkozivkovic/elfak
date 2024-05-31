namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class ZatvorskeJediniceZaposleni
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
            listaZaposlenih = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            gbxLista = new GroupBox();
            btnDodajZaposlenog = new Button();
            btnDodajPostojecegZaposlenog = new Button();
            btnObrisiZaposlenog = new Button();
            btnIzmeniZaposlenog = new Button();
            gbxZaposleni = new GroupBox();
            gbxLista.SuspendLayout();
            gbxZaposleni.SuspendLayout();
            SuspendLayout();
            // 
            // listaZaposlenih
            // 
            listaZaposlenih.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9 });
            listaZaposlenih.Dock = DockStyle.Fill;
            listaZaposlenih.FullRowSelect = true;
            listaZaposlenih.GridLines = true;
            listaZaposlenih.Location = new Point(3, 24);
            listaZaposlenih.Margin = new Padding(4);
            listaZaposlenih.Name = "listaZaposlenih";
            listaZaposlenih.Size = new Size(694, 342);
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
            // columnHeader8
            // 
            columnHeader8.Text = "Radno mesto";
            columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Datum početka rada";
            columnHeader9.Width = 150;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZaposlenih);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 370);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zaposlenih";
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
            // btnDodajPostojecegZaposlenog
            // 
            btnDodajPostojecegZaposlenog.Location = new Point(10, 136);
            btnDodajPostojecegZaposlenog.Margin = new Padding(3, 4, 3, 4);
            btnDodajPostojecegZaposlenog.Name = "btnDodajPostojecegZaposlenog";
            btnDodajPostojecegZaposlenog.Size = new Size(136, 55);
            btnDodajPostojecegZaposlenog.TabIndex = 1;
            btnDodajPostojecegZaposlenog.Text = "Dodaj postojećeg zaposlenog";
            btnDodajPostojecegZaposlenog.UseVisualStyleBackColor = true;
            btnDodajPostojecegZaposlenog.Click += btnDodajPostojecegZaposlenog_Click;
            // 
            // btnObrisiZaposlenog
            // 
            btnObrisiZaposlenog.Location = new Point(10, 218);
            btnObrisiZaposlenog.Margin = new Padding(3, 4, 3, 4);
            btnObrisiZaposlenog.Name = "btnObrisiZaposlenog";
            btnObrisiZaposlenog.Size = new Size(136, 55);
            btnObrisiZaposlenog.TabIndex = 2;
            btnObrisiZaposlenog.Text = "Obriši zaposlenog";
            btnObrisiZaposlenog.UseVisualStyleBackColor = true;
            btnObrisiZaposlenog.Click += btnObrisiZaposlenog_Click;
            // 
            // btnIzmeniZaposlenog
            // 
            btnIzmeniZaposlenog.Location = new Point(10, 300);
            btnIzmeniZaposlenog.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniZaposlenog.Name = "btnIzmeniZaposlenog";
            btnIzmeniZaposlenog.Size = new Size(136, 55);
            btnIzmeniZaposlenog.TabIndex = 3;
            btnIzmeniZaposlenog.Text = "Izmeni zaposlenog";
            btnIzmeniZaposlenog.UseVisualStyleBackColor = true;
            btnIzmeniZaposlenog.Click += btnIzmeniZaposlenog_Click;
            // 
            // gbxZaposleni
            // 
            gbxZaposleni.Controls.Add(btnDodajZaposlenog);
            gbxZaposleni.Controls.Add(btnIzmeniZaposlenog);
            gbxZaposleni.Controls.Add(btnObrisiZaposlenog);
            gbxZaposleni.Controls.Add(btnDodajPostojecegZaposlenog);
            gbxZaposleni.Location = new Point(758, 31);
            gbxZaposleni.Margin = new Padding(3, 4, 3, 4);
            gbxZaposleni.Name = "gbxZaposleni";
            gbxZaposleni.Padding = new Padding(3, 4, 3, 4);
            gbxZaposleni.Size = new Size(157, 370);
            gbxZaposleni.TabIndex = 1;
            gbxZaposleni.TabStop = false;
            gbxZaposleni.Text = "Zaposleni";
            // 
            // ZatvorskeJediniceZaposleni
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 413);
            Controls.Add(gbxLista);
            Controls.Add(gbxZaposleni);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(945, 460);
            MinimizeBox = false;
            MinimumSize = new Size(945, 460);
            Name = "ZatvorskeJediniceZaposleni";
            Text = "ZAPOSLENI U ZATVORU";
            Load += ZatvorskeJediniceZaposleni_Load;
            gbxLista.ResumeLayout(false);
            gbxZaposleni.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView listaZaposlenih;
        private GroupBox gbxLista;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button btnDodajZaposlenog;
        private Button btnDodajPostojecegZaposlenog;
        private Button btnObrisiZaposlenog;
        private Button btnIzmeniZaposlenog;
        private GroupBox gbxZaposleni;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
    }
}
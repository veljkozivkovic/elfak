namespace Zatvor.Forme_za_OSTALO
{
    partial class AdvokatZatvorenici
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
            listaZatvorenika = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            gbxZatvorenici = new GroupBox();
            btnDodajZastupanje = new Button();
            btnOtkaziZastupanje = new Button();
            gbxLista.SuspendLayout();
            gbxZatvorenici.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZatvorenika);
            gbxLista.Location = new Point(12, 25);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(659, 192);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zatvorenika";
            // 
            // listaZatvorenika
            // 
            listaZatvorenika.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader14, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader12, columnHeader13 });
            listaZatvorenika.Dock = DockStyle.Fill;
            listaZatvorenika.FullRowSelect = true;
            listaZatvorenika.GridLines = true;
            listaZatvorenika.Location = new Point(3, 24);
            listaZatvorenika.Margin = new Padding(4);
            listaZatvorenika.Name = "listaZatvorenika";
            listaZatvorenika.Size = new Size(653, 164);
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
            // columnHeader14
            // 
            columnHeader14.Text = "Zatvorska jedinica";
            columnHeader14.Width = 180;
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
            // columnHeader12
            // 
            columnHeader12.Text = "Datum dodele advokata";
            columnHeader12.Width = 240;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "Poslednji kontakt sa advokatom";
            columnHeader13.Width = 240;
            // 
            // gbxZatvorenici
            // 
            gbxZatvorenici.Controls.Add(btnDodajZastupanje);
            gbxZatvorenici.Controls.Add(btnOtkaziZastupanje);
            gbxZatvorenici.Location = new Point(702, 25);
            gbxZatvorenici.Margin = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Name = "gbxZatvorenici";
            gbxZatvorenici.Padding = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Size = new Size(141, 192);
            gbxZatvorenici.TabIndex = 1;
            gbxZatvorenici.TabStop = false;
            gbxZatvorenici.Text = "Zatvorenici";
            // 
            // btnDodajZastupanje
            // 
            btnDodajZastupanje.Location = new Point(9, 28);
            btnDodajZastupanje.Margin = new Padding(3, 4, 3, 4);
            btnDodajZastupanje.Name = "btnDodajZastupanje";
            btnDodajZastupanje.Size = new Size(125, 55);
            btnDodajZastupanje.TabIndex = 0;
            btnDodajZastupanje.Text = "Dodaj zastupanje";
            btnDodajZastupanje.UseVisualStyleBackColor = true;
            btnDodajZastupanje.Click += btnDodajZatvorenika_Click;
            // 
            // btnOtkaziZastupanje
            // 
            btnOtkaziZastupanje.Location = new Point(9, 123);
            btnOtkaziZastupanje.Margin = new Padding(3, 4, 3, 4);
            btnOtkaziZastupanje.Name = "btnOtkaziZastupanje";
            btnOtkaziZastupanje.Size = new Size(125, 55);
            btnOtkaziZastupanje.TabIndex = 1;
            btnOtkaziZastupanje.Text = "Otkaži zastupanje";
            btnOtkaziZastupanje.UseVisualStyleBackColor = true;
            btnOtkaziZastupanje.Click += btnObrisiZatvorenika_Click;
            // 
            // AdvokatZatvorenici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 229);
            Controls.Add(gbxZatvorenici);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(874, 276);
            MinimizeBox = false;
            MinimumSize = new Size(874, 276);
            Name = "AdvokatZatvorenici";
            Text = "ZATVORENICI KOJE ADVOKAT ZASTUPA";
            Load += AdvokatZatvorenici_Load;
            gbxLista.ResumeLayout(false);
            gbxZatvorenici.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaZatvorenika;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private GroupBox gbxZatvorenici;
        private Button btnDodajZastupanje;
        private Button btnOtkaziZastupanje;
    }
}
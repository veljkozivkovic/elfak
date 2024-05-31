namespace Zatvor.Forme_za_OSTALO
{
    partial class FirmaZatvorskeJedinice
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
            btnDodajSaradnju = new Button();
            btnOtkaziSaradnju = new Button();
            gbxOstali = new GroupBox();
            listaOstali = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            gbxLista.SuspendLayout();
            gbxOstali.SuspendLayout();
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
            listaZatvora.Size = new Size(694, 237);
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
            gbxLista.Size = new Size(700, 265);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Zatvori sa kojima postoji saradnja";
            // 
            // btnDodajSaradnju
            // 
            btnDodajSaradnju.Location = new Point(752, 433);
            btnDodajSaradnju.Margin = new Padding(3, 4, 3, 4);
            btnDodajSaradnju.Name = "btnDodajSaradnju";
            btnDodajSaradnju.Size = new Size(125, 55);
            btnDodajSaradnju.TabIndex = 3;
            btnDodajSaradnju.Text = "Dodaj saradnju";
            btnDodajSaradnju.UseVisualStyleBackColor = true;
            btnDodajSaradnju.Click += btnDodajSaradnju_Click;
            // 
            // btnOtkaziSaradnju
            // 
            btnOtkaziSaradnju.Location = new Point(752, 144);
            btnOtkaziSaradnju.Margin = new Padding(3, 4, 3, 4);
            btnOtkaziSaradnju.Name = "btnOtkaziSaradnju";
            btnOtkaziSaradnju.Size = new Size(125, 55);
            btnOtkaziSaradnju.TabIndex = 1;
            btnOtkaziSaradnju.Text = "Obriši saradnju";
            btnOtkaziSaradnju.UseVisualStyleBackColor = true;
            btnOtkaziSaradnju.Click += btnOtkaziSaradnju_Click;
            // 
            // gbxOstali
            // 
            gbxOstali.Controls.Add(listaOstali);
            gbxOstali.Location = new Point(14, 311);
            gbxOstali.Margin = new Padding(3, 4, 3, 4);
            gbxOstali.Name = "gbxOstali";
            gbxOstali.Padding = new Padding(3, 4, 3, 4);
            gbxOstali.Size = new Size(700, 265);
            gbxOstali.TabIndex = 2;
            gbxOstali.TabStop = false;
            gbxOstali.Text = "Ostali zatvori";
            // 
            // listaOstali
            // 
            listaOstali.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12 });
            listaOstali.Dock = DockStyle.Fill;
            listaOstali.FullRowSelect = true;
            listaOstali.GridLines = true;
            listaOstali.Location = new Point(3, 24);
            listaOstali.Margin = new Padding(4);
            listaOstali.Name = "listaOstali";
            listaOstali.Size = new Size(694, 237);
            listaOstali.TabIndex = 0;
            listaOstali.UseCompatibleStateImageBehavior = false;
            listaOstali.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Tag = "sa";
            columnHeader7.Text = "Sifra";
            columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Naziv";
            columnHeader8.Width = 180;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Adresa";
            columnHeader9.Width = 180;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Kapacitet";
            columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Tip";
            columnHeader11.Width = 180;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Period zabrane";
            columnHeader12.Width = 180;
            // 
            // FirmaZatvorskeJedinice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(918, 589);
            Controls.Add(btnDodajSaradnju);
            Controls.Add(gbxOstali);
            Controls.Add(btnOtkaziSaradnju);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(936, 636);
            MinimizeBox = false;
            MinimumSize = new Size(936, 636);
            Name = "FirmaZatvorskeJedinice";
            Text = "ZATVORSKE JEDINICE";
            Load += FirmaZatvorskeJedinice_Load;
            gbxLista.ResumeLayout(false);
            gbxOstali.ResumeLayout(false);
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
        private Button btnDodajSaradnju;
        private Button btnOtkaziSaradnju;
        private ColumnHeader columnHeader6;
        private GroupBox gbxOstali;
        private ListView listaOstali;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
    }
}
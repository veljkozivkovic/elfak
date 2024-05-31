namespace Zatvor.Forme_za_OSTALO
{
    partial class FirmaZatvorenici
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
            btnZaposliZatvorenika = new Button();
            btnDajOtkaz = new Button();
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
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            gbxOstali = new GroupBox();
            listaOstali = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            columnHeader20 = new ColumnHeader();
            columnHeader21 = new ColumnHeader();
            columnHeader22 = new ColumnHeader();
            gbxLista.SuspendLayout();
            gbxOstali.SuspendLayout();
            SuspendLayout();
            // 
            // btnZaposliZatvorenika
            // 
            btnZaposliZatvorenika.Location = new Point(714, 351);
            btnZaposliZatvorenika.Margin = new Padding(3, 4, 3, 4);
            btnZaposliZatvorenika.Name = "btnZaposliZatvorenika";
            btnZaposliZatvorenika.Size = new Size(125, 55);
            btnZaposliZatvorenika.TabIndex = 3;
            btnZaposliZatvorenika.Text = "Zaposli zatvorenika";
            btnZaposliZatvorenika.UseVisualStyleBackColor = true;
            btnZaposliZatvorenika.Click += btnZaposliZatvorenika_Click;
            // 
            // btnDajOtkaz
            // 
            btnDajOtkaz.Location = new Point(714, 100);
            btnDajOtkaz.Margin = new Padding(3, 4, 3, 4);
            btnDajOtkaz.Name = "btnDajOtkaz";
            btnDajOtkaz.Size = new Size(125, 55);
            btnDajOtkaz.TabIndex = 1;
            btnDajOtkaz.Text = "Daj otkaz zatvoreniku";
            btnDajOtkaz.UseVisualStyleBackColor = true;
            btnDajOtkaz.Click += btnDajOtkaz_Click;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZatvorenika);
            gbxLista.Location = new Point(12, 30);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(659, 200);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Zatvorenici koji rade u firmi";
            // 
            // listaZatvorenika
            // 
            listaZatvorenika.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader14, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader11, columnHeader12, columnHeader13 });
            listaZatvorenika.Dock = DockStyle.Fill;
            listaZatvorenika.FullRowSelect = true;
            listaZatvorenika.GridLines = true;
            listaZatvorenika.Location = new Point(3, 24);
            listaZatvorenika.Margin = new Padding(4);
            listaZatvorenika.Name = "listaZatvorenika";
            listaZatvorenika.Size = new Size(653, 172);
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
            // columnHeader11
            // 
            columnHeader11.Text = "Advokat";
            columnHeader11.Width = 220;
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
            // gbxOstali
            // 
            gbxOstali.Controls.Add(listaOstali);
            gbxOstali.Location = new Point(15, 273);
            gbxOstali.Margin = new Padding(3, 4, 3, 4);
            gbxOstali.Name = "gbxOstali";
            gbxOstali.Padding = new Padding(3, 4, 3, 4);
            gbxOstali.Size = new Size(659, 200);
            gbxOstali.TabIndex = 2;
            gbxOstali.TabStop = false;
            gbxOstali.Text = "Zatvorenici koji mogu da rade u firmi";
            // 
            // listaOstali
            // 
            listaOstali.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader15, columnHeader16, columnHeader17, columnHeader18, columnHeader19, columnHeader20, columnHeader21, columnHeader22 });
            listaOstali.Dock = DockStyle.Fill;
            listaOstali.FullRowSelect = true;
            listaOstali.GridLines = true;
            listaOstali.Location = new Point(3, 24);
            listaOstali.Margin = new Padding(4);
            listaOstali.Name = "listaOstali";
            listaOstali.Size = new Size(653, 172);
            listaOstali.TabIndex = 0;
            listaOstali.UseCompatibleStateImageBehavior = false;
            listaOstali.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Tag = "sa";
            columnHeader8.Text = "Sifra";
            columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Ime";
            columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Prezime";
            columnHeader10.Width = 120;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "Zatvorska jedinica";
            columnHeader15.Width = 180;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Adresa";
            columnHeader16.Width = 240;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Pol";
            columnHeader17.Width = 40;
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Status uslovnog otpusta";
            columnHeader18.Width = 200;
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Datum sledećeg saslušanja";
            columnHeader19.Width = 200;
            // 
            // columnHeader20
            // 
            columnHeader20.Text = "Advokat";
            columnHeader20.Width = 220;
            // 
            // columnHeader21
            // 
            columnHeader21.Text = "Datum dodele advokata";
            columnHeader21.Width = 240;
            // 
            // columnHeader22
            // 
            columnHeader22.Text = "Poslednji kontakt sa advokatom";
            columnHeader22.Width = 240;
            // 
            // FirmaZatvorenici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 488);
            Controls.Add(gbxOstali);
            Controls.Add(gbxLista);
            Controls.Add(btnZaposliZatvorenika);
            Controls.Add(btnDajOtkaz);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(876, 535);
            MinimizeBox = false;
            MinimumSize = new Size(876, 535);
            Name = "FirmaZatvorenici";
            Text = "ZATVORENICI";
            Load += FirmaZatvorenici_Load;
            gbxLista.ResumeLayout(false);
            gbxOstali.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnZaposliZatvorenika;
        private Button btnDajOtkaz;
        private GroupBox gbxLista;
        private ListView listaZatvorenika;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private GroupBox gbxOstali;
        private ListView listaOstali;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader22;
    }
}
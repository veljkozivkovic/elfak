namespace Zatvor.Forme_za_Zatvorenike
{
    partial class FZatvorenici
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
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            gbxZatvorenici = new GroupBox();
            btnDodajZatvorenika = new Button();
            btnIzmeniZatvorenika = new Button();
            btnObrisiZatvorenika = new Button();
            btnPrestupi = new Button();
            gbxPrestupi = new GroupBox();
            gbxAngazovanja = new GroupBox();
            btnAngažovanja = new Button();
            gbxPosete = new GroupBox();
            btnPosete = new Button();
            gbxLista.SuspendLayout();
            gbxZatvorenici.SuspendLayout();
            gbxPrestupi.SuspendLayout();
            gbxAngazovanja.SuspendLayout();
            gbxPosete.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZatvorenika);
            gbxLista.Location = new Point(12, 25);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(659, 637);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zatvorenika";
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
            listaZatvorenika.Size = new Size(653, 609);
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
            // gbxZatvorenici
            // 
            gbxZatvorenici.Controls.Add(btnDodajZatvorenika);
            gbxZatvorenici.Controls.Add(btnIzmeniZatvorenika);
            gbxZatvorenici.Controls.Add(btnObrisiZatvorenika);
            gbxZatvorenici.Location = new Point(702, 25);
            gbxZatvorenici.Margin = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Name = "gbxZatvorenici";
            gbxZatvorenici.Padding = new Padding(3, 4, 3, 4);
            gbxZatvorenici.Size = new Size(141, 288);
            gbxZatvorenici.TabIndex = 1;
            gbxZatvorenici.TabStop = false;
            gbxZatvorenici.Text = "Zatvorenici";
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
            // btnPrestupi
            // 
            btnPrestupi.Location = new Point(9, 28);
            btnPrestupi.Margin = new Padding(3, 4, 3, 4);
            btnPrestupi.Name = "btnPrestupi";
            btnPrestupi.Size = new Size(125, 55);
            btnPrestupi.TabIndex = 0;
            btnPrestupi.Text = "Prestupi";
            btnPrestupi.UseVisualStyleBackColor = true;
            btnPrestupi.Click += btnPrestupi_Click;
            // 
            // gbxPrestupi
            // 
            gbxPrestupi.Controls.Add(btnPrestupi);
            gbxPrestupi.Location = new Point(702, 334);
            gbxPrestupi.Margin = new Padding(3, 4, 3, 4);
            gbxPrestupi.Name = "gbxPrestupi";
            gbxPrestupi.Padding = new Padding(3, 4, 3, 4);
            gbxPrestupi.Size = new Size(141, 94);
            gbxPrestupi.TabIndex = 2;
            gbxPrestupi.TabStop = false;
            gbxPrestupi.Text = "Prestupi";
            // 
            // gbxAngazovanja
            // 
            gbxAngazovanja.Controls.Add(btnAngažovanja);
            gbxAngazovanja.Location = new Point(702, 454);
            gbxAngazovanja.Margin = new Padding(3, 4, 3, 4);
            gbxAngazovanja.Name = "gbxAngazovanja";
            gbxAngazovanja.Padding = new Padding(3, 4, 3, 4);
            gbxAngazovanja.Size = new Size(141, 94);
            gbxAngazovanja.TabIndex = 3;
            gbxAngazovanja.TabStop = false;
            gbxAngazovanja.Text = "Angažovanja";
            // 
            // btnAngažovanja
            // 
            btnAngažovanja.Location = new Point(9, 28);
            btnAngažovanja.Margin = new Padding(3, 4, 3, 4);
            btnAngažovanja.Name = "btnAngažovanja";
            btnAngažovanja.Size = new Size(125, 55);
            btnAngažovanja.TabIndex = 0;
            btnAngažovanja.Text = "Angažovanja";
            btnAngažovanja.UseVisualStyleBackColor = true;
            btnAngažovanja.Click += btnAngažovanja_Click;
            // 
            // gbxPosete
            // 
            gbxPosete.Controls.Add(btnPosete);
            gbxPosete.Location = new Point(702, 568);
            gbxPosete.Margin = new Padding(3, 4, 3, 4);
            gbxPosete.Name = "gbxPosete";
            gbxPosete.Padding = new Padding(3, 4, 3, 4);
            gbxPosete.Size = new Size(141, 94);
            gbxPosete.TabIndex = 4;
            gbxPosete.TabStop = false;
            gbxPosete.Text = "Posete";
            // 
            // btnPosete
            // 
            btnPosete.Location = new Point(9, 28);
            btnPosete.Margin = new Padding(3, 4, 3, 4);
            btnPosete.Name = "btnPosete";
            btnPosete.Size = new Size(125, 55);
            btnPosete.TabIndex = 0;
            btnPosete.Text = "Posete";
            btnPosete.UseVisualStyleBackColor = true;
            btnPosete.Click += btnPosete_Click;
            // 
            // FZatvorenici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 675);
            Controls.Add(gbxPosete);
            Controls.Add(gbxAngazovanja);
            Controls.Add(gbxPrestupi);
            Controls.Add(gbxZatvorenici);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(874, 722);
            MinimizeBox = false;
            MinimumSize = new Size(874, 722);
            Name = "FZatvorenici";
            Text = "ZATVORENICI";
            Load += FZatvorenici_Load;
            gbxLista.ResumeLayout(false);
            gbxZatvorenici.ResumeLayout(false);
            gbxPrestupi.ResumeLayout(false);
            gbxAngazovanja.ResumeLayout(false);
            gbxPosete.ResumeLayout(false);
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
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private GroupBox gbxZatvorenici;
        private Button btnDodajZatvorenika;
        private Button btnIzmeniZatvorenika;
        private Button btnObrisiZatvorenika;
        private Button btnPrestupi;
        private GroupBox gbxPrestupi;
        private GroupBox gbxAngazovanja;
        private Button btnAngažovanja;
        private GroupBox gbxPosete;
        private Button btnPosete;
    }
}
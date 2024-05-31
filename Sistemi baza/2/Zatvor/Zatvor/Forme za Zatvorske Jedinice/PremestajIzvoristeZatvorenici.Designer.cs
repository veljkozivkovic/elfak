namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class PremestajIzvoristeZatvorenici
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
            btnIzaberi = new Button();
            gbxLista = new GroupBox();
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
            gbxLista.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzaberi
            // 
            btnIzaberi.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIzaberi.Location = new Point(751, 224);
            btnIzaberi.Margin = new Padding(3, 4, 3, 4);
            btnIzaberi.Name = "btnIzaberi";
            btnIzaberi.Size = new Size(131, 68);
            btnIzaberi.TabIndex = 1;
            btnIzaberi.Text = "Izaberi";
            btnIzaberi.UseVisualStyleBackColor = true;
            btnIzaberi.Click += btnIzaberi_Click;
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
            // PremestajIzvoristeZatvorenici
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 519);
            Controls.Add(gbxLista);
            Controls.Add(btnIzaberi);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(932, 566);
            MinimizeBox = false;
            MinimumSize = new Size(932, 566);
            Name = "PremestajIzvoristeZatvorenici";
            Text = "ZATVORENICI U ZATVORU IZVORA PREMEŠTAJA";
            Load += PremestajIzvoristeZatvorenici_Load;
            gbxLista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnIzaberi;
        private GroupBox gbxLista;
        private ListView listaZatvorenika;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
    }
}
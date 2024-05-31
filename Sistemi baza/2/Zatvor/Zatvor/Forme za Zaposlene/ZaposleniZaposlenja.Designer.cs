namespace Zatvor.Forme_za_Zaposlene
{
    partial class ZaposleniZaposlenja
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
            listaZaposlenja = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            gbxRadnaMesta = new GroupBox();
            btnDodajRadnoMesta = new Button();
            btnIzmeniRadnoMesto = new Button();
            btnObrisiRadnoMesto = new Button();
            gbxLista.SuspendLayout();
            gbxRadnaMesta.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZaposlenja);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(670, 256);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista radnih mesta";
            // 
            // listaZaposlenja
            // 
            listaZaposlenja.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader6, columnHeader4, columnHeader5 });
            listaZaposlenja.Dock = DockStyle.Fill;
            listaZaposlenja.FullRowSelect = true;
            listaZaposlenja.GridLines = true;
            listaZaposlenja.Location = new Point(3, 24);
            listaZaposlenja.Margin = new Padding(4);
            listaZaposlenja.Name = "listaZaposlenja";
            listaZaposlenja.Size = new Size(664, 228);
            listaZaposlenja.TabIndex = 0;
            listaZaposlenja.UseCompatibleStateImageBehavior = false;
            listaZaposlenja.View = View.Details;
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
            // columnHeader6
            // 
            columnHeader6.Text = "Zatvor";
            columnHeader6.Width = 180;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Naziv radnog mesta";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Datum zaposlenja";
            columnHeader5.Width = 150;
            // 
            // gbxRadnaMesta
            // 
            gbxRadnaMesta.Controls.Add(btnDodajRadnoMesta);
            gbxRadnaMesta.Controls.Add(btnIzmeniRadnoMesto);
            gbxRadnaMesta.Controls.Add(btnObrisiRadnoMesto);
            gbxRadnaMesta.Location = new Point(703, 31);
            gbxRadnaMesta.Margin = new Padding(3, 4, 3, 4);
            gbxRadnaMesta.Name = "gbxRadnaMesta";
            gbxRadnaMesta.Padding = new Padding(3, 4, 3, 4);
            gbxRadnaMesta.Size = new Size(157, 256);
            gbxRadnaMesta.TabIndex = 1;
            gbxRadnaMesta.TabStop = false;
            gbxRadnaMesta.Text = "Radna mesta";
            // 
            // btnDodajRadnoMesta
            // 
            btnDodajRadnoMesta.Location = new Point(10, 28);
            btnDodajRadnoMesta.Margin = new Padding(3, 4, 3, 4);
            btnDodajRadnoMesta.Name = "btnDodajRadnoMesta";
            btnDodajRadnoMesta.Size = new Size(136, 55);
            btnDodajRadnoMesta.TabIndex = 0;
            btnDodajRadnoMesta.Text = "Dodaj novo radno mesto";
            btnDodajRadnoMesta.UseVisualStyleBackColor = true;
            btnDodajRadnoMesta.Click += btnDodajRadnoMesta_Click;
            // 
            // btnIzmeniRadnoMesto
            // 
            btnIzmeniRadnoMesto.Location = new Point(10, 187);
            btnIzmeniRadnoMesto.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniRadnoMesto.Name = "btnIzmeniRadnoMesto";
            btnIzmeniRadnoMesto.Size = new Size(136, 55);
            btnIzmeniRadnoMesto.TabIndex = 2;
            btnIzmeniRadnoMesto.Text = "Izmeni radno mesto";
            btnIzmeniRadnoMesto.UseVisualStyleBackColor = true;
            btnIzmeniRadnoMesto.Click += btnIzmeniRadnoMesto_Click;
            // 
            // btnObrisiRadnoMesto
            // 
            btnObrisiRadnoMesto.Location = new Point(10, 107);
            btnObrisiRadnoMesto.Margin = new Padding(3, 4, 3, 4);
            btnObrisiRadnoMesto.Name = "btnObrisiRadnoMesto";
            btnObrisiRadnoMesto.Size = new Size(136, 55);
            btnObrisiRadnoMesto.TabIndex = 1;
            btnObrisiRadnoMesto.Text = "Obriši radno mesto";
            btnObrisiRadnoMesto.UseVisualStyleBackColor = true;
            btnObrisiRadnoMesto.Click += btnObrisiRadnoMesto_Click;
            // 
            // ZaposleniZaposlenja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 297);
            Controls.Add(gbxRadnaMesta);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(889, 344);
            MinimizeBox = false;
            MinimumSize = new Size(889, 344);
            Name = "ZaposleniZaposlenja";
            Text = "RADNA MESTA ZAPOSLENOG";
            Load += ZaposleniZaposlenja_Load;
            gbxLista.ResumeLayout(false);
            gbxRadnaMesta.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaZaposlenja;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox gbxRadnaMesta;
        private Button btnDodajRadnoMesta;
        private Button btnIzmeniRadnoMesto;
        private Button btnObrisiRadnoMesto;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}
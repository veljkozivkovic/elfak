namespace Zatvor.Forme_za_Zaposlene
{
    partial class LekarskiPregledi
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
            listaPregleda = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            gbxLekarskiPregledi = new GroupBox();
            btnDodajPregled = new Button();
            btnIzmeniRadnoMesto = new Button();
            btnObrisiPregled = new Button();
            gbxLista.SuspendLayout();
            gbxLekarskiPregledi.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaPregleda);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(670, 256);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista lekarskih pregleda";
            // 
            // listaPregleda
            // 
            listaPregleda.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader6, columnHeader4 });
            listaPregleda.Dock = DockStyle.Fill;
            listaPregleda.FullRowSelect = true;
            listaPregleda.GridLines = true;
            listaPregleda.Location = new Point(3, 24);
            listaPregleda.Margin = new Padding(4);
            listaPregleda.Name = "listaPregleda";
            listaPregleda.Size = new Size(664, 228);
            listaPregleda.TabIndex = 0;
            listaPregleda.UseCompatibleStateImageBehavior = false;
            listaPregleda.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "ID";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Datum";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Naziv ustanove";
            columnHeader3.Width = 220;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Adresa ustanove";
            columnHeader6.Width = 220;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Lekar";
            columnHeader4.Width = 150;
            // 
            // gbxLekarskiPregledi
            // 
            gbxLekarskiPregledi.Controls.Add(btnDodajPregled);
            gbxLekarskiPregledi.Controls.Add(btnIzmeniRadnoMesto);
            gbxLekarskiPregledi.Controls.Add(btnObrisiPregled);
            gbxLekarskiPregledi.Location = new Point(703, 31);
            gbxLekarskiPregledi.Margin = new Padding(3, 4, 3, 4);
            gbxLekarskiPregledi.Name = "gbxLekarskiPregledi";
            gbxLekarskiPregledi.Padding = new Padding(3, 4, 3, 4);
            gbxLekarskiPregledi.Size = new Size(157, 256);
            gbxLekarskiPregledi.TabIndex = 1;
            gbxLekarskiPregledi.TabStop = false;
            gbxLekarskiPregledi.Text = "Lekarski pregledi";
            // 
            // btnDodajPregled
            // 
            btnDodajPregled.Location = new Point(10, 28);
            btnDodajPregled.Margin = new Padding(3, 4, 3, 4);
            btnDodajPregled.Name = "btnDodajPregled";
            btnDodajPregled.Size = new Size(136, 55);
            btnDodajPregled.TabIndex = 0;
            btnDodajPregled.Text = "Dodaj lekarski pregled";
            btnDodajPregled.UseVisualStyleBackColor = true;
            btnDodajPregled.Click += btnDodajPregled_Click;
            // 
            // btnIzmeniRadnoMesto
            // 
            btnIzmeniRadnoMesto.Location = new Point(10, 187);
            btnIzmeniRadnoMesto.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniRadnoMesto.Name = "btnIzmeniRadnoMesto";
            btnIzmeniRadnoMesto.Size = new Size(136, 55);
            btnIzmeniRadnoMesto.TabIndex = 2;
            btnIzmeniRadnoMesto.Text = "Izmeni lekarski pregled";
            btnIzmeniRadnoMesto.UseVisualStyleBackColor = true;
            btnIzmeniRadnoMesto.Click += btnIzmeniRadnoMesto_Click;
            // 
            // btnObrisiPregled
            // 
            btnObrisiPregled.Location = new Point(10, 107);
            btnObrisiPregled.Margin = new Padding(3, 4, 3, 4);
            btnObrisiPregled.Name = "btnObrisiPregled";
            btnObrisiPregled.Size = new Size(136, 55);
            btnObrisiPregled.TabIndex = 1;
            btnObrisiPregled.Text = "Obriši lekarski pregled";
            btnObrisiPregled.UseVisualStyleBackColor = true;
            btnObrisiPregled.Click += btnObrisiPregled_Click;
            // 
            // LekarskiPregledi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 297);
            Controls.Add(gbxLekarskiPregledi);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(889, 344);
            MinimizeBox = false;
            MinimumSize = new Size(889, 344);
            Name = "LekarskiPregledi";
            Text = "LEKARSKI PREGLEDI";
            Load += LekarskiPregledi_Load;
            gbxLista.ResumeLayout(false);
            gbxLekarskiPregledi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaPregleda;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox gbxLekarskiPregledi;
        private Button btnDodajPregled;
        private Button btnIzmeniRadnoMesto;
        private Button btnObrisiPregled;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
    }
}
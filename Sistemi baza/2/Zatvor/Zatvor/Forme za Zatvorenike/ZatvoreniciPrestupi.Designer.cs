namespace Zatvor.Forme_za_Zatvorenike
{
    partial class ZatvoreniciPrestupi
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
            listaPrestupa = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            gbxPrestupi = new GroupBox();
            btnDodajPrestup = new Button();
            btnIzmeniPrestup = new Button();
            btnObrisiPrestup = new Button();
            gbxLista.SuspendLayout();
            gbxPrestupi.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaPrestupa);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 287);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista prestupa";
            // 
            // listaPrestupa
            // 
            listaPrestupa.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader8, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listaPrestupa.Dock = DockStyle.Fill;
            listaPrestupa.FullRowSelect = true;
            listaPrestupa.GridLines = true;
            listaPrestupa.Location = new Point(3, 24);
            listaPrestupa.Margin = new Padding(4);
            listaPrestupa.Name = "listaPrestupa";
            listaPrestupa.Size = new Size(694, 259);
            listaPrestupa.TabIndex = 0;
            listaPrestupa.UseCompatibleStateImageBehavior = false;
            listaPrestupa.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "ID";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Naziv prestupa";
            columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Mesto";
            columnHeader3.Width = 260;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Datum";
            columnHeader8.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Kategorija";
            columnHeader4.Width = 260;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Opis";
            columnHeader5.Width = 560;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Minimalna kazna";
            columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Maksimalna kazna";
            columnHeader7.Width = 140;
            // 
            // gbxPrestupi
            // 
            gbxPrestupi.Controls.Add(btnDodajPrestup);
            gbxPrestupi.Controls.Add(btnIzmeniPrestup);
            gbxPrestupi.Controls.Add(btnObrisiPrestup);
            gbxPrestupi.Location = new Point(746, 31);
            gbxPrestupi.Margin = new Padding(3, 4, 3, 4);
            gbxPrestupi.Name = "gbxPrestupi";
            gbxPrestupi.Padding = new Padding(3, 4, 3, 4);
            gbxPrestupi.Size = new Size(157, 287);
            gbxPrestupi.TabIndex = 1;
            gbxPrestupi.TabStop = false;
            gbxPrestupi.Text = "Zaposleni";
            // 
            // btnDodajPrestup
            // 
            btnDodajPrestup.Location = new Point(10, 47);
            btnDodajPrestup.Margin = new Padding(3, 4, 3, 4);
            btnDodajPrestup.Name = "btnDodajPrestup";
            btnDodajPrestup.Size = new Size(136, 55);
            btnDodajPrestup.TabIndex = 0;
            btnDodajPrestup.Text = "Dodaj prestup";
            btnDodajPrestup.UseVisualStyleBackColor = true;
            btnDodajPrestup.Click += btnDodajPrestup_Click;
            // 
            // btnIzmeniPrestup
            // 
            btnIzmeniPrestup.Location = new Point(10, 218);
            btnIzmeniPrestup.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniPrestup.Name = "btnIzmeniPrestup";
            btnIzmeniPrestup.Size = new Size(136, 55);
            btnIzmeniPrestup.TabIndex = 2;
            btnIzmeniPrestup.Text = "Izmeni prestup";
            btnIzmeniPrestup.UseVisualStyleBackColor = true;
            btnIzmeniPrestup.Click += btnIzmeniPrestup_Click;
            // 
            // btnObrisiPrestup
            // 
            btnObrisiPrestup.Location = new Point(10, 130);
            btnObrisiPrestup.Margin = new Padding(3, 4, 3, 4);
            btnObrisiPrestup.Name = "btnObrisiPrestup";
            btnObrisiPrestup.Size = new Size(136, 55);
            btnObrisiPrestup.TabIndex = 1;
            btnObrisiPrestup.Text = "Obriši prestup";
            btnObrisiPrestup.UseVisualStyleBackColor = true;
            btnObrisiPrestup.Click += btnObrisiPrestup_Click;
            // 
            // ZatvoreniciPrestupi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 328);
            Controls.Add(gbxPrestupi);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(934, 375);
            MinimizeBox = false;
            MinimumSize = new Size(934, 375);
            Name = "ZatvoreniciPrestupi";
            Text = "PRESTUPI ZATVORENIKA";
            Load += ZatvoreniciPrestupi_Load;
            gbxLista.ResumeLayout(false);
            gbxPrestupi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaPrestupa;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private GroupBox gbxPrestupi;
        private Button btnDodajPrestup;
        private Button btnIzmeniPrestup;
        private Button btnObrisiPrestup;
        private ColumnHeader columnHeader8;
    }
}
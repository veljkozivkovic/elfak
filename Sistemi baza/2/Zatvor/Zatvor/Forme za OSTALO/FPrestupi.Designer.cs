namespace Zatvor.Forme_za_OSTALO
{
    partial class FPrestupi
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
            gbxPodaci = new GroupBox();
            btnDodajPrestup = new Button();
            btnIzmeniPrestup = new Button();
            btnObrisiPrestup = new Button();
            gbxLista = new GroupBox();
            listaPrestupa = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            gbxPodaci.SuspendLayout();
            gbxLista.SuspendLayout();
            SuspendLayout();
            // 
            // gbxPodaci
            // 
            gbxPodaci.Controls.Add(btnDodajPrestup);
            gbxPodaci.Controls.Add(btnIzmeniPrestup);
            gbxPodaci.Controls.Add(btnObrisiPrestup);
            gbxPodaci.Location = new Point(744, 31);
            gbxPodaci.Margin = new Padding(3, 4, 3, 4);
            gbxPodaci.Name = "gbxPodaci";
            gbxPodaci.Padding = new Padding(3, 4, 3, 4);
            gbxPodaci.Size = new Size(157, 266);
            gbxPodaci.TabIndex = 1;
            gbxPodaci.TabStop = false;
            gbxPodaci.Text = "Prestup";
            // 
            // btnDodajPrestup
            // 
            btnDodajPrestup.Location = new Point(10, 42);
            btnDodajPrestup.Margin = new Padding(3, 4, 3, 4);
            btnDodajPrestup.Name = "btnDodajPrestup";
            btnDodajPrestup.Size = new Size(136, 55);
            btnDodajPrestup.TabIndex = 0;
            btnDodajPrestup.Text = "Dodaj prestup";
            btnDodajPrestup.UseVisualStyleBackColor = true;
            btnDodajPrestup.Click += btnDodajFirmu_Click;
            // 
            // btnIzmeniPrestup
            // 
            btnIzmeniPrestup.Location = new Point(10, 194);
            btnIzmeniPrestup.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniPrestup.Name = "btnIzmeniPrestup";
            btnIzmeniPrestup.Size = new Size(136, 55);
            btnIzmeniPrestup.TabIndex = 2;
            btnIzmeniPrestup.Text = "Izmeni prestup";
            btnIzmeniPrestup.UseVisualStyleBackColor = true;
            btnIzmeniPrestup.Click += btnIzmeniFirmu_Click;
            // 
            // btnObrisiPrestup
            // 
            btnObrisiPrestup.Location = new Point(10, 120);
            btnObrisiPrestup.Margin = new Padding(3, 4, 3, 4);
            btnObrisiPrestup.Name = "btnObrisiPrestup";
            btnObrisiPrestup.Size = new Size(136, 55);
            btnObrisiPrestup.TabIndex = 1;
            btnObrisiPrestup.Text = "Obriši prestup";
            btnObrisiPrestup.UseVisualStyleBackColor = true;
            btnObrisiPrestup.Click += btnObrisiFirmu_Click;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaPrestupa);
            gbxLista.Location = new Point(12, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 266);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista prestupa";
            // 
            // listaPrestupa
            // 
            listaPrestupa.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listaPrestupa.Dock = DockStyle.Fill;
            listaPrestupa.FullRowSelect = true;
            listaPrestupa.GridLines = true;
            listaPrestupa.Location = new Point(3, 24);
            listaPrestupa.Margin = new Padding(4);
            listaPrestupa.Name = "listaPrestupa";
            listaPrestupa.Size = new Size(694, 238);
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
            // FPrestupi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(917, 310);
            Controls.Add(gbxLista);
            Controls.Add(gbxPodaci);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(935, 357);
            MinimizeBox = false;
            MinimumSize = new Size(935, 357);
            Name = "FPrestupi";
            Text = "PRESTUPI";
            Load += FPrestupi_Load;
            gbxPodaci.ResumeLayout(false);
            gbxLista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxPodaci;
        private Button btnDodajPrestup;
        private Button btnIzmeniPrestup;
        private Button btnObrisiPrestup;
        private GroupBox gbxLista;
        private ListView listaPrestupa;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
    }
}
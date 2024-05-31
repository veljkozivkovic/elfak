namespace Zatvor.Forme_za_OSTALO
{
    partial class FirmaOdgovornaLica
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
            listaOdgovornihLica = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            gbxOdgovornaLica = new GroupBox();
            btnDodajOdgovornoLice = new Button();
            btnIzmeniOdgovornoLice = new Button();
            btnObrisiOdgovornoLice = new Button();
            gbxLista.SuspendLayout();
            gbxOdgovornaLica.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaOdgovornihLica);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(420, 287);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = " Lista odgovornih lica";
            // 
            // listaOdgovornihLica
            // 
            listaOdgovornihLica.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listaOdgovornihLica.Dock = DockStyle.Fill;
            listaOdgovornihLica.FullRowSelect = true;
            listaOdgovornihLica.GridLines = true;
            listaOdgovornihLica.Location = new Point(3, 24);
            listaOdgovornihLica.Margin = new Padding(4);
            listaOdgovornihLica.Name = "listaOdgovornihLica";
            listaOdgovornihLica.Size = new Size(414, 259);
            listaOdgovornihLica.TabIndex = 0;
            listaOdgovornihLica.UseCompatibleStateImageBehavior = false;
            listaOdgovornihLica.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "ID";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Prezime";
            columnHeader3.Width = 180;
            // 
            // gbxOdgovornaLica
            // 
            gbxOdgovornaLica.Controls.Add(btnDodajOdgovornoLice);
            gbxOdgovornaLica.Controls.Add(btnIzmeniOdgovornoLice);
            gbxOdgovornaLica.Controls.Add(btnObrisiOdgovornoLice);
            gbxOdgovornaLica.Location = new Point(451, 31);
            gbxOdgovornaLica.Margin = new Padding(3, 4, 3, 4);
            gbxOdgovornaLica.Name = "gbxOdgovornaLica";
            gbxOdgovornaLica.Padding = new Padding(3, 4, 3, 4);
            gbxOdgovornaLica.Size = new Size(192, 287);
            gbxOdgovornaLica.TabIndex = 1;
            gbxOdgovornaLica.TabStop = false;
            gbxOdgovornaLica.Text = "Odgovorno lice";
            // 
            // btnDodajOdgovornoLice
            // 
            btnDodajOdgovornoLice.Location = new Point(10, 47);
            btnDodajOdgovornoLice.Margin = new Padding(3, 4, 3, 4);
            btnDodajOdgovornoLice.Name = "btnDodajOdgovornoLice";
            btnDodajOdgovornoLice.Size = new Size(171, 55);
            btnDodajOdgovornoLice.TabIndex = 0;
            btnDodajOdgovornoLice.Text = "Dodaj odgovorno lice";
            btnDodajOdgovornoLice.UseVisualStyleBackColor = true;
            btnDodajOdgovornoLice.Click += btnDodajOdgovornoLice_Click;
            // 
            // btnIzmeniOdgovornoLice
            // 
            btnIzmeniOdgovornoLice.Location = new Point(10, 218);
            btnIzmeniOdgovornoLice.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniOdgovornoLice.Name = "btnIzmeniOdgovornoLice";
            btnIzmeniOdgovornoLice.Size = new Size(171, 55);
            btnIzmeniOdgovornoLice.TabIndex = 2;
            btnIzmeniOdgovornoLice.Text = "Izmeni odgovorno lice";
            btnIzmeniOdgovornoLice.UseVisualStyleBackColor = true;
            btnIzmeniOdgovornoLice.Click += btnIzmeniPosetu_Click;
            // 
            // btnObrisiOdgovornoLice
            // 
            btnObrisiOdgovornoLice.Location = new Point(10, 130);
            btnObrisiOdgovornoLice.Margin = new Padding(3, 4, 3, 4);
            btnObrisiOdgovornoLice.Name = "btnObrisiOdgovornoLice";
            btnObrisiOdgovornoLice.Size = new Size(171, 55);
            btnObrisiOdgovornoLice.TabIndex = 1;
            btnObrisiOdgovornoLice.Text = "Obriši odgovorno lice";
            btnObrisiOdgovornoLice.UseVisualStyleBackColor = true;
            btnObrisiOdgovornoLice.Click += btnObrisiPosetu_Click;
            // 
            // FirmaOdgovornaLica
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(658, 328);
            Controls.Add(gbxOdgovornaLica);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(676, 375);
            MinimizeBox = false;
            MinimumSize = new Size(676, 375);
            Name = "FirmaOdgovornaLica";
            Text = "ODGOVORNA LICA";
            Load += FirmaOdgovornaLica_Load;
            gbxLista.ResumeLayout(false);
            gbxOdgovornaLica.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaOdgovornihLica;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox gbxOdgovornaLica;
        private Button btnDodajOdgovornoLice;
        private Button btnIzmeniOdgovornoLice;
        private Button btnObrisiOdgovornoLice;
    }
}
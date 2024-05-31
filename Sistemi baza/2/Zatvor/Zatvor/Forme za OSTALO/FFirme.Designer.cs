namespace Zatvor.Forme_za_OSTALO
{
    partial class FFirme
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
            btnDodajFirmu = new Button();
            btnIzmeniFirmu = new Button();
            btnObrisiFirmu = new Button();
            gbxOdgovornaLica = new GroupBox();
            btnOdgovornaLica = new Button();
            gbxTelefoni = new GroupBox();
            btnTelefoni = new Button();
            gbxLista = new GroupBox();
            listaFirmi = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            gbxSaradnje = new GroupBox();
            btnSaradnje = new Button();
            gbxZatvoreniciRadnici = new GroupBox();
            btnZatvoreniciRadnici = new Button();
            gbxPodaci.SuspendLayout();
            gbxOdgovornaLica.SuspendLayout();
            gbxTelefoni.SuspendLayout();
            gbxLista.SuspendLayout();
            gbxSaradnje.SuspendLayout();
            gbxZatvoreniciRadnici.SuspendLayout();
            SuspendLayout();
            // 
            // gbxPodaci
            // 
            gbxPodaci.Controls.Add(btnDodajFirmu);
            gbxPodaci.Controls.Add(btnIzmeniFirmu);
            gbxPodaci.Controls.Add(btnObrisiFirmu);
            gbxPodaci.Location = new Point(665, 31);
            gbxPodaci.Margin = new Padding(3, 4, 3, 4);
            gbxPodaci.Name = "gbxPodaci";
            gbxPodaci.Padding = new Padding(3, 4, 3, 4);
            gbxPodaci.Size = new Size(157, 287);
            gbxPodaci.TabIndex = 1;
            gbxPodaci.TabStop = false;
            gbxPodaci.Text = "Firme";
            // 
            // btnDodajFirmu
            // 
            btnDodajFirmu.Location = new Point(10, 47);
            btnDodajFirmu.Margin = new Padding(3, 4, 3, 4);
            btnDodajFirmu.Name = "btnDodajFirmu";
            btnDodajFirmu.Size = new Size(136, 55);
            btnDodajFirmu.TabIndex = 0;
            btnDodajFirmu.Text = "Dodaj firmu";
            btnDodajFirmu.UseVisualStyleBackColor = true;
            btnDodajFirmu.Click += btnDodajFirmu_Click;
            // 
            // btnIzmeniFirmu
            // 
            btnIzmeniFirmu.Location = new Point(10, 218);
            btnIzmeniFirmu.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniFirmu.Name = "btnIzmeniFirmu";
            btnIzmeniFirmu.Size = new Size(136, 55);
            btnIzmeniFirmu.TabIndex = 2;
            btnIzmeniFirmu.Text = "Izmeni firmu";
            btnIzmeniFirmu.UseVisualStyleBackColor = true;
            btnIzmeniFirmu.Click += btnIzmeniFirmu_Click;
            // 
            // btnObrisiFirmu
            // 
            btnObrisiFirmu.Location = new Point(10, 136);
            btnObrisiFirmu.Margin = new Padding(3, 4, 3, 4);
            btnObrisiFirmu.Name = "btnObrisiFirmu";
            btnObrisiFirmu.Size = new Size(136, 55);
            btnObrisiFirmu.TabIndex = 1;
            btnObrisiFirmu.Text = "Obriši firmu";
            btnObrisiFirmu.UseVisualStyleBackColor = true;
            btnObrisiFirmu.Click += btnObrisiFirmu_Click;
            // 
            // gbxOdgovornaLica
            // 
            gbxOdgovornaLica.Controls.Add(btnOdgovornaLica);
            gbxOdgovornaLica.Location = new Point(665, 341);
            gbxOdgovornaLica.Margin = new Padding(3, 4, 3, 4);
            gbxOdgovornaLica.Name = "gbxOdgovornaLica";
            gbxOdgovornaLica.Padding = new Padding(3, 4, 3, 4);
            gbxOdgovornaLica.Size = new Size(157, 95);
            gbxOdgovornaLica.TabIndex = 2;
            gbxOdgovornaLica.TabStop = false;
            gbxOdgovornaLica.Text = "Odgovorna lica";
            // 
            // btnOdgovornaLica
            // 
            btnOdgovornaLica.Location = new Point(10, 28);
            btnOdgovornaLica.Margin = new Padding(3, 4, 3, 4);
            btnOdgovornaLica.Name = "btnOdgovornaLica";
            btnOdgovornaLica.Size = new Size(136, 55);
            btnOdgovornaLica.TabIndex = 0;
            btnOdgovornaLica.Text = "Odgovorna lica";
            btnOdgovornaLica.UseVisualStyleBackColor = true;
            btnOdgovornaLica.Click += btnOdgovornaLica_Click;
            // 
            // gbxTelefoni
            // 
            gbxTelefoni.Controls.Add(btnTelefoni);
            gbxTelefoni.Location = new Point(665, 457);
            gbxTelefoni.Margin = new Padding(3, 4, 3, 4);
            gbxTelefoni.Name = "gbxTelefoni";
            gbxTelefoni.Padding = new Padding(3, 4, 3, 4);
            gbxTelefoni.Size = new Size(157, 94);
            gbxTelefoni.TabIndex = 3;
            gbxTelefoni.TabStop = false;
            gbxTelefoni.Text = "Telefoni";
            // 
            // btnTelefoni
            // 
            btnTelefoni.Location = new Point(10, 28);
            btnTelefoni.Margin = new Padding(3, 4, 3, 4);
            btnTelefoni.Name = "btnTelefoni";
            btnTelefoni.Size = new Size(136, 55);
            btnTelefoni.TabIndex = 0;
            btnTelefoni.Text = "Telefoni";
            btnTelefoni.UseVisualStyleBackColor = true;
            btnTelefoni.Click += btnTelefoni_Click;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaFirmi);
            gbxLista.Font = new Font("Segoe UI", 9F);
            gbxLista.Location = new Point(12, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(632, 749);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista firmi";
            // 
            // listaFirmi
            // 
            listaFirmi.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader9 });
            listaFirmi.Dock = DockStyle.Fill;
            listaFirmi.FullRowSelect = true;
            listaFirmi.GridLines = true;
            listaFirmi.Location = new Point(3, 24);
            listaFirmi.Margin = new Padding(4);
            listaFirmi.Name = "listaFirmi";
            listaFirmi.Size = new Size(626, 721);
            listaFirmi.TabIndex = 0;
            listaFirmi.UseCompatibleStateImageBehavior = false;
            listaFirmi.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "PIB";
            columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Ime firme";
            columnHeader2.Width = 260;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Adresa firme";
            columnHeader9.Width = 220;
            // 
            // gbxSaradnje
            // 
            gbxSaradnje.Controls.Add(btnSaradnje);
            gbxSaradnje.Location = new Point(665, 566);
            gbxSaradnje.Margin = new Padding(3, 4, 3, 4);
            gbxSaradnje.Name = "gbxSaradnje";
            gbxSaradnje.Padding = new Padding(3, 4, 3, 4);
            gbxSaradnje.Size = new Size(157, 94);
            gbxSaradnje.TabIndex = 4;
            gbxSaradnje.TabStop = false;
            gbxSaradnje.Text = "Saradnje";
            // 
            // btnSaradnje
            // 
            btnSaradnje.Location = new Point(10, 28);
            btnSaradnje.Margin = new Padding(3, 4, 3, 4);
            btnSaradnje.Name = "btnSaradnje";
            btnSaradnje.Size = new Size(136, 55);
            btnSaradnje.TabIndex = 0;
            btnSaradnje.Text = "Saradnje";
            btnSaradnje.UseVisualStyleBackColor = true;
            btnSaradnje.Click += btnSaradnje_Click;
            // 
            // gbxZatvoreniciRadnici
            // 
            gbxZatvoreniciRadnici.Controls.Add(btnZatvoreniciRadnici);
            gbxZatvoreniciRadnici.Location = new Point(665, 686);
            gbxZatvoreniciRadnici.Margin = new Padding(3, 4, 3, 4);
            gbxZatvoreniciRadnici.Name = "gbxZatvoreniciRadnici";
            gbxZatvoreniciRadnici.Padding = new Padding(3, 4, 3, 4);
            gbxZatvoreniciRadnici.Size = new Size(157, 94);
            gbxZatvoreniciRadnici.TabIndex = 5;
            gbxZatvoreniciRadnici.TabStop = false;
            gbxZatvoreniciRadnici.Text = "Zatvorenici radnici";
            // 
            // btnZatvoreniciRadnici
            // 
            btnZatvoreniciRadnici.Location = new Point(10, 28);
            btnZatvoreniciRadnici.Margin = new Padding(3, 4, 3, 4);
            btnZatvoreniciRadnici.Name = "btnZatvoreniciRadnici";
            btnZatvoreniciRadnici.Size = new Size(136, 55);
            btnZatvoreniciRadnici.TabIndex = 0;
            btnZatvoreniciRadnici.Text = "Zatvorenici radnici";
            btnZatvoreniciRadnici.UseVisualStyleBackColor = true;
            btnZatvoreniciRadnici.Click += btnZatvoreniciRadnici_Click;
            // 
            // FFirme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 792);
            Controls.Add(gbxZatvoreniciRadnici);
            Controls.Add(gbxSaradnje);
            Controls.Add(gbxLista);
            Controls.Add(gbxTelefoni);
            Controls.Add(gbxOdgovornaLica);
            Controls.Add(gbxPodaci);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(856, 839);
            MinimizeBox = false;
            MinimumSize = new Size(856, 839);
            Name = "FFirme";
            Text = "FIRME";
            Load += FFirme_Load;
            gbxPodaci.ResumeLayout(false);
            gbxOdgovornaLica.ResumeLayout(false);
            gbxTelefoni.ResumeLayout(false);
            gbxLista.ResumeLayout(false);
            gbxSaradnje.ResumeLayout(false);
            gbxZatvoreniciRadnici.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxPodaci;
        private Button btnDodajFirmu;
        private Button btnIzmeniFirmu;
        private Button btnObrisiFirmu;
        private GroupBox gbxOdgovornaLica;
        private Button btnOdgovornaLica;
        private GroupBox gbxTelefoni;
        private Button btnTelefoni;
        private GroupBox gbxLista;
        private ListView listaFirmi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader9;
        private GroupBox gbxSaradnje;
        private Button btnSaradnje;
        private GroupBox gbxZatvoreniciRadnici;
        private Button btnZatvoreniciRadnici;
    }
}
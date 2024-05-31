namespace Zatvor.Forme_za_Zatvorenike
{
    partial class ZatvoreniciAngazovanje
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
            listaFirmi = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            btnIzaberi = new Button();
            gbxPodaci = new GroupBox();
            dgvUpravnik = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            btnDajOtkaz = new Button();
            gbxAkcije = new GroupBox();
            gbxLista.SuspendLayout();
            gbxPodaci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpravnik).BeginInit();
            gbxAkcije.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaFirmi);
            gbxLista.Font = new Font("Segoe UI", 9.75F);
            gbxLista.Location = new Point(579, 25);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(632, 285);
            gbxLista.TabIndex = 1;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista firmi";
            // 
            // listaFirmi
            // 
            listaFirmi.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader9 });
            listaFirmi.Dock = DockStyle.Fill;
            listaFirmi.FullRowSelect = true;
            listaFirmi.GridLines = true;
            listaFirmi.Location = new Point(3, 26);
            listaFirmi.Margin = new Padding(4);
            listaFirmi.Name = "listaFirmi";
            listaFirmi.Size = new Size(626, 255);
            listaFirmi.TabIndex = 0;
            listaFirmi.UseCompatibleStateImageBehavior = false;
            listaFirmi.View = View.Details;
            listaFirmi.ItemSelectionChanged += listaFirmi_ItemSelectionChanged;
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
            // btnIzaberi
            // 
            btnIzaberi.Font = new Font("Segoe UI", 9.75F);
            btnIzaberi.Location = new Point(72, 31);
            btnIzaberi.Margin = new Padding(3, 4, 3, 4);
            btnIzaberi.Name = "btnIzaberi";
            btnIzaberi.Size = new Size(180, 74);
            btnIzaberi.TabIndex = 0;
            btnIzaberi.Text = "Izaberi novu firmu";
            btnIzaberi.UseVisualStyleBackColor = true;
            btnIzaberi.Click += btnIzaberi_Click;
            // 
            // gbxPodaci
            // 
            gbxPodaci.Controls.Add(dgvUpravnik);
            gbxPodaci.Font = new Font("Segoe UI", 9.75F);
            gbxPodaci.Location = new Point(13, 25);
            gbxPodaci.Margin = new Padding(4, 5, 4, 5);
            gbxPodaci.Name = "gbxPodaci";
            gbxPodaci.Padding = new Padding(4, 5, 4, 5);
            gbxPodaci.Size = new Size(542, 152);
            gbxPodaci.TabIndex = 0;
            gbxPodaci.TabStop = false;
            gbxPodaci.Text = "Podaci o firmi";
            // 
            // dgvUpravnik
            // 
            dgvUpravnik.AllowUserToAddRows = false;
            dgvUpravnik.AllowUserToDeleteRows = false;
            dgvUpravnik.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpravnik.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2 });
            dgvUpravnik.Dock = DockStyle.Fill;
            dgvUpravnik.Location = new Point(4, 27);
            dgvUpravnik.Name = "dgvUpravnik";
            dgvUpravnik.ReadOnly = true;
            dgvUpravnik.RowHeadersWidth = 51;
            dgvUpravnik.Size = new Size(534, 120);
            dgvUpravnik.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Svojstvo";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 180;
            // 
            // Column2
            // 
            Column2.HeaderText = "Vrednost";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 300;
            // 
            // btnDajOtkaz
            // 
            btnDajOtkaz.Font = new Font("Segoe UI", 9.75F);
            btnDajOtkaz.Location = new Point(322, 31);
            btnDajOtkaz.Margin = new Padding(3, 4, 3, 4);
            btnDajOtkaz.Name = "btnDajOtkaz";
            btnDajOtkaz.Size = new Size(180, 74);
            btnDajOtkaz.TabIndex = 1;
            btnDajOtkaz.Text = "Daj otkaz zatvoreniku";
            btnDajOtkaz.UseVisualStyleBackColor = true;
            btnDajOtkaz.Click += btnDajOtkaz_Click;
            // 
            // gbxAkcije
            // 
            gbxAkcije.Controls.Add(btnDajOtkaz);
            gbxAkcije.Controls.Add(btnIzaberi);
            gbxAkcije.Font = new Font("Segoe UI", 9.75F);
            gbxAkcije.Location = new Point(13, 190);
            gbxAkcije.Margin = new Padding(4, 5, 4, 5);
            gbxAkcije.Name = "gbxAkcije";
            gbxAkcije.Padding = new Padding(4, 5, 4, 5);
            gbxAkcije.Size = new Size(542, 120);
            gbxAkcije.TabIndex = 2;
            gbxAkcije.TabStop = false;
            gbxAkcije.Text = "Akcije";
            // 
            // ZatvoreniciAngazovanje
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1223, 322);
            Controls.Add(gbxAkcije);
            Controls.Add(gbxPodaci);
            Controls.Add(gbxLista);
            MaximizeBox = false;
            MaximumSize = new Size(1241, 369);
            MinimizeBox = false;
            MinimumSize = new Size(1241, 369);
            Name = "ZatvoreniciAngazovanje";
            Text = "ANGAŽOVANJE ZATVORENIKA";
            Load += Angazovanje_Load;
            gbxLista.ResumeLayout(false);
            gbxPodaci.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUpravnik).EndInit();
            gbxAkcije.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaFirmi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader9;
        private Button btnIzaberi;
        private GroupBox gbxPodaci;
        private DataGridView dgvUpravnik;
        private Button btnDajOtkaz;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private GroupBox gbxAkcije;
    }
}
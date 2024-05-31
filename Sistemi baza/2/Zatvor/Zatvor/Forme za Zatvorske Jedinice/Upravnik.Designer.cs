namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class Upravnik
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
            listaZaposlenih = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            btnIzaberi = new Button();
            gbxPodaci = new GroupBox();
            dgvUpravnik = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            gbxLista.SuspendLayout();
            gbxPodaci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUpravnik).BeginInit();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZaposlenih);
            gbxLista.Font = new Font("Segoe UI", 9.75F);
            gbxLista.Location = new Point(465, 25);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 414);
            gbxLista.TabIndex = 1;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zaposlenih";
            // 
            // listaZaposlenih
            // 
            listaZaposlenih.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader8, columnHeader9 });
            listaZaposlenih.Dock = DockStyle.Fill;
            listaZaposlenih.FullRowSelect = true;
            listaZaposlenih.GridLines = true;
            listaZaposlenih.Location = new Point(3, 26);
            listaZaposlenih.Margin = new Padding(4);
            listaZaposlenih.Name = "listaZaposlenih";
            listaZaposlenih.Size = new Size(694, 384);
            listaZaposlenih.TabIndex = 0;
            listaZaposlenih.UseCompatibleStateImageBehavior = false;
            listaZaposlenih.View = View.Details;
            listaZaposlenih.ItemSelectionChanged += listaZaposlenih_ItemSelectionChanged;
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
            // columnHeader4
            // 
            columnHeader4.Text = "Datum protivpožarne obuke";
            columnHeader4.Width = 220;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip";
            columnHeader5.Width = 140;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Zanimanje";
            columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Stručna sprema";
            columnHeader7.Width = 160;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Radno mesto";
            columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Datum početka rada";
            columnHeader9.Width = 180;
            // 
            // btnIzaberi
            // 
            btnIzaberi.Font = new Font("Segoe UI", 9.75F);
            btnIzaberi.Location = new Point(95, 343);
            btnIzaberi.Margin = new Padding(3, 4, 3, 4);
            btnIzaberi.Name = "btnIzaberi";
            btnIzaberi.Size = new Size(261, 78);
            btnIzaberi.TabIndex = 2;
            btnIzaberi.Text = "Izaberi novog upravnika";
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
            gbxPodaci.Size = new Size(432, 297);
            gbxPodaci.TabIndex = 0;
            gbxPodaci.TabStop = false;
            gbxPodaci.Text = "Podaci o upravniku";
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
            dgvUpravnik.Size = new Size(424, 265);
            dgvUpravnik.TabIndex = 0;
            // 
            // Column1
            // 
            Column1.HeaderText = "Svojstvo";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 160;
            // 
            // Column2
            // 
            Column2.HeaderText = "Vrednost";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 210;
            // 
            // Upravnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1175, 446);
            Controls.Add(gbxPodaci);
            Controls.Add(btnIzaberi);
            Controls.Add(gbxLista);
            MaximizeBox = false;
            MaximumSize = new Size(1193, 493);
            MinimizeBox = false;
            MinimumSize = new Size(1193, 493);
            Name = "Upravnik";
            Text = "UPRAVNIK ZATVORSKE JEDINICE";
            Load += Upravnik_Load;
            gbxLista.ResumeLayout(false);
            gbxPodaci.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUpravnik).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaZaposlenih;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private Button btnIzaberi;
        private GroupBox gbxPodaci;
        private DataGridView dgvUpravnik;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
    }
}
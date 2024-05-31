namespace Zatvor.Forme_za_Zaposlene
{
    partial class ZaposleniZaposlenjaDodaj
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
            txtRadnoMesto = new TextBox();
            lblRadnoMesto = new Label();
            dtmZaposlenja = new DateTimePicker();
            lblDatumPocetka = new Label();
            btnDodaj = new Button();
            gbxLista = new GroupBox();
            listaZatvora = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            gbxPodaci.SuspendLayout();
            gbxLista.SuspendLayout();
            SuspendLayout();
            // 
            // gbxPodaci
            // 
            gbxPodaci.Controls.Add(txtRadnoMesto);
            gbxPodaci.Controls.Add(lblRadnoMesto);
            gbxPodaci.Controls.Add(dtmZaposlenja);
            gbxPodaci.Controls.Add(lblDatumPocetka);
            gbxPodaci.Location = new Point(729, 31);
            gbxPodaci.Margin = new Padding(3, 4, 3, 4);
            gbxPodaci.Name = "gbxPodaci";
            gbxPodaci.Padding = new Padding(3, 4, 3, 4);
            gbxPodaci.Size = new Size(387, 126);
            gbxPodaci.TabIndex = 2;
            gbxPodaci.TabStop = false;
            gbxPodaci.Text = "Podaci o zaposlenju";
            // 
            // txtRadnoMesto
            // 
            txtRadnoMesto.Location = new Point(179, 43);
            txtRadnoMesto.Margin = new Padding(4, 5, 4, 5);
            txtRadnoMesto.Name = "txtRadnoMesto";
            txtRadnoMesto.Size = new Size(201, 27);
            txtRadnoMesto.TabIndex = 1;
            // 
            // lblRadnoMesto
            // 
            lblRadnoMesto.AutoSize = true;
            lblRadnoMesto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRadnoMesto.Location = new Point(56, 47);
            lblRadnoMesto.Margin = new Padding(4, 0, 4, 0);
            lblRadnoMesto.Name = "lblRadnoMesto";
            lblRadnoMesto.Size = new Size(115, 23);
            lblRadnoMesto.TabIndex = 0;
            lblRadnoMesto.Text = "Radno mesto:";
            // 
            // dtmZaposlenja
            // 
            dtmZaposlenja.CustomFormat = "dd.MM.yyyy.";
            dtmZaposlenja.Format = DateTimePickerFormat.Custom;
            dtmZaposlenja.Location = new Point(179, 86);
            dtmZaposlenja.Name = "dtmZaposlenja";
            dtmZaposlenja.Size = new Size(201, 27);
            dtmZaposlenja.TabIndex = 3;
            // 
            // lblDatumPocetka
            // 
            lblDatumPocetka.AutoSize = true;
            lblDatumPocetka.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDatumPocetka.Location = new Point(21, 89);
            lblDatumPocetka.Margin = new Padding(4, 0, 4, 0);
            lblDatumPocetka.Name = "lblDatumPocetka";
            lblDatumPocetka.Size = new Size(151, 23);
            lblDatumPocetka.TabIndex = 2;
            lblDatumPocetka.Text = "Datum zaposlenja:";
            // 
            // btnDodaj
            // 
            btnDodaj.BackColor = Color.Transparent;
            btnDodaj.Font = new Font("Segoe UI", 9F);
            btnDodaj.Location = new Point(873, 224);
            btnDodaj.Margin = new Padding(4, 5, 4, 5);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(145, 56);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "DODAJ";
            btnDodaj.UseVisualStyleBackColor = false;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaZatvora);
            gbxLista.Location = new Point(12, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 361);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista zatvora";
            // 
            // listaZatvora
            // 
            listaZatvora.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            listaZatvora.Dock = DockStyle.Fill;
            listaZatvora.FullRowSelect = true;
            listaZatvora.GridLines = true;
            listaZatvora.Location = new Point(3, 24);
            listaZatvora.Margin = new Padding(4);
            listaZatvora.Name = "listaZatvora";
            listaZatvora.Size = new Size(694, 333);
            listaZatvora.TabIndex = 0;
            listaZatvora.UseCompatibleStateImageBehavior = false;
            listaZatvora.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "Sifra";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Naziv";
            columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Adresa";
            columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Kapacitet";
            columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tip";
            columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Period zabrane";
            columnHeader6.Width = 180;
            // 
            // ZaposleniZaposlenjaDodaj
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 413);
            Controls.Add(gbxLista);
            Controls.Add(btnDodaj);
            Controls.Add(gbxPodaci);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(1146, 460);
            MinimizeBox = false;
            MinimumSize = new Size(1146, 460);
            Name = "ZaposleniZaposlenjaDodaj";
            Text = "DODAJ POSTOJEĆEG ZAPOSLENOG";
            Load += ZaposleniZaposlenjaDodaj_Load;
            gbxPodaci.ResumeLayout(false);
            gbxPodaci.PerformLayout();
            gbxLista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxPodaci;
        private TextBox txtRadnoMesto;
        private Label lblRadnoMesto;
        private DateTimePicker dtmZaposlenja;
        private Label lblDatumPocetka;
        private Button btnDodaj;
        private GroupBox gbxLista;
        private ListView listaZatvora;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}
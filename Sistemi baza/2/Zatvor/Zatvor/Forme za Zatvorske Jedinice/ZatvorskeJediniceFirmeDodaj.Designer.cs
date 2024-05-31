namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class ZatvorskeJediniceFirmeDodaj
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
            listaFirmi = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            gbxLista.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzaberi
            // 
            btnIzaberi.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIzaberi.Location = new Point(721, 120);
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
            gbxLista.Controls.Add(listaFirmi);
            gbxLista.Font = new Font("Segoe UI", 9F);
            gbxLista.Location = new Point(12, 25);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(632, 272);
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
            listaFirmi.Size = new Size(626, 244);
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
            // ZatvorskeJediniceFirmeDodaj
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 308);
            Controls.Add(gbxLista);
            Controls.Add(btnIzaberi);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(932, 355);
            MinimizeBox = false;
            MinimumSize = new Size(932, 355);
            Name = "ZatvorskeJediniceFirmeDodaj";
            Text = "DODAJ SARADNJU";
            Load += ZatvorskeJediniceFirmeDodaj_Load;
            gbxLista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnIzaberi;
        private GroupBox gbxLista;
        private ListView listaFirmi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader9;
    }
}
namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class ZatvorskeJediniceFirme
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
            gbxSaradnja = new GroupBox();
            btnDodajSaradnju = new Button();
            btnObrisiSaradnju = new Button();
            gbxLista = new GroupBox();
            listaFirmi = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            gbxSaradnja.SuspendLayout();
            gbxLista.SuspendLayout();
            SuspendLayout();
            // 
            // gbxSaradnja
            // 
            gbxSaradnja.Controls.Add(btnDodajSaradnju);
            gbxSaradnja.Controls.Add(btnObrisiSaradnju);
            gbxSaradnja.Location = new Point(667, 19);
            gbxSaradnja.Margin = new Padding(3, 4, 3, 4);
            gbxSaradnja.Name = "gbxSaradnja";
            gbxSaradnja.Padding = new Padding(3, 4, 3, 4);
            gbxSaradnja.Size = new Size(157, 198);
            gbxSaradnja.TabIndex = 1;
            gbxSaradnja.TabStop = false;
            gbxSaradnja.Text = "Saradnja";
            // 
            // btnDodajSaradnju
            // 
            btnDodajSaradnju.Location = new Point(10, 47);
            btnDodajSaradnju.Margin = new Padding(3, 4, 3, 4);
            btnDodajSaradnju.Name = "btnDodajSaradnju";
            btnDodajSaradnju.Size = new Size(136, 55);
            btnDodajSaradnju.TabIndex = 0;
            btnDodajSaradnju.Text = "Dodaj saradnju";
            btnDodajSaradnju.UseVisualStyleBackColor = true;
            btnDodajSaradnju.Click += btnDodajSaradnju_Click;
            // 
            // btnObrisiSaradnju
            // 
            btnObrisiSaradnju.Location = new Point(10, 130);
            btnObrisiSaradnju.Margin = new Padding(3, 4, 3, 4);
            btnObrisiSaradnju.Name = "btnObrisiSaradnju";
            btnObrisiSaradnju.Size = new Size(136, 55);
            btnObrisiSaradnju.TabIndex = 1;
            btnObrisiSaradnju.Text = "Otkaži saradnju";
            btnObrisiSaradnju.UseVisualStyleBackColor = true;
            btnObrisiSaradnju.Click += btnObrisiSaradnju_Click;
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaFirmi);
            gbxLista.Font = new Font("Segoe UI", 9F);
            gbxLista.Location = new Point(12, 19);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(632, 198);
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
            listaFirmi.Size = new Size(626, 170);
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
            // ZatvorskeJediniceFirme
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 227);
            Controls.Add(gbxLista);
            Controls.Add(gbxSaradnja);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(854, 274);
            MinimizeBox = false;
            MinimumSize = new Size(854, 274);
            Name = "ZatvorskeJediniceFirme";
            Text = "SARADNJA SA FIRMAMA";
            Load += ZatvorskeJediniceFirme_Load;
            gbxSaradnja.ResumeLayout(false);
            gbxLista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxSaradnja;
        private Button btnDodajSaradnju;
        private Button btnObrisiSaradnju;
        private GroupBox gbxLista;
        private ListView listaFirmi;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader9;
    }
}
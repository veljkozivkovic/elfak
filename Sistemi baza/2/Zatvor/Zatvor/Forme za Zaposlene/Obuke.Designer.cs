namespace Zatvor.Forme_za_Zaposlene
{
    partial class Obuke
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
            listaObuka = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            gbxObuke = new GroupBox();
            btnDodajObuku = new Button();
            btnIzmeniObuku = new Button();
            btnObrisiObuku = new Button();
            gbxLista.SuspendLayout();
            gbxObuke.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaObuka);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(441, 256);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista obuka";
            // 
            // listaObuka
            // 
            listaObuka.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listaObuka.Dock = DockStyle.Fill;
            listaObuka.FullRowSelect = true;
            listaObuka.GridLines = true;
            listaObuka.Location = new Point(3, 24);
            listaObuka.Margin = new Padding(4);
            listaObuka.Name = "listaObuka";
            listaObuka.Size = new Size(435, 228);
            listaObuka.TabIndex = 0;
            listaObuka.UseCompatibleStateImageBehavior = false;
            listaObuka.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "Šifra sertifikata";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Datum izdavanja";
            columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Policijska uprava";
            columnHeader3.Width = 180;
            // 
            // gbxObuke
            // 
            gbxObuke.Controls.Add(btnDodajObuku);
            gbxObuke.Controls.Add(btnIzmeniObuku);
            gbxObuke.Controls.Add(btnObrisiObuku);
            gbxObuke.Location = new Point(478, 31);
            gbxObuke.Margin = new Padding(3, 4, 3, 4);
            gbxObuke.Name = "gbxObuke";
            gbxObuke.Padding = new Padding(3, 4, 3, 4);
            gbxObuke.Size = new Size(157, 256);
            gbxObuke.TabIndex = 1;
            gbxObuke.TabStop = false;
            gbxObuke.Text = "Obuke";
            // 
            // btnDodajObuku
            // 
            btnDodajObuku.Location = new Point(10, 28);
            btnDodajObuku.Margin = new Padding(3, 4, 3, 4);
            btnDodajObuku.Name = "btnDodajObuku";
            btnDodajObuku.Size = new Size(136, 55);
            btnDodajObuku.TabIndex = 0;
            btnDodajObuku.Text = "Dodaj obuku za vatreno oružje";
            btnDodajObuku.UseVisualStyleBackColor = true;
            btnDodajObuku.Click += btnDodajObuku_Click;
            // 
            // btnIzmeniObuku
            // 
            btnIzmeniObuku.Location = new Point(10, 187);
            btnIzmeniObuku.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniObuku.Name = "btnIzmeniObuku";
            btnIzmeniObuku.Size = new Size(136, 55);
            btnIzmeniObuku.TabIndex = 2;
            btnIzmeniObuku.Text = "Izmeni obuku";
            btnIzmeniObuku.UseVisualStyleBackColor = true;
            btnIzmeniObuku.Click += btnIzmeniObuku_Click;
            // 
            // btnObrisiObuku
            // 
            btnObrisiObuku.Location = new Point(10, 107);
            btnObrisiObuku.Margin = new Padding(3, 4, 3, 4);
            btnObrisiObuku.Name = "btnObrisiObuku";
            btnObrisiObuku.Size = new Size(136, 55);
            btnObrisiObuku.TabIndex = 1;
            btnObrisiObuku.Text = "Obriši obuku";
            btnObrisiObuku.UseVisualStyleBackColor = true;
            btnObrisiObuku.Click += btnObrisiObuku_Click;
            // 
            // Obuke
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 297);
            Controls.Add(gbxObuke);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(668, 344);
            MinimizeBox = false;
            MinimumSize = new Size(668, 344);
            Name = "Obuke";
            Text = "OBUKE";
            Load += Obuke_Load;
            gbxLista.ResumeLayout(false);
            gbxObuke.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaObuka;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private GroupBox gbxObuke;
        private Button btnDodajObuku;
        private Button btnIzmeniObuku;
        private Button btnObrisiObuku;
    }
}
namespace Zatvor.Forme_za_Zatvorske_Jedinice
{
    partial class PremestajOdrediste
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
            listaZatvora = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            gbxLista.SuspendLayout();
            SuspendLayout();
            // 
            // btnIzaberi
            // 
            btnIzaberi.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIzaberi.Location = new Point(750, 288);
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
            gbxLista.Controls.Add(listaZatvora);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(700, 556);
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
            listaZatvora.Size = new Size(694, 528);
            listaZatvora.TabIndex = 0;
            listaZatvora.UseCompatibleStateImageBehavior = false;
            listaZatvora.View = View.Details;
            listaZatvora.ItemSelectionChanged += listaZatvora_ItemSelectionChanged;
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
            // PremestajOdrediste
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(gbxLista);
            Controls.Add(btnIzaberi);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(932, 647);
            MinimizeBox = false;
            MinimumSize = new Size(932, 647);
            Name = "PremestajOdrediste";
            Text = "DESTINACIJA PREMEŠTAJA";
            Load += PremestajOdrediste_Load;
            gbxLista.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnIzaberi;
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
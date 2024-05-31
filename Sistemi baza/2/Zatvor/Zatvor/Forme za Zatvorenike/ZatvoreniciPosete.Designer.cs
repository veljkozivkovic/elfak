namespace Zatvor.Forme_za_Zatvorenike
{
    partial class ZatvoreniciPosete
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
            listaPoseta = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            gbxPrestupi = new GroupBox();
            btnDodajPosetu = new Button();
            btnIzmeniPosetu = new Button();
            btnObrisiPosetu = new Button();
            gbxLista.SuspendLayout();
            gbxPrestupi.SuspendLayout();
            SuspendLayout();
            // 
            // gbxLista
            // 
            gbxLista.Controls.Add(listaPoseta);
            gbxLista.Location = new Point(14, 31);
            gbxLista.Margin = new Padding(3, 4, 3, 4);
            gbxLista.Name = "gbxLista";
            gbxLista.Padding = new Padding(3, 4, 3, 4);
            gbxLista.Size = new Size(591, 287);
            gbxLista.TabIndex = 0;
            gbxLista.TabStop = false;
            gbxLista.Text = "Lista poseta";
            // 
            // listaPoseta
            // 
            listaPoseta.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader8, columnHeader4 });
            listaPoseta.Dock = DockStyle.Fill;
            listaPoseta.FullRowSelect = true;
            listaPoseta.GridLines = true;
            listaPoseta.Location = new Point(3, 24);
            listaPoseta.Margin = new Padding(4);
            listaPoseta.Name = "listaPoseta";
            listaPoseta.Size = new Size(585, 259);
            listaPoseta.TabIndex = 0;
            listaPoseta.UseCompatibleStateImageBehavior = false;
            listaPoseta.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Tag = "sa";
            columnHeader1.Text = "ID";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Advokat";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Datum";
            columnHeader3.Width = 100;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Vreme od";
            columnHeader8.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Vreme do";
            columnHeader4.Width = 100;
            // 
            // gbxPrestupi
            // 
            gbxPrestupi.Controls.Add(btnDodajPosetu);
            gbxPrestupi.Controls.Add(btnIzmeniPosetu);
            gbxPrestupi.Controls.Add(btnObrisiPosetu);
            gbxPrestupi.Location = new Point(629, 31);
            gbxPrestupi.Margin = new Padding(3, 4, 3, 4);
            gbxPrestupi.Name = "gbxPrestupi";
            gbxPrestupi.Padding = new Padding(3, 4, 3, 4);
            gbxPrestupi.Size = new Size(157, 287);
            gbxPrestupi.TabIndex = 1;
            gbxPrestupi.TabStop = false;
            gbxPrestupi.Text = "Posete";
            // 
            // btnDodajPosetu
            // 
            btnDodajPosetu.Location = new Point(10, 47);
            btnDodajPosetu.Margin = new Padding(3, 4, 3, 4);
            btnDodajPosetu.Name = "btnDodajPosetu";
            btnDodajPosetu.Size = new Size(136, 55);
            btnDodajPosetu.TabIndex = 0;
            btnDodajPosetu.Text = "Dodaj posetu";
            btnDodajPosetu.UseVisualStyleBackColor = true;
            btnDodajPosetu.Click += btnDodajPosetu_Click;
            // 
            // btnIzmeniPosetu
            // 
            btnIzmeniPosetu.Location = new Point(10, 218);
            btnIzmeniPosetu.Margin = new Padding(3, 4, 3, 4);
            btnIzmeniPosetu.Name = "btnIzmeniPosetu";
            btnIzmeniPosetu.Size = new Size(136, 55);
            btnIzmeniPosetu.TabIndex = 2;
            btnIzmeniPosetu.Text = "Izmeni posetu";
            btnIzmeniPosetu.UseVisualStyleBackColor = true;
            btnIzmeniPosetu.Click += btnIzmeniPosetu_Click;
            // 
            // btnObrisiPosetu
            // 
            btnObrisiPosetu.Location = new Point(10, 130);
            btnObrisiPosetu.Margin = new Padding(3, 4, 3, 4);
            btnObrisiPosetu.Name = "btnObrisiPosetu";
            btnObrisiPosetu.Size = new Size(136, 55);
            btnObrisiPosetu.TabIndex = 1;
            btnObrisiPosetu.Text = "Obriši posetu";
            btnObrisiPosetu.UseVisualStyleBackColor = true;
            btnObrisiPosetu.Click += btnObrisiPosetu_Click;
            // 
            // ZatvoreniciPosete
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 328);
            Controls.Add(gbxPrestupi);
            Controls.Add(gbxLista);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(816, 375);
            MinimizeBox = false;
            MinimumSize = new Size(816, 375);
            Name = "ZatvoreniciPosete";
            Text = "POSETE ZATVORENIKA";
            Load += ZatvoreniciPrestupi_Load;
            gbxLista.ResumeLayout(false);
            gbxPrestupi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox gbxLista;
        private ListView listaPoseta;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private GroupBox gbxPrestupi;
        private Button btnDodajPosetu;
        private Button btnIzmeniPosetu;
        private Button btnObrisiPosetu;
        private ColumnHeader columnHeader8;
    }
}
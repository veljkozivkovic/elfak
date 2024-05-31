namespace Zatvor.Forme_za_OSTALO;

partial class FirmaTelefoni
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
        listaTelefona = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        gbxPodaci = new GroupBox();
        txtTelefon = new TextBox();
        lblBrojTelefona = new Label();
        gbxTelefoni = new GroupBox();
        btnObrisi = new Button();
        btnIzmeni = new Button();
        btnDodajTelefon = new Button();
        gbxLista.SuspendLayout();
        gbxPodaci.SuspendLayout();
        gbxTelefoni.SuspendLayout();
        SuspendLayout();
        // 
        // gbxLista
        // 
        gbxLista.Controls.Add(listaTelefona);
        gbxLista.Location = new Point(12, 25);
        gbxLista.Margin = new Padding(3, 4, 3, 4);
        gbxLista.Name = "gbxLista";
        gbxLista.Padding = new Padding(3, 4, 3, 4);
        gbxLista.Size = new Size(251, 214);
        gbxLista.TabIndex = 0;
        gbxLista.TabStop = false;
        gbxLista.Text = "Lista telefona";
        // 
        // listaTelefona
        // 
        listaTelefona.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
        listaTelefona.Dock = DockStyle.Fill;
        listaTelefona.FullRowSelect = true;
        listaTelefona.GridLines = true;
        listaTelefona.Location = new Point(3, 24);
        listaTelefona.Margin = new Padding(4);
        listaTelefona.Name = "listaTelefona";
        listaTelefona.Size = new Size(245, 186);
        listaTelefona.TabIndex = 0;
        listaTelefona.UseCompatibleStateImageBehavior = false;
        listaTelefona.View = View.Details;
        listaTelefona.ItemSelectionChanged += listaTelefona_ItemSelectionChanged;
        // 
        // columnHeader1
        // 
        columnHeader1.Tag = "sa";
        columnHeader1.Text = "Id";
        columnHeader1.Width = 80;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Broj telefona";
        columnHeader2.Width = 160;
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(txtTelefon);
        gbxPodaci.Controls.Add(lblBrojTelefona);
        gbxPodaci.Font = new Font("Segoe UI", 9F);
        gbxPodaci.Location = new Point(305, 25);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(372, 93);
        gbxPodaci.TabIndex = 1;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Telefon";
        // 
        // txtTelefon
        // 
        txtTelefon.Location = new Point(145, 47);
        txtTelefon.Margin = new Padding(4, 5, 4, 5);
        txtTelefon.Name = "txtTelefon";
        txtTelefon.Size = new Size(201, 27);
        txtTelefon.TabIndex = 1;
        // 
        // lblBrojTelefona
        // 
        lblBrojTelefona.AutoSize = true;
        lblBrojTelefona.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblBrojTelefona.Location = new Point(26, 48);
        lblBrojTelefona.Margin = new Padding(4, 0, 4, 0);
        lblBrojTelefona.Name = "lblBrojTelefona";
        lblBrojTelefona.Size = new Size(111, 23);
        lblBrojTelefona.TabIndex = 0;
        lblBrojTelefona.Text = "Broj telefona:";
        // 
        // gbxTelefoni
        // 
        gbxTelefoni.Controls.Add(btnObrisi);
        gbxTelefoni.Controls.Add(btnIzmeni);
        gbxTelefoni.Controls.Add(btnDodajTelefon);
        gbxTelefoni.Location = new Point(305, 127);
        gbxTelefoni.Margin = new Padding(3, 4, 3, 4);
        gbxTelefoni.Name = "gbxTelefoni";
        gbxTelefoni.Padding = new Padding(3, 4, 3, 4);
        gbxTelefoni.Size = new Size(372, 112);
        gbxTelefoni.TabIndex = 2;
        gbxTelefoni.TabStop = false;
        gbxTelefoni.Text = "Akcije";
        // 
        // btnObrisi
        // 
        btnObrisi.Location = new Point(250, 38);
        btnObrisi.Margin = new Padding(3, 4, 3, 4);
        btnObrisi.Name = "btnObrisi";
        btnObrisi.Size = new Size(96, 55);
        btnObrisi.TabIndex = 2;
        btnObrisi.Text = "Obriši";
        btnObrisi.UseVisualStyleBackColor = true;
        btnObrisi.Click += btnObrisi_Click;
        // 
        // btnIzmeni
        // 
        btnIzmeni.Location = new Point(139, 38);
        btnIzmeni.Margin = new Padding(3, 4, 3, 4);
        btnIzmeni.Name = "btnIzmeni";
        btnIzmeni.Size = new Size(96, 55);
        btnIzmeni.TabIndex = 1;
        btnIzmeni.Text = "Izmeni";
        btnIzmeni.UseVisualStyleBackColor = true;
        btnIzmeni.Click += btnIzmeni_Click;
        // 
        // btnDodajTelefon
        // 
        btnDodajTelefon.Location = new Point(26, 38);
        btnDodajTelefon.Margin = new Padding(3, 4, 3, 4);
        btnDodajTelefon.Name = "btnDodajTelefon";
        btnDodajTelefon.Size = new Size(96, 55);
        btnDodajTelefon.TabIndex = 0;
        btnDodajTelefon.Text = "Dodaj";
        btnDodajTelefon.UseVisualStyleBackColor = true;
        btnDodajTelefon.Click += btnDodajTelefon_Click;
        // 
        // FirmaTelefoni
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(693, 248);
        Controls.Add(gbxTelefoni);
        Controls.Add(gbxPodaci);
        Controls.Add(gbxLista);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(711, 295);
        MinimizeBox = false;
        MinimumSize = new Size(711, 295);
        Name = "FirmaTelefoni";
        Text = "FIRMA TELEFONI";
        Load += FirmaTelefoni_Load;
        gbxLista.ResumeLayout(false);
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        gbxTelefoni.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private GroupBox gbxLista;
    private ListView listaTelefona;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private GroupBox gbxPodaci;
    private TextBox txtTelefon;
    private Label lblBrojTelefona;
    private GroupBox gbxTelefoni;
    private Button btnObrisi;
    private Button btnIzmeni;
    private Button btnDodajTelefon;
}
namespace Zatvor.Forme_za_OSTALO;

partial class PrestupDodaj
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
        lblNaziv = new Label();
        lblKategorija = new Label();
        gbxPodaci = new GroupBox();
        txtMaxKazna = new TextBox();
        lblMaxKazna = new Label();
        txtMinKazna = new TextBox();
        lblMinKazna = new Label();
        txtOpis = new TextBox();
        btnDodaj = new Button();
        txtKategorija = new TextBox();
        txtNaziv = new TextBox();
        lblOpis = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblNaziv
        // 
        lblNaziv.AutoSize = true;
        lblNaziv.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNaziv.Location = new Point(126, 63);
        lblNaziv.Margin = new Padding(4, 0, 4, 0);
        lblNaziv.Name = "lblNaziv";
        lblNaziv.Size = new Size(56, 23);
        lblNaziv.TabIndex = 0;
        lblNaziv.Text = "Naziv:";
        // 
        // lblKategorija
        // 
        lblKategorija.AutoSize = true;
        lblKategorija.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblKategorija.Location = new Point(91, 114);
        lblKategorija.Margin = new Padding(4, 0, 4, 0);
        lblKategorija.Name = "lblKategorija";
        lblKategorija.Size = new Size(91, 23);
        lblKategorija.TabIndex = 2;
        lblKategorija.Text = "Kategorija:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(txtMaxKazna);
        gbxPodaci.Controls.Add(lblMaxKazna);
        gbxPodaci.Controls.Add(txtMinKazna);
        gbxPodaci.Controls.Add(lblMinKazna);
        gbxPodaci.Controls.Add(txtOpis);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtKategorija);
        gbxPodaci.Controls.Add(txtNaziv);
        gbxPodaci.Controls.Add(lblOpis);
        gbxPodaci.Controls.Add(lblNaziv);
        gbxPodaci.Controls.Add(lblKategorija);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(15, 21);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 400);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o prestupu";
        // 
        // txtMaxKazna
        // 
        txtMaxKazna.Location = new Point(197, 268);
        txtMaxKazna.Margin = new Padding(4, 5, 4, 5);
        txtMaxKazna.Name = "txtMaxKazna";
        txtMaxKazna.Size = new Size(201, 29);
        txtMaxKazna.TabIndex = 9;
        // 
        // lblMaxKazna
        // 
        lblMaxKazna.AutoSize = true;
        lblMaxKazna.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblMaxKazna.Location = new Point(29, 270);
        lblMaxKazna.Margin = new Padding(4, 0, 4, 0);
        lblMaxKazna.Name = "lblMaxKazna";
        lblMaxKazna.Size = new Size(153, 23);
        lblMaxKazna.TabIndex = 8;
        lblMaxKazna.Text = "Maksimalna kazna:";
        // 
        // txtMinKazna
        // 
        txtMinKazna.Location = new Point(197, 217);
        txtMinKazna.Margin = new Padding(4, 5, 4, 5);
        txtMinKazna.Name = "txtMinKazna";
        txtMinKazna.Size = new Size(201, 29);
        txtMinKazna.TabIndex = 7;
        // 
        // lblMinKazna
        // 
        lblMinKazna.AutoSize = true;
        lblMinKazna.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblMinKazna.Location = new Point(39, 219);
        lblMinKazna.Margin = new Padding(4, 0, 4, 0);
        lblMinKazna.Name = "lblMinKazna";
        lblMinKazna.Size = new Size(143, 23);
        lblMinKazna.TabIndex = 6;
        lblMinKazna.Text = "Minimalna kazna:";
        // 
        // txtOpis
        // 
        txtOpis.Location = new Point(197, 166);
        txtOpis.Margin = new Padding(4, 5, 4, 5);
        txtOpis.Name = "txtOpis";
        txtOpis.Size = new Size(201, 29);
        txtOpis.TabIndex = 5;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(253, 319);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 10;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtKategorija
        // 
        txtKategorija.Location = new Point(197, 112);
        txtKategorija.Margin = new Padding(4, 5, 4, 5);
        txtKategorija.Name = "txtKategorija";
        txtKategorija.Size = new Size(201, 29);
        txtKategorija.TabIndex = 3;
        // 
        // txtNaziv
        // 
        txtNaziv.Location = new Point(197, 61);
        txtNaziv.Margin = new Padding(4, 5, 4, 5);
        txtNaziv.Name = "txtNaziv";
        txtNaziv.Size = new Size(201, 29);
        txtNaziv.TabIndex = 1;
        // 
        // lblOpis
        // 
        lblOpis.AutoSize = true;
        lblOpis.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblOpis.Location = new Point(134, 168);
        lblOpis.Margin = new Padding(4, 0, 4, 0);
        lblOpis.Name = "lblOpis";
        lblOpis.Size = new Size(48, 23);
        lblOpis.TabIndex = 4;
        lblOpis.Text = "Opis:";
        // 
        // PrestupDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 434);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 481);
        MinimizeBox = false;
        MinimumSize = new Size(461, 481);
        Name = "PrestupDodaj";
        Text = "DODAVANJE PRESTUPA";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblNaziv;
    private System.Windows.Forms.Label lblKategorija;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtKategorija;
    private System.Windows.Forms.TextBox txtNaziv;
    private System.Windows.Forms.Label lblOpis;
    private System.Windows.Forms.Label lblTip;
    private System.Windows.Forms.Label lblMaxKazna;
    private System.Windows.Forms.Label lblMinKazna;
    private System.Windows.Forms.TextBox txtMaxKazna;
    private System.Windows.Forms.TextBox txtMinKazna;
    private System.Windows.Forms.TextBox txtOpis;

}
namespace Zatvor.Forme_za_OSTALO;

partial class FirmaOdgovornaLicaDodaj
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
        lblIme = new Label();
        gbxPodaci = new GroupBox();
        txtPrezime = new TextBox();
        btnDodaj = new Button();
        txtIme = new TextBox();
        lblPrezime = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblIme
        // 
        lblIme.AutoSize = true;
        lblIme.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblIme.Location = new Point(91, 44);
        lblIme.Margin = new Padding(4, 0, 4, 0);
        lblIme.Name = "lblIme";
        lblIme.Size = new Size(43, 23);
        lblIme.TabIndex = 0;
        lblIme.Text = "Ime:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(txtPrezime);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtIme);
        gbxPodaci.Controls.Add(lblPrezime);
        gbxPodaci.Controls.Add(lblIme);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(15, 21);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(378, 222);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o odgovornom licu";
        // 
        // txtPrezime
        // 
        txtPrezime.Location = new Point(154, 96);
        txtPrezime.Margin = new Padding(4, 5, 4, 5);
        txtPrezime.Name = "txtPrezime";
        txtPrezime.Size = new Size(201, 29);
        txtPrezime.TabIndex = 3;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(210, 146);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 4;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtIme
        // 
        txtIme.Location = new Point(154, 42);
        txtIme.Margin = new Padding(4, 5, 4, 5);
        txtIme.Name = "txtIme";
        txtIme.Size = new Size(201, 29);
        txtIme.TabIndex = 1;
        // 
        // lblPrezime
        // 
        lblPrezime.AutoSize = true;
        lblPrezime.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPrezime.Location = new Point(59, 98);
        lblPrezime.Margin = new Padding(4, 0, 4, 0);
        lblPrezime.Name = "lblPrezime";
        lblPrezime.Size = new Size(75, 23);
        lblPrezime.TabIndex = 2;
        lblPrezime.Text = "Prezime:";
        // 
        // FirmaOdgovornaLicaDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(407, 254);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(425, 301);
        MinimizeBox = false;
        MinimumSize = new Size(425, 301);
        Name = "FirmaOdgovornaLicaDodaj";
        Text = "DODAVANJE ODGOVORNOG LICA";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Label lblIme;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtIme;
    private System.Windows.Forms.Label lblPrezime;
    private TextBox txtPrezime;
}
namespace Zatvor.Forme_za_OSTALO;

partial class FirmaDodaj
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
        lblPIB = new Label();
        lblImeFirme = new Label();
        gbxPodaci = new GroupBox();
        txtAdresaFirme = new TextBox();
        btnDodaj = new Button();
        txtImeFirme = new TextBox();
        txtPIB = new TextBox();
        lblAdresaFirme = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblPIB
        // 
        lblPIB.AutoSize = true;
        lblPIB.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPIB.Location = new Point(95, 63);
        lblPIB.Margin = new Padding(4, 0, 4, 0);
        lblPIB.Name = "lblPIB";
        lblPIB.Size = new Size(39, 23);
        lblPIB.TabIndex = 0;
        lblPIB.Text = "PIB:";
        // 
        // lblImeFirme
        // 
        lblImeFirme.AutoSize = true;
        lblImeFirme.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblImeFirme.Location = new Point(47, 114);
        lblImeFirme.Margin = new Padding(4, 0, 4, 0);
        lblImeFirme.Name = "lblImeFirme";
        lblImeFirme.Size = new Size(87, 23);
        lblImeFirme.TabIndex = 2;
        lblImeFirme.Text = "Ime firme:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(txtAdresaFirme);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtImeFirme);
        gbxPodaci.Controls.Add(txtPIB);
        gbxPodaci.Controls.Add(lblAdresaFirme);
        gbxPodaci.Controls.Add(lblPIB);
        gbxPodaci.Controls.Add(lblImeFirme);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(15, 21);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(378, 297);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o firmi";
        // 
        // txtAdresaFirme
        // 
        txtAdresaFirme.Location = new Point(154, 166);
        txtAdresaFirme.Margin = new Padding(4, 5, 4, 5);
        txtAdresaFirme.Name = "txtAdresaFirme";
        txtAdresaFirme.Size = new Size(201, 29);
        txtAdresaFirme.TabIndex = 5;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(210, 216);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 6;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtImeFirme
        // 
        txtImeFirme.Location = new Point(154, 112);
        txtImeFirme.Margin = new Padding(4, 5, 4, 5);
        txtImeFirme.Name = "txtImeFirme";
        txtImeFirme.Size = new Size(201, 29);
        txtImeFirme.TabIndex = 3;
        // 
        // txtPIB
        // 
        txtPIB.Location = new Point(154, 61);
        txtPIB.Margin = new Padding(4, 5, 4, 5);
        txtPIB.Name = "txtPIB";
        txtPIB.Size = new Size(201, 29);
        txtPIB.TabIndex = 1;
        // 
        // lblAdresaFirme
        // 
        lblAdresaFirme.AutoSize = true;
        lblAdresaFirme.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblAdresaFirme.Location = new Point(24, 168);
        lblAdresaFirme.Margin = new Padding(4, 0, 4, 0);
        lblAdresaFirme.Name = "lblAdresaFirme";
        lblAdresaFirme.Size = new Size(110, 23);
        lblAdresaFirme.TabIndex = 4;
        lblAdresaFirme.Text = "Adresa firme:";
        // 
        // FirmaDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(407, 328);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(425, 375);
        MinimizeBox = false;
        MinimumSize = new Size(425, 375);
        Name = "FirmaDodaj";
        Text = "DODAVANJE FIRME";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblPIB;
    private System.Windows.Forms.Label lblImeFirme;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtImeFirme;
    private System.Windows.Forms.TextBox txtPIB;
    private System.Windows.Forms.Label lblAdresaFirme;
    private TextBox txtAdresaFirme;
}
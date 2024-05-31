namespace Zatvor.Forme_za_Zaposlene;

partial class ObukeDodaj
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
        dtmIzdavanja = new DateTimePicker();
        lblDatumIzdavanja = new Label();
        btnDodaj = new Button();
        txtPolicijskaUprava = new TextBox();
        lblPolicijskaUprava = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(dtmIzdavanja);
        gbxPodaci.Controls.Add(lblDatumIzdavanja);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtPolicijskaUprava);
        gbxPodaci.Controls.Add(lblPolicijskaUprava);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(16, 19);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 233);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o obuci";
        // 
        // dtmIzdavanja
        // 
        dtmIzdavanja.CustomFormat = "dd.MM.yyyy.";
        dtmIzdavanja.Format = DateTimePickerFormat.Custom;
        dtmIzdavanja.Location = new Point(186, 61);
        dtmIzdavanja.Name = "dtmIzdavanja";
        dtmIzdavanja.Size = new Size(201, 29);
        dtmIzdavanja.TabIndex = 1;
        // 
        // lblDatumIzdavanja
        // 
        lblDatumIzdavanja.AutoSize = true;
        lblDatumIzdavanja.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatumIzdavanja.Location = new Point(24, 61);
        lblDatumIzdavanja.Margin = new Padding(4, 0, 4, 0);
        lblDatumIzdavanja.Name = "lblDatumIzdavanja";
        lblDatumIzdavanja.Size = new Size(142, 23);
        lblDatumIzdavanja.TabIndex = 0;
        lblDatumIzdavanja.Text = "Datum izdavanja:";
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(242, 163);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 4;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtPolicijskaUprava
        // 
        txtPolicijskaUprava.Location = new Point(186, 112);
        txtPolicijskaUprava.Margin = new Padding(4, 5, 4, 5);
        txtPolicijskaUprava.Name = "txtPolicijskaUprava";
        txtPolicijskaUprava.Size = new Size(201, 29);
        txtPolicijskaUprava.TabIndex = 3;
        // 
        // lblPolicijskaUprava
        // 
        lblPolicijskaUprava.AutoSize = true;
        lblPolicijskaUprava.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPolicijskaUprava.Location = new Point(26, 114);
        lblPolicijskaUprava.Margin = new Padding(4, 0, 4, 0);
        lblPolicijskaUprava.Name = "lblPolicijskaUprava";
        lblPolicijskaUprava.Size = new Size(138, 23);
        lblPolicijskaUprava.TabIndex = 2;
        lblPolicijskaUprava.Text = "Policijska uprava:";
        // 
        // ObukeDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 264);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 311);
        MinimizeBox = false;
        MinimumSize = new Size(461, 311);
        Name = "ObukeDodaj";
        Text = "DODAVANJE OBUKE";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtPolicijskaUprava;
    private Label lblDatumIzdavanja;
    private DateTimePicker dtmIzdavanja;
    private Label lblPolicijskaUprava;
}
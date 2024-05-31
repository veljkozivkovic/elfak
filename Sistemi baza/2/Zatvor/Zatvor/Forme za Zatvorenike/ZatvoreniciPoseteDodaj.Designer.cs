namespace Zatvor.Forme_za_Zatvorenike;

partial class ZatvoreniciPoseteDodaj
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
        lblDatum = new Label();
        lblVremeOd = new Label();
        gbxPodaci = new GroupBox();
        lblVremeDo = new Label();
        txtVremeDo = new TextBox();
        dtmDatum = new DateTimePicker();
        btnDodaj = new Button();
        txtVremeOd = new TextBox();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblDatum
        // 
        lblDatum.AutoSize = true;
        lblDatum.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatum.Location = new Point(74, 67);
        lblDatum.Margin = new Padding(4, 0, 4, 0);
        lblDatum.Name = "lblDatum";
        lblDatum.Size = new Size(66, 23);
        lblDatum.TabIndex = 0;
        lblDatum.Text = "Datum:";
        // 
        // lblVremeOd
        // 
        lblVremeOd.AutoSize = true;
        lblVremeOd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblVremeOd.Location = new Point(52, 114);
        lblVremeOd.Margin = new Padding(4, 0, 4, 0);
        lblVremeOd.Name = "lblVremeOd";
        lblVremeOd.Size = new Size(88, 23);
        lblVremeOd.TabIndex = 2;
        lblVremeOd.Text = "Vreme od:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(lblVremeDo);
        gbxPodaci.Controls.Add(txtVremeDo);
        gbxPodaci.Controls.Add(dtmDatum);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtVremeOd);
        gbxPodaci.Controls.Add(lblDatum);
        gbxPodaci.Controls.Add(lblVremeOd);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(16, 19);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(372, 298);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o poseti";
        // 
        // lblVremeDo
        // 
        lblVremeDo.AutoSize = true;
        lblVremeDo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblVremeDo.Location = new Point(52, 170);
        lblVremeDo.Margin = new Padding(4, 0, 4, 0);
        lblVremeDo.Name = "lblVremeDo";
        lblVremeDo.Size = new Size(88, 23);
        lblVremeDo.TabIndex = 4;
        lblVremeDo.Text = "Vreme do:";
        // 
        // txtVremeDo
        // 
        txtVremeDo.Location = new Point(150, 168);
        txtVremeDo.Margin = new Padding(4, 5, 4, 5);
        txtVremeDo.MaxLength = 5;
        txtVremeDo.Name = "txtVremeDo";
        txtVremeDo.Size = new Size(201, 29);
        txtVremeDo.TabIndex = 5;
        // 
        // dtmDatum
        // 
        dtmDatum.CustomFormat = "dd.MM.yyyy.";
        dtmDatum.Format = DateTimePickerFormat.Custom;
        dtmDatum.Location = new Point(150, 62);
        dtmDatum.Name = "dtmDatum";
        dtmDatum.Size = new Size(201, 29);
        dtmDatum.TabIndex = 1;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(206, 218);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 6;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtVremeOd
        // 
        txtVremeOd.Location = new Point(150, 112);
        txtVremeOd.Margin = new Padding(4, 5, 4, 5);
        txtVremeOd.MaxLength = 5;
        txtVremeOd.Name = "txtVremeOd";
        txtVremeOd.Size = new Size(201, 29);
        txtVremeOd.TabIndex = 3;
        // 
        // ZatvoreniciPoseteDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(401, 329);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(419, 376);
        MinimizeBox = false;
        MinimumSize = new Size(419, 376);
        Name = "ZatvoreniciPoseteDodaj";
        Text = "DODAVANJE POSETE";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblDatum;
    private System.Windows.Forms.Label lblVremeOd;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtVremeOd;
    private DateTimePicker dtmDatum;
    private Label lblVremeDo;
    private TextBox txtVremeDo;
}
namespace Zatvor.Forme_za_Zaposlene;

partial class LekarskiPregledDodaj
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
        lblNazivUstanove = new Label();
        lblAdresaUstanove = new Label();
        gbxPodaci = new GroupBox();
        dtmPregleda = new DateTimePicker();
        lblDatumPregleda = new Label();
        txtLekar = new TextBox();
        btnDodaj = new Button();
        txtAdresaUstanove = new TextBox();
        txtNazivUstanove = new TextBox();
        lblLekar = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblNazivUstanove
        // 
        lblNazivUstanove.AutoSize = true;
        lblNazivUstanove.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNazivUstanove.Location = new Point(36, 61);
        lblNazivUstanove.Margin = new Padding(4, 0, 4, 0);
        lblNazivUstanove.Name = "lblNazivUstanove";
        lblNazivUstanove.Size = new Size(130, 23);
        lblNazivUstanove.TabIndex = 0;
        lblNazivUstanove.Text = "Naziv ustanove:";
        // 
        // lblAdresaUstanove
        // 
        lblAdresaUstanove.AutoSize = true;
        lblAdresaUstanove.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblAdresaUstanove.Location = new Point(26, 114);
        lblAdresaUstanove.Margin = new Padding(4, 0, 4, 0);
        lblAdresaUstanove.Name = "lblAdresaUstanove";
        lblAdresaUstanove.Size = new Size(140, 23);
        lblAdresaUstanove.TabIndex = 2;
        lblAdresaUstanove.Text = "Adresa ustanove:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(dtmPregleda);
        gbxPodaci.Controls.Add(lblDatumPregleda);
        gbxPodaci.Controls.Add(txtLekar);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtAdresaUstanove);
        gbxPodaci.Controls.Add(txtNazivUstanove);
        gbxPodaci.Controls.Add(lblLekar);
        gbxPodaci.Controls.Add(lblNazivUstanove);
        gbxPodaci.Controls.Add(lblAdresaUstanove);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(16, 19);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 341);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o lekarskom pregledu";
        // 
        // dtmPregleda
        // 
        dtmPregleda.CustomFormat = "dd.MM.yyyy.";
        dtmPregleda.Format = DateTimePickerFormat.Custom;
        dtmPregleda.Location = new Point(186, 218);
        dtmPregleda.Name = "dtmPregleda";
        dtmPregleda.Size = new Size(201, 29);
        dtmPregleda.TabIndex = 7;
        // 
        // lblDatumPregleda
        // 
        lblDatumPregleda.AutoSize = true;
        lblDatumPregleda.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatumPregleda.Location = new Point(28, 223);
        lblDatumPregleda.Margin = new Padding(4, 0, 4, 0);
        lblDatumPregleda.Name = "lblDatumPregleda";
        lblDatumPregleda.Size = new Size(138, 23);
        lblDatumPregleda.TabIndex = 6;
        lblDatumPregleda.Text = "Datum pregleda:";
        // 
        // txtLekar
        // 
        txtLekar.Location = new Point(186, 164);
        txtLekar.Margin = new Padding(4, 5, 4, 5);
        txtLekar.Name = "txtLekar";
        txtLekar.Size = new Size(201, 29);
        txtLekar.TabIndex = 5;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(242, 269);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 8;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtAdresaUstanove
        // 
        txtAdresaUstanove.Location = new Point(186, 112);
        txtAdresaUstanove.Margin = new Padding(4, 5, 4, 5);
        txtAdresaUstanove.Name = "txtAdresaUstanove";
        txtAdresaUstanove.Size = new Size(201, 29);
        txtAdresaUstanove.TabIndex = 3;
        // 
        // txtNazivUstanove
        // 
        txtNazivUstanove.Location = new Point(186, 61);
        txtNazivUstanove.Margin = new Padding(4, 5, 4, 5);
        txtNazivUstanove.Name = "txtNazivUstanove";
        txtNazivUstanove.Size = new Size(201, 29);
        txtNazivUstanove.TabIndex = 1;
        // 
        // lblLekar
        // 
        lblLekar.AutoSize = true;
        lblLekar.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblLekar.Location = new Point(112, 166);
        lblLekar.Margin = new Padding(4, 0, 4, 0);
        lblLekar.Name = "lblLekar";
        lblLekar.Size = new Size(54, 23);
        lblLekar.TabIndex = 4;
        lblLekar.Text = "Lekar:";
        // 
        // LekarskiPregledDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 372);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 419);
        MinimizeBox = false;
        MinimumSize = new Size(461, 419);
        Name = "LekarskiPregledDodaj";
        Text = "DODAVANJE LEKARSKOG PREGLEDA";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblNazivUstanove;
    private System.Windows.Forms.Label lblAdresaUstanove;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtAdresaUstanove;
    private System.Windows.Forms.TextBox txtNazivUstanove;
    private System.Windows.Forms.Label lblLekar;
    private TextBox txtLekar;
    private Label lblDatumPregleda;
    private DateTimePicker dtmPregleda;
}
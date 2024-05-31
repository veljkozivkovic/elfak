namespace Zatvor.Forme_za_Zaposlene;

partial class ZaposleniZaposlenjaIzmeni
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
        btnIzmeni = new Button();
        txtRadnoMesto = new TextBox();
        lblRadnoMesto = new Label();
        dtmZaposlenja = new DateTimePicker();
        lblDatumPocetka = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(btnIzmeni);
        gbxPodaci.Controls.Add(txtRadnoMesto);
        gbxPodaci.Controls.Add(lblRadnoMesto);
        gbxPodaci.Controls.Add(dtmZaposlenja);
        gbxPodaci.Controls.Add(lblDatumPocetka);
        gbxPodaci.Location = new Point(12, 13);
        gbxPodaci.Margin = new Padding(3, 4, 3, 4);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(3, 4, 3, 4);
        gbxPodaci.Size = new Size(398, 223);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o zaposlenju";
        // 
        // btnIzmeni
        // 
        btnIzmeni.BackColor = Color.Transparent;
        btnIzmeni.Font = new Font("Segoe UI", 9F);
        btnIzmeni.Location = new Point(233, 147);
        btnIzmeni.Margin = new Padding(4, 5, 4, 5);
        btnIzmeni.Name = "btnIzmeni";
        btnIzmeni.Size = new Size(145, 56);
        btnIzmeni.TabIndex = 4;
        btnIzmeni.Text = "IZMENI";
        btnIzmeni.UseVisualStyleBackColor = false;
        btnIzmeni.Click += btnIzmeni_Click;
        // 
        // txtRadnoMesto
        // 
        txtRadnoMesto.Location = new Point(177, 54);
        txtRadnoMesto.Margin = new Padding(4, 5, 4, 5);
        txtRadnoMesto.Name = "txtRadnoMesto";
        txtRadnoMesto.Size = new Size(201, 27);
        txtRadnoMesto.TabIndex = 1;
        // 
        // lblRadnoMesto
        // 
        lblRadnoMesto.AutoSize = true;
        lblRadnoMesto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblRadnoMesto.Location = new Point(54, 59);
        lblRadnoMesto.Margin = new Padding(4, 0, 4, 0);
        lblRadnoMesto.Name = "lblRadnoMesto";
        lblRadnoMesto.Size = new Size(115, 23);
        lblRadnoMesto.TabIndex = 0;
        lblRadnoMesto.Text = "Radno mesto:";
        // 
        // dtmZaposlenja
        // 
        dtmZaposlenja.CustomFormat = "dd.MM.yyyy.";
        dtmZaposlenja.Format = DateTimePickerFormat.Custom;
        dtmZaposlenja.Location = new Point(177, 97);
        dtmZaposlenja.Name = "dtmZaposlenja";
        dtmZaposlenja.Size = new Size(201, 27);
        dtmZaposlenja.TabIndex = 3;
        // 
        // lblDatumPocetka
        // 
        lblDatumPocetka.AutoSize = true;
        lblDatumPocetka.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatumPocetka.Location = new Point(19, 101);
        lblDatumPocetka.Margin = new Padding(4, 0, 4, 0);
        lblDatumPocetka.Name = "lblDatumPocetka";
        lblDatumPocetka.Size = new Size(151, 23);
        lblDatumPocetka.TabIndex = 2;
        lblDatumPocetka.Text = "Datum zaposlenja:";
        // 
        // ZaposleniZaposlenjaIzmeni
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(422, 247);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(440, 294);
        MinimizeBox = false;
        MinimumSize = new Size(440, 294);
        Name = "ZaposleniZaposlenjaIzmeni";
        Text = "IZMENA RADNOG MESTA";
        Load += ZaposleniZaposlenjaIzmeni_Load;
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox gbxPodaci;
    private TextBox txtRadnoMesto;
    private Label lblRadnoMesto;
    private DateTimePicker dtmZaposlenja;
    private Label lblDatumPocetka;
    private Button btnIzmeni;
}
namespace Zatvor.Forme_za_Zaposlene;

partial class ZaposleniDodaj
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
        lblJMBG = new Label();
        lblIme = new Label();
        gbxPodaci = new GroupBox();
        txtRadnoMesto = new TextBox();
        lblRadnoMesto = new Label();
        dtmZaposlenja = new DateTimePicker();
        lblDatumPocetka = new Label();
        txtStrucnaSprema = new TextBox();
        lblStrucnaSprema = new Label();
        txtZanimanje = new TextBox();
        lblZanimanje = new Label();
        cbxPodtip = new ComboBox();
        lblPodtip = new Label();
        dtmObuke = new DateTimePicker();
        txtPrezime = new TextBox();
        cbxTip = new ComboBox();
        lblDatumObuke = new Label();
        lblTip = new Label();
        btnDodaj = new Button();
        txtIme = new TextBox();
        txtJMBG = new TextBox();
        lblPrezime = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblJMBG
        // 
        lblJMBG.AutoSize = true;
        lblJMBG.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblJMBG.Location = new Point(120, 63);
        lblJMBG.Margin = new Padding(4, 0, 4, 0);
        lblJMBG.Name = "lblJMBG";
        lblJMBG.Size = new Size(57, 23);
        lblJMBG.TabIndex = 0;
        lblJMBG.Text = "JMBG:";
        // 
        // lblIme
        // 
        lblIme.AutoSize = true;
        lblIme.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblIme.Location = new Point(134, 114);
        lblIme.Margin = new Padding(4, 0, 4, 0);
        lblIme.Name = "lblIme";
        lblIme.Size = new Size(43, 23);
        lblIme.TabIndex = 2;
        lblIme.Text = "Ime:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(txtRadnoMesto);
        gbxPodaci.Controls.Add(lblRadnoMesto);
        gbxPodaci.Controls.Add(dtmZaposlenja);
        gbxPodaci.Controls.Add(lblDatumPocetka);
        gbxPodaci.Controls.Add(txtStrucnaSprema);
        gbxPodaci.Controls.Add(lblStrucnaSprema);
        gbxPodaci.Controls.Add(txtZanimanje);
        gbxPodaci.Controls.Add(lblZanimanje);
        gbxPodaci.Controls.Add(cbxPodtip);
        gbxPodaci.Controls.Add(lblPodtip);
        gbxPodaci.Controls.Add(dtmObuke);
        gbxPodaci.Controls.Add(txtPrezime);
        gbxPodaci.Controls.Add(cbxTip);
        gbxPodaci.Controls.Add(lblDatumObuke);
        gbxPodaci.Controls.Add(lblTip);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtIme);
        gbxPodaci.Controls.Add(txtJMBG);
        gbxPodaci.Controls.Add(lblPrezime);
        gbxPodaci.Controls.Add(lblJMBG);
        gbxPodaci.Controls.Add(lblIme);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(15, 21);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 657);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o zaposlenom";
        // 
        // txtRadnoMesto
        // 
        txtRadnoMesto.Location = new Point(197, 478);
        txtRadnoMesto.Margin = new Padding(4, 5, 4, 5);
        txtRadnoMesto.Name = "txtRadnoMesto";
        txtRadnoMesto.Size = new Size(201, 29);
        txtRadnoMesto.TabIndex = 17;
        // 
        // lblRadnoMesto
        // 
        lblRadnoMesto.AutoSize = true;
        lblRadnoMesto.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblRadnoMesto.Location = new Point(62, 480);
        lblRadnoMesto.Margin = new Padding(4, 0, 4, 0);
        lblRadnoMesto.Name = "lblRadnoMesto";
        lblRadnoMesto.Size = new Size(115, 23);
        lblRadnoMesto.TabIndex = 16;
        lblRadnoMesto.Text = "Radno mesto:";
        // 
        // dtmZaposlenja
        // 
        dtmZaposlenja.CustomFormat = "dd.MM.yyyy.";
        dtmZaposlenja.Format = DateTimePickerFormat.Custom;
        dtmZaposlenja.Location = new Point(197, 533);
        dtmZaposlenja.Name = "dtmZaposlenja";
        dtmZaposlenja.Size = new Size(201, 29);
        dtmZaposlenja.TabIndex = 19;
        // 
        // lblDatumPocetka
        // 
        lblDatumPocetka.AutoSize = true;
        lblDatumPocetka.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatumPocetka.Location = new Point(26, 538);
        lblDatumPocetka.Margin = new Padding(4, 0, 4, 0);
        lblDatumPocetka.Name = "lblDatumPocetka";
        lblDatumPocetka.Size = new Size(151, 23);
        lblDatumPocetka.TabIndex = 18;
        lblDatumPocetka.Text = "Datum zaposlenja:";
        // 
        // txtStrucnaSprema
        // 
        txtStrucnaSprema.Location = new Point(197, 425);
        txtStrucnaSprema.Margin = new Padding(4, 5, 4, 5);
        txtStrucnaSprema.Name = "txtStrucnaSprema";
        txtStrucnaSprema.Size = new Size(201, 29);
        txtStrucnaSprema.TabIndex = 15;
        // 
        // lblStrucnaSprema
        // 
        lblStrucnaSprema.AutoSize = true;
        lblStrucnaSprema.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblStrucnaSprema.Location = new Point(45, 427);
        lblStrucnaSprema.Margin = new Padding(4, 0, 4, 0);
        lblStrucnaSprema.Name = "lblStrucnaSprema";
        lblStrucnaSprema.Size = new Size(132, 23);
        lblStrucnaSprema.TabIndex = 14;
        lblStrucnaSprema.Text = "Stručna sprema:";
        // 
        // txtZanimanje
        // 
        txtZanimanje.Location = new Point(197, 369);
        txtZanimanje.Margin = new Padding(4, 5, 4, 5);
        txtZanimanje.Name = "txtZanimanje";
        txtZanimanje.Size = new Size(201, 29);
        txtZanimanje.TabIndex = 13;
        // 
        // lblZanimanje
        // 
        lblZanimanje.AutoSize = true;
        lblZanimanje.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblZanimanje.Location = new Point(83, 371);
        lblZanimanje.Margin = new Padding(4, 0, 4, 0);
        lblZanimanje.Name = "lblZanimanje";
        lblZanimanje.Size = new Size(94, 23);
        lblZanimanje.TabIndex = 12;
        lblZanimanje.Text = "Zanimanje:";
        // 
        // cbxPodtip
        // 
        cbxPodtip.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxPodtip.FormattingEnabled = true;
        cbxPodtip.Items.AddRange(new object[] { "Psiholog", "Radnik obezbeđenja" });
        cbxPodtip.Location = new Point(197, 321);
        cbxPodtip.Name = "cbxPodtip";
        cbxPodtip.Size = new Size(201, 29);
        cbxPodtip.TabIndex = 11;
        // 
        // lblPodtip
        // 
        lblPodtip.AutoSize = true;
        lblPodtip.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPodtip.Location = new Point(22, 323);
        lblPodtip.Margin = new Padding(4, 0, 4, 0);
        lblPodtip.Name = "lblPodtip";
        lblPodtip.Size = new Size(155, 23);
        lblPodtip.TabIndex = 10;
        lblPodtip.Text = "Podtip zaposlenog:";
        // 
        // dtmObuke
        // 
        dtmObuke.CustomFormat = "dd.MM.yyyy.";
        dtmObuke.Format = DateTimePickerFormat.Custom;
        dtmObuke.Location = new Point(197, 218);
        dtmObuke.Name = "dtmObuke";
        dtmObuke.Size = new Size(201, 29);
        dtmObuke.TabIndex = 7;
        // 
        // txtPrezime
        // 
        txtPrezime.Location = new Point(197, 166);
        txtPrezime.Margin = new Padding(4, 5, 4, 5);
        txtPrezime.Name = "txtPrezime";
        txtPrezime.Size = new Size(201, 29);
        txtPrezime.TabIndex = 5;
        // 
        // cbxTip
        // 
        cbxTip.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxTip.FormattingEnabled = true;
        cbxTip.Items.AddRange(new object[] { "Administracija", "Sa direktnim kontaktom" });
        cbxTip.Location = new Point(197, 271);
        cbxTip.Name = "cbxTip";
        cbxTip.Size = new Size(201, 29);
        cbxTip.TabIndex = 9;
        cbxTip.SelectedValueChanged += cbxTip_SelectedValueChanged;
        // 
        // lblDatumObuke
        // 
        lblDatumObuke.AutoSize = true;
        lblDatumObuke.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatumObuke.Location = new Point(34, 223);
        lblDatumObuke.Margin = new Padding(4, 0, 4, 0);
        lblDatumObuke.Name = "lblDatumObuke";
        lblDatumObuke.Size = new Size(143, 23);
        lblDatumObuke.TabIndex = 6;
        lblDatumObuke.Text = "Datum PP obuke:";
        // 
        // lblTip
        // 
        lblTip.AutoSize = true;
        lblTip.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTip.Location = new Point(48, 273);
        lblTip.Margin = new Padding(4, 0, 4, 0);
        lblTip.Name = "lblTip";
        lblTip.Size = new Size(129, 23);
        lblTip.TabIndex = 8;
        lblTip.Text = "Tip zaposlenog:";
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(253, 582);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 20;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtIme
        // 
        txtIme.Location = new Point(197, 112);
        txtIme.Margin = new Padding(4, 5, 4, 5);
        txtIme.Name = "txtIme";
        txtIme.Size = new Size(201, 29);
        txtIme.TabIndex = 3;
        // 
        // txtJMBG
        // 
        txtJMBG.Location = new Point(197, 61);
        txtJMBG.Margin = new Padding(4, 5, 4, 5);
        txtJMBG.Name = "txtJMBG";
        txtJMBG.Size = new Size(201, 29);
        txtJMBG.TabIndex = 1;
        // 
        // lblPrezime
        // 
        lblPrezime.AutoSize = true;
        lblPrezime.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPrezime.Location = new Point(102, 168);
        lblPrezime.Margin = new Padding(4, 0, 4, 0);
        lblPrezime.Name = "lblPrezime";
        lblPrezime.Size = new Size(75, 23);
        lblPrezime.TabIndex = 4;
        lblPrezime.Text = "Prezime:";
        // 
        // ZaposleniDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 692);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 739);
        MinimizeBox = false;
        MinimumSize = new Size(461, 739);
        Name = "ZaposleniDodaj";
        Text = "DODAVANJE ZAPOSLENOG";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblJMBG;
    private System.Windows.Forms.Label lblIme;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtIme;
    private System.Windows.Forms.TextBox txtJMBG;
    private System.Windows.Forms.Label lblPrezime;
    private System.Windows.Forms.Label lblTip;
    private Label lblDatumObuke;
    private ComboBox cbxTip;
    private TextBox txtPrezime;
    private DateTimePicker dtmObuke;
    private ComboBox cbxPodtip;
    private Label lblPodtip;
    private Label lblZanimanje;
    private TextBox txtZanimanje;
    private TextBox txtStrucnaSprema;
    private Label lblStrucnaSprema;
    private DateTimePicker dtmZaposlenja;
    private Label lblDatumPocetka;
    private TextBox txtRadnoMesto;
    private Label lblRadnoMesto;
}
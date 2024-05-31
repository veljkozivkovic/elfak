namespace Zatvor.Forme_za_OSTALO;

partial class AdvokatPoseteDodaj
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
        listaZatvorenika = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        columnHeader14 = new ColumnHeader();
        columnHeader4 = new ColumnHeader();
        columnHeader5 = new ColumnHeader();
        columnHeader6 = new ColumnHeader();
        columnHeader7 = new ColumnHeader();
        columnHeader11 = new ColumnHeader();
        columnHeader12 = new ColumnHeader();
        columnHeader13 = new ColumnHeader();
        gbxPodaci = new GroupBox();
        lblVremeDo = new Label();
        txtVremeDo = new TextBox();
        dtmDatum = new DateTimePicker();
        txtVremeOd = new TextBox();
        lblDatum = new Label();
        lblVremeOd = new Label();
        btnDodaj = new Button();
        gbxLista.SuspendLayout();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // gbxLista
        // 
        gbxLista.Controls.Add(listaZatvorenika);
        gbxLista.Location = new Point(12, 25);
        gbxLista.Margin = new Padding(3, 4, 3, 4);
        gbxLista.Name = "gbxLista";
        gbxLista.Padding = new Padding(3, 4, 3, 4);
        gbxLista.Size = new Size(659, 328);
        gbxLista.TabIndex = 0;
        gbxLista.TabStop = false;
        gbxLista.Text = "Lista zatvorenika";
        // 
        // listaZatvorenika
        // 
        listaZatvorenika.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader14, columnHeader4, columnHeader5, columnHeader6, columnHeader7, columnHeader11, columnHeader12, columnHeader13 });
        listaZatvorenika.Dock = DockStyle.Fill;
        listaZatvorenika.FullRowSelect = true;
        listaZatvorenika.GridLines = true;
        listaZatvorenika.Location = new Point(3, 24);
        listaZatvorenika.Margin = new Padding(4);
        listaZatvorenika.Name = "listaZatvorenika";
        listaZatvorenika.Size = new Size(653, 300);
        listaZatvorenika.TabIndex = 0;
        listaZatvorenika.UseCompatibleStateImageBehavior = false;
        listaZatvorenika.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Tag = "sa";
        columnHeader1.Text = "Sifra";
        columnHeader1.Width = 80;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Ime";
        columnHeader2.Width = 100;
        // 
        // columnHeader3
        // 
        columnHeader3.Text = "Prezime";
        columnHeader3.Width = 120;
        // 
        // columnHeader14
        // 
        columnHeader14.Text = "Zatvorska jedinica";
        columnHeader14.Width = 180;
        // 
        // columnHeader4
        // 
        columnHeader4.Text = "Adresa";
        columnHeader4.Width = 240;
        // 
        // columnHeader5
        // 
        columnHeader5.Text = "Pol";
        columnHeader5.Width = 40;
        // 
        // columnHeader6
        // 
        columnHeader6.Text = "Status uslovnog otpusta";
        columnHeader6.Width = 200;
        // 
        // columnHeader7
        // 
        columnHeader7.Text = "Datum sledećeg saslušanja";
        columnHeader7.Width = 200;
        // 
        // columnHeader11
        // 
        columnHeader11.Text = "Advokat";
        columnHeader11.Width = 220;
        // 
        // columnHeader12
        // 
        columnHeader12.Text = "Datum dodele advokata";
        columnHeader12.Width = 240;
        // 
        // columnHeader13
        // 
        columnHeader13.Text = "Poslednji kontakt sa advokatom";
        columnHeader13.Width = 240;
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(lblVremeDo);
        gbxPodaci.Controls.Add(txtVremeDo);
        gbxPodaci.Controls.Add(dtmDatum);
        gbxPodaci.Controls.Add(txtVremeOd);
        gbxPodaci.Controls.Add(lblDatum);
        gbxPodaci.Controls.Add(lblVremeOd);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(690, 25);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(372, 220);
        gbxPodaci.TabIndex = 1;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o poseti";
        // 
        // lblVremeDo
        // 
        lblVremeDo.AutoSize = true;
        lblVremeDo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblVremeDo.Location = new Point(53, 172);
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
        // txtVremeOd
        // 
        txtVremeOd.Location = new Point(150, 112);
        txtVremeOd.Margin = new Padding(4, 5, 4, 5);
        txtVremeOd.MaxLength = 5;
        txtVremeOd.Name = "txtVremeOd";
        txtVremeOd.Size = new Size(201, 29);
        txtVremeOd.TabIndex = 3;
        // 
        // lblDatum
        // 
        lblDatum.AutoSize = true;
        lblDatum.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatum.Location = new Point(75, 69);
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
        lblVremeOd.Location = new Point(53, 116);
        lblVremeOd.Margin = new Padding(4, 0, 4, 0);
        lblVremeOd.Name = "lblVremeOd";
        lblVremeOd.Size = new Size(88, 23);
        lblVremeOd.TabIndex = 2;
        lblVremeOd.Text = "Vreme od:";
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(827, 275);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 2;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // AdvokatPoseteDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1078, 362);
        Controls.Add(gbxPodaci);
        Controls.Add(gbxLista);
        Controls.Add(btnDodaj);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(1096, 409);
        MinimizeBox = false;
        MinimumSize = new Size(1096, 409);
        Name = "AdvokatPoseteDodaj";
        Text = "DODAJ POSETU";
        Load += AdvokatPoseteDodaj_Load;
        gbxLista.ResumeLayout(false);
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private GroupBox gbxLista;
    private ListView listaZatvorenika;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader14;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader11;
    private ColumnHeader columnHeader12;
    private ColumnHeader columnHeader13;
    private GroupBox gbxPodaci;
    private Label lblVremeDo;
    private TextBox txtVremeDo;
    private DateTimePicker dtmDatum;
    private TextBox txtVremeOd;
    private Label lblDatum;
    private Label lblVremeOd;
    private Button btnDodaj;
}
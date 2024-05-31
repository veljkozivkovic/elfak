namespace Zatvor.Forme_za_Zatvorenike;

partial class ZatvoreniciDodaj
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
        lblPrezime = new Label();
        gbxPodaci = new GroupBox();
        btnAdvokat = new Button();
        lblAdvokat = new Label();
        dtmSledecegSaslusanja = new DateTimePicker();
        txtAdresa = new TextBox();
        cbxPol = new ComboBox();
        lblDatumSledecegSaslusanja = new Label();
        txtStatusUslovnogOtpusta = new TextBox();
        lblStatusUslovnogOtpusta = new Label();
        lblPol = new Label();
        txtPrezime = new TextBox();
        txtIme = new TextBox();
        lblAdresa = new Label();
        btnDodaj = new Button();
        gbxLista = new GroupBox();
        listaZatvora = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        columnHeader4 = new ColumnHeader();
        columnHeader5 = new ColumnHeader();
        columnHeader6 = new ColumnHeader();
        gbxPodaci.SuspendLayout();
        gbxLista.SuspendLayout();
        SuspendLayout();
        // 
        // lblIme
        // 
        lblIme.AutoSize = true;
        lblIme.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblIme.Location = new Point(203, 63);
        lblIme.Margin = new Padding(4, 0, 4, 0);
        lblIme.Name = "lblIme";
        lblIme.Size = new Size(43, 23);
        lblIme.TabIndex = 0;
        lblIme.Text = "Ime:";
        // 
        // lblPrezime
        // 
        lblPrezime.AutoSize = true;
        lblPrezime.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPrezime.Location = new Point(171, 114);
        lblPrezime.Margin = new Padding(4, 0, 4, 0);
        lblPrezime.Name = "lblPrezime";
        lblPrezime.Size = new Size(75, 23);
        lblPrezime.TabIndex = 2;
        lblPrezime.Text = "Prezime:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(btnAdvokat);
        gbxPodaci.Controls.Add(lblAdvokat);
        gbxPodaci.Controls.Add(dtmSledecegSaslusanja);
        gbxPodaci.Controls.Add(txtAdresa);
        gbxPodaci.Controls.Add(cbxPol);
        gbxPodaci.Controls.Add(lblDatumSledecegSaslusanja);
        gbxPodaci.Controls.Add(txtStatusUslovnogOtpusta);
        gbxPodaci.Controls.Add(lblStatusUslovnogOtpusta);
        gbxPodaci.Controls.Add(lblPol);
        gbxPodaci.Controls.Add(txtPrezime);
        gbxPodaci.Controls.Add(txtIme);
        gbxPodaci.Controls.Add(lblAdresa);
        gbxPodaci.Controls.Add(lblIme);
        gbxPodaci.Controls.Add(lblPrezime);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(16, 19);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(493, 431);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o zatvoreniku";
        // 
        // btnAdvokat
        // 
        btnAdvokat.Location = new Point(256, 381);
        btnAdvokat.Name = "btnAdvokat";
        btnAdvokat.Size = new Size(201, 36);
        btnAdvokat.TabIndex = 13;
        btnAdvokat.Text = "Dodeli advokata";
        btnAdvokat.UseVisualStyleBackColor = true;
        btnAdvokat.Click += btnAdvokat_Click;
        // 
        // lblAdvokat
        // 
        lblAdvokat.AutoSize = true;
        lblAdvokat.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblAdvokat.Location = new Point(170, 388);
        lblAdvokat.Margin = new Padding(4, 0, 4, 0);
        lblAdvokat.Name = "lblAdvokat";
        lblAdvokat.Size = new Size(76, 23);
        lblAdvokat.TabIndex = 12;
        lblAdvokat.Text = "Advokat:";
        // 
        // dtmSledecegSaslusanja
        // 
        dtmSledecegSaslusanja.CustomFormat = "dd.MM.yyyy.";
        dtmSledecegSaslusanja.Format = DateTimePickerFormat.Custom;
        dtmSledecegSaslusanja.Location = new Point(256, 324);
        dtmSledecegSaslusanja.Name = "dtmSledecegSaslusanja";
        dtmSledecegSaslusanja.Size = new Size(201, 29);
        dtmSledecegSaslusanja.TabIndex = 11;
        // 
        // txtAdresa
        // 
        txtAdresa.Location = new Point(256, 164);
        txtAdresa.Margin = new Padding(4, 5, 4, 5);
        txtAdresa.Name = "txtAdresa";
        txtAdresa.Size = new Size(201, 29);
        txtAdresa.TabIndex = 5;
        // 
        // cbxPol
        // 
        cbxPol.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxPol.FormattingEnabled = true;
        cbxPol.Items.AddRange(new object[] { "M", "Z" });
        cbxPol.Location = new Point(256, 215);
        cbxPol.Name = "cbxPol";
        cbxPol.Size = new Size(201, 29);
        cbxPol.TabIndex = 7;
        // 
        // lblDatumSledecegSaslusanja
        // 
        lblDatumSledecegSaslusanja.AutoSize = true;
        lblDatumSledecegSaslusanja.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDatumSledecegSaslusanja.Location = new Point(28, 329);
        lblDatumSledecegSaslusanja.Margin = new Padding(4, 0, 4, 0);
        lblDatumSledecegSaslusanja.Name = "lblDatumSledecegSaslusanja";
        lblDatumSledecegSaslusanja.Size = new Size(218, 23);
        lblDatumSledecegSaslusanja.TabIndex = 10;
        lblDatumSledecegSaslusanja.Text = "Datum sledećeg saslušanja:";
        // 
        // txtStatusUslovnogOtpusta
        // 
        txtStatusUslovnogOtpusta.Location = new Point(256, 272);
        txtStatusUslovnogOtpusta.Margin = new Padding(4, 5, 4, 5);
        txtStatusUslovnogOtpusta.Name = "txtStatusUslovnogOtpusta";
        txtStatusUslovnogOtpusta.Size = new Size(201, 29);
        txtStatusUslovnogOtpusta.TabIndex = 9;
        // 
        // lblStatusUslovnogOtpusta
        // 
        lblStatusUslovnogOtpusta.AutoSize = true;
        lblStatusUslovnogOtpusta.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblStatusUslovnogOtpusta.Location = new Point(51, 274);
        lblStatusUslovnogOtpusta.Margin = new Padding(4, 0, 4, 0);
        lblStatusUslovnogOtpusta.Name = "lblStatusUslovnogOtpusta";
        lblStatusUslovnogOtpusta.Size = new Size(197, 23);
        lblStatusUslovnogOtpusta.TabIndex = 8;
        lblStatusUslovnogOtpusta.Text = "Status uslovnog otpusta:";
        // 
        // lblPol
        // 
        lblPol.AutoSize = true;
        lblPol.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPol.Location = new Point(209, 217);
        lblPol.Margin = new Padding(4, 0, 4, 0);
        lblPol.Name = "lblPol";
        lblPol.Size = new Size(37, 23);
        lblPol.TabIndex = 6;
        lblPol.Text = "Pol:";
        // 
        // txtPrezime
        // 
        txtPrezime.Location = new Point(256, 112);
        txtPrezime.Margin = new Padding(4, 5, 4, 5);
        txtPrezime.Name = "txtPrezime";
        txtPrezime.Size = new Size(201, 29);
        txtPrezime.TabIndex = 3;
        // 
        // txtIme
        // 
        txtIme.Location = new Point(256, 61);
        txtIme.Margin = new Padding(4, 5, 4, 5);
        txtIme.Name = "txtIme";
        txtIme.Size = new Size(201, 29);
        txtIme.TabIndex = 1;
        // 
        // lblAdresa
        // 
        lblAdresa.AutoSize = true;
        lblAdresa.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblAdresa.Location = new Point(180, 166);
        lblAdresa.Margin = new Padding(4, 0, 4, 0);
        lblAdresa.Name = "lblAdresa";
        lblAdresa.Size = new Size(66, 23);
        lblAdresa.TabIndex = 4;
        lblAdresa.Text = "Adresa:";
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(826, 343);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 2;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // gbxLista
        // 
        gbxLista.Controls.Add(listaZatvora);
        gbxLista.Location = new Point(531, 19);
        gbxLista.Margin = new Padding(3, 4, 3, 4);
        gbxLista.Name = "gbxLista";
        gbxLista.Padding = new Padding(3, 4, 3, 4);
        gbxLista.Size = new Size(700, 300);
        gbxLista.TabIndex = 1;
        gbxLista.TabStop = false;
        gbxLista.Text = "Lista zatvora";
        // 
        // listaZatvora
        // 
        listaZatvora.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
        listaZatvora.Dock = DockStyle.Fill;
        listaZatvora.FullRowSelect = true;
        listaZatvora.GridLines = true;
        listaZatvora.Location = new Point(3, 24);
        listaZatvora.Margin = new Padding(4);
        listaZatvora.Name = "listaZatvora";
        listaZatvora.Size = new Size(694, 272);
        listaZatvora.TabIndex = 0;
        listaZatvora.UseCompatibleStateImageBehavior = false;
        listaZatvora.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Tag = "sa";
        columnHeader1.Text = "Sifra";
        columnHeader1.Width = 80;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Naziv";
        columnHeader2.Width = 180;
        // 
        // columnHeader3
        // 
        columnHeader3.Text = "Adresa";
        columnHeader3.Width = 180;
        // 
        // columnHeader4
        // 
        columnHeader4.Text = "Kapacitet";
        columnHeader4.Width = 100;
        // 
        // columnHeader5
        // 
        columnHeader5.Text = "Tip";
        columnHeader5.Width = 180;
        // 
        // columnHeader6
        // 
        columnHeader6.Text = "Period zabrane";
        columnHeader6.Width = 180;
        // 
        // ZatvoreniciDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(1244, 462);
        Controls.Add(gbxLista);
        Controls.Add(gbxPodaci);
        Controls.Add(btnDodaj);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(1262, 509);
        MinimizeBox = false;
        MinimumSize = new Size(1262, 509);
        Name = "ZatvoreniciDodaj";
        Text = "DODAJ ZATVORENIKA";
        Load += ZatvoreniciDodaj_Load;
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        gbxLista.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblIme;
    private System.Windows.Forms.Label lblPrezime;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtPrezime;
    private System.Windows.Forms.TextBox txtIme;
    private System.Windows.Forms.Label lblAdresa;
    private System.Windows.Forms.Label lblPol;
    private Label lblDatumSledecegSaslusanja;
    private Label lblStatusUslovnogOtpusta;
    private ComboBox cbxPol;
    private TextBox txtAdresa;
    private TextBox txtStatusUslovnogOtpusta;
    private DateTimePicker dtmSledecegSaslusanja;
    private Button btnAdvokat;
    private Label lblAdvokat;
    private GroupBox gbxLista;
    private ListView listaZatvora;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
}
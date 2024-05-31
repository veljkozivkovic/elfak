namespace Zatvor.Forme_za_Zatvorenike;

partial class ZatvoreniciDodajIzaberiAdvokata
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
        listaAdvokata = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        gbxAdvokati = new GroupBox();
        btnDodeli = new Button();
        gbxDodatneInfo = new GroupBox();
        dtmPoslednjiKontakt = new DateTimePicker();
        lblPoslednjiKontakt = new Label();
        dtmDodele = new DateTimePicker();
        lblDatumDodele = new Label();
        gbxAdvokati.SuspendLayout();
        gbxDodatneInfo.SuspendLayout();
        SuspendLayout();
        // 
        // listaAdvokata
        // 
        listaAdvokata.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
        listaAdvokata.Dock = DockStyle.Fill;
        listaAdvokata.FullRowSelect = true;
        listaAdvokata.Location = new Point(3, 24);
        listaAdvokata.Margin = new Padding(3, 4, 3, 4);
        listaAdvokata.Name = "listaAdvokata";
        listaAdvokata.Size = new Size(342, 537);
        listaAdvokata.TabIndex = 0;
        listaAdvokata.UseCompatibleStateImageBehavior = false;
        listaAdvokata.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Text = "JMBG";
        columnHeader1.Width = 120;
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
        // gbxAdvokati
        // 
        gbxAdvokati.Controls.Add(listaAdvokata);
        gbxAdvokati.Location = new Point(12, 22);
        gbxAdvokati.Margin = new Padding(3, 4, 3, 4);
        gbxAdvokati.Name = "gbxAdvokati";
        gbxAdvokati.Padding = new Padding(3, 4, 3, 4);
        gbxAdvokati.Size = new Size(348, 565);
        gbxAdvokati.TabIndex = 0;
        gbxAdvokati.TabStop = false;
        gbxAdvokati.Text = "Advokati";
        // 
        // btnDodeli
        // 
        btnDodeli.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnDodeli.Location = new Point(399, 363);
        btnDodeli.Margin = new Padding(3, 4, 3, 4);
        btnDodeli.Name = "btnDodeli";
        btnDodeli.Size = new Size(387, 78);
        btnDodeli.TabIndex = 2;
        btnDodeli.Text = "Dodeli advokata zatvoreniku";
        btnDodeli.UseVisualStyleBackColor = true;
        btnDodeli.Click += btnDodeli_Click;
        // 
        // gbxDodatneInfo
        // 
        gbxDodatneInfo.Controls.Add(dtmPoslednjiKontakt);
        gbxDodatneInfo.Controls.Add(lblPoslednjiKontakt);
        gbxDodatneInfo.Controls.Add(dtmDodele);
        gbxDodatneInfo.Controls.Add(lblDatumDodele);
        gbxDodatneInfo.Location = new Point(399, 192);
        gbxDodatneInfo.Name = "gbxDodatneInfo";
        gbxDodatneInfo.Size = new Size(387, 120);
        gbxDodatneInfo.TabIndex = 1;
        gbxDodatneInfo.TabStop = false;
        gbxDodatneInfo.Text = "Dodatne informacije";
        // 
        // dtmPoslednjiKontakt
        // 
        dtmPoslednjiKontakt.CustomFormat = "dd.MM.yyyy.";
        dtmPoslednjiKontakt.Format = DateTimePickerFormat.Custom;
        dtmPoslednjiKontakt.Location = new Point(274, 81);
        dtmPoslednjiKontakt.Name = "dtmPoslednjiKontakt";
        dtmPoslednjiKontakt.Size = new Size(100, 27);
        dtmPoslednjiKontakt.TabIndex = 3;
        // 
        // lblPoslednjiKontakt
        // 
        lblPoslednjiKontakt.AutoSize = true;
        lblPoslednjiKontakt.Location = new Point(47, 86);
        lblPoslednjiKontakt.Name = "lblPoslednjiKontakt";
        lblPoslednjiKontakt.Size = new Size(221, 20);
        lblPoslednjiKontakt.TabIndex = 2;
        lblPoslednjiKontakt.Text = "Poslednji kontakt sa advokatom:";
        // 
        // dtmDodele
        // 
        dtmDodele.CustomFormat = "dd.MM.yyyy.";
        dtmDodele.Format = DateTimePickerFormat.Custom;
        dtmDodele.Location = new Point(274, 36);
        dtmDodele.Name = "dtmDodele";
        dtmDodele.Size = new Size(100, 27);
        dtmDodele.TabIndex = 1;
        // 
        // lblDatumDodele
        // 
        lblDatumDodele.AutoSize = true;
        lblDatumDodele.Location = new Point(15, 41);
        lblDatumDodele.Name = "lblDatumDodele";
        lblDatumDodele.Size = new Size(253, 20);
        lblDatumDodele.TabIndex = 0;
        lblDatumDodele.Text = "Datum dodele advokata zatvoreniku:";
        // 
        // ZatvoreniciDodajIzaberiAdvokata
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(825, 600);
        Controls.Add(gbxDodatneInfo);
        Controls.Add(btnDodeli);
        Controls.Add(gbxAdvokati);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(843, 647);
        MinimizeBox = false;
        MinimumSize = new Size(843, 647);
        Name = "ZatvoreniciDodajIzaberiAdvokata";
        Text = "DODELA ADVOKATA";
        Load += FZatvoreniciDodajIzaberiAdvokata_Load;
        gbxAdvokati.ResumeLayout(false);
        gbxDodatneInfo.ResumeLayout(false);
        gbxDodatneInfo.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ListView listaAdvokata;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private GroupBox gbxAdvokati;
    private Button btnDodeli;
    private GroupBox gbxDodatneInfo;
    private DateTimePicker dtmDodele;
    private Label lblDatumDodele;
    private DateTimePicker dtmPoslednjiKontakt;
    private Label lblPoslednjiKontakt;
}
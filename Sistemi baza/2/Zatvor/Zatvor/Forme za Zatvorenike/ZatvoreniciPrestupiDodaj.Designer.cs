namespace Zatvor.Forme_za_Zatvorenike;

partial class ZatvoreniciPrestupiDodaj
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
        gbxDodatneInfo = new GroupBox();
        txtMesto = new TextBox();
        dtmDatum = new DateTimePicker();
        lblDatum = new Label();
        lblMesto = new Label();
        gbxLista = new GroupBox();
        listaPrestupa = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        columnHeader4 = new ColumnHeader();
        columnHeader5 = new ColumnHeader();
        columnHeader6 = new ColumnHeader();
        columnHeader7 = new ColumnHeader();
        btnDodaj = new Button();
        gbxDodatneInfo.SuspendLayout();
        gbxLista.SuspendLayout();
        SuspendLayout();
        // 
        // gbxDodatneInfo
        // 
        gbxDodatneInfo.Controls.Add(txtMesto);
        gbxDodatneInfo.Controls.Add(dtmDatum);
        gbxDodatneInfo.Controls.Add(lblDatum);
        gbxDodatneInfo.Controls.Add(lblMesto);
        gbxDodatneInfo.Location = new Point(733, 158);
        gbxDodatneInfo.Name = "gbxDodatneInfo";
        gbxDodatneInfo.Size = new Size(339, 120);
        gbxDodatneInfo.TabIndex = 1;
        gbxDodatneInfo.TabStop = false;
        gbxDodatneInfo.Text = "Informacije o prestupu";
        // 
        // txtMesto
        // 
        txtMesto.Location = new Point(118, 43);
        txtMesto.Margin = new Padding(4, 5, 4, 5);
        txtMesto.Name = "txtMesto";
        txtMesto.Size = new Size(201, 27);
        txtMesto.TabIndex = 1;
        // 
        // dtmDatum
        // 
        dtmDatum.CustomFormat = "dd.MM.yyyy.";
        dtmDatum.Format = DateTimePickerFormat.Custom;
        dtmDatum.Location = new Point(118, 81);
        dtmDatum.Name = "dtmDatum";
        dtmDatum.Size = new Size(201, 27);
        dtmDatum.TabIndex = 3;
        // 
        // lblDatum
        // 
        lblDatum.AutoSize = true;
        lblDatum.Location = new Point(47, 86);
        lblDatum.Name = "lblDatum";
        lblDatum.Size = new Size(57, 20);
        lblDatum.TabIndex = 2;
        lblDatum.Text = "Datum:";
        // 
        // lblMesto
        // 
        lblMesto.AutoSize = true;
        lblMesto.Location = new Point(51, 46);
        lblMesto.Name = "lblMesto";
        lblMesto.Size = new Size(53, 20);
        lblMesto.TabIndex = 0;
        lblMesto.Text = "Mesto:";
        // 
        // gbxLista
        // 
        gbxLista.Controls.Add(listaPrestupa);
        gbxLista.Location = new Point(12, 25);
        gbxLista.Margin = new Padding(3, 4, 3, 4);
        gbxLista.Name = "gbxLista";
        gbxLista.Padding = new Padding(3, 4, 3, 4);
        gbxLista.Size = new Size(700, 410);
        gbxLista.TabIndex = 0;
        gbxLista.TabStop = false;
        gbxLista.Text = "Lista prestupa";
        // 
        // listaPrestupa
        // 
        listaPrestupa.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
        listaPrestupa.Dock = DockStyle.Fill;
        listaPrestupa.FullRowSelect = true;
        listaPrestupa.GridLines = true;
        listaPrestupa.Location = new Point(3, 24);
        listaPrestupa.Margin = new Padding(4);
        listaPrestupa.Name = "listaPrestupa";
        listaPrestupa.Size = new Size(694, 382);
        listaPrestupa.TabIndex = 0;
        listaPrestupa.UseCompatibleStateImageBehavior = false;
        listaPrestupa.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Tag = "sa";
        columnHeader1.Text = "ID";
        columnHeader1.Width = 80;
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Naziv prestupa";
        columnHeader2.Width = 220;
        // 
        // columnHeader4
        // 
        columnHeader4.Text = "Kategorija";
        columnHeader4.Width = 260;
        // 
        // columnHeader5
        // 
        columnHeader5.Text = "Opis";
        columnHeader5.Width = 560;
        // 
        // columnHeader6
        // 
        columnHeader6.Text = "Minimalna kazna";
        columnHeader6.Width = 140;
        // 
        // columnHeader7
        // 
        columnHeader7.Text = "Maksimalna kazna";
        columnHeader7.Width = 140;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9.75F);
        btnDodaj.Location = new Point(851, 317);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 2;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // ZatvoreniciPrestupiDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1087, 443);
        Controls.Add(btnDodaj);
        Controls.Add(gbxLista);
        Controls.Add(gbxDodatneInfo);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(1105, 490);
        MinimizeBox = false;
        MinimumSize = new Size(1105, 490);
        Name = "ZatvoreniciPrestupiDodaj";
        Text = "DODAJ PRESTUP";
        Load += ZatvoreniciPrestupiDodaj_Load;
        gbxDodatneInfo.ResumeLayout(false);
        gbxDodatneInfo.PerformLayout();
        gbxLista.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private GroupBox gbxDodatneInfo;
    private Label lblMesto;
    private DateTimePicker dtmDatum;
    private Label lblDatum;
    private GroupBox gbxLista;
    private ListView listaPrestupa;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private TextBox txtMesto;
    private Button btnDodaj;
}
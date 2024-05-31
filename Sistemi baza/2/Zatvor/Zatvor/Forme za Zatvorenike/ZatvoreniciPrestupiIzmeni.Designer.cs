namespace Zatvor.Forme_za_Zatvorenike;

partial class ZatvoreniciPrestupiIzmeni
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
        btnIzmeni = new Button();
        txtMesto = new TextBox();
        dtmDatum = new DateTimePicker();
        lblDatum = new Label();
        lblMesto = new Label();
        gbxDodatneInfo.SuspendLayout();
        SuspendLayout();
        // 
        // gbxDodatneInfo
        // 
        gbxDodatneInfo.Controls.Add(btnIzmeni);
        gbxDodatneInfo.Controls.Add(txtMesto);
        gbxDodatneInfo.Controls.Add(dtmDatum);
        gbxDodatneInfo.Controls.Add(lblDatum);
        gbxDodatneInfo.Controls.Add(lblMesto);
        gbxDodatneInfo.Location = new Point(12, 25);
        gbxDodatneInfo.Name = "gbxDodatneInfo";
        gbxDodatneInfo.Size = new Size(339, 198);
        gbxDodatneInfo.TabIndex = 0;
        gbxDodatneInfo.TabStop = false;
        gbxDodatneInfo.Text = "Informacije o prestupu";
        // 
        // btnIzmeni
        // 
        btnIzmeni.BackColor = Color.Transparent;
        btnIzmeni.Font = new Font("Segoe UI", 9F);
        btnIzmeni.Location = new Point(174, 125);
        btnIzmeni.Margin = new Padding(4, 5, 4, 5);
        btnIzmeni.Name = "btnIzmeni";
        btnIzmeni.Size = new Size(145, 56);
        btnIzmeni.TabIndex = 4;
        btnIzmeni.Text = "IZMENI";
        btnIzmeni.UseVisualStyleBackColor = false;
        btnIzmeni.Click += btnIzmeni_Click;
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
        // ZatvoreniciPrestupiIzmeni
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(361, 232);
        Controls.Add(gbxDodatneInfo);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(379, 279);
        MinimizeBox = false;
        MinimumSize = new Size(379, 279);
        Name = "ZatvoreniciPrestupiIzmeni";
        Text = "IZMENI PRESTUP";
        Load += ZatvoreniciPrestupiIzmeni_Load;
        gbxDodatneInfo.ResumeLayout(false);
        gbxDodatneInfo.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private GroupBox gbxDodatneInfo;
    private Label lblMesto;
    private DateTimePicker dtmDatum;
    private Label lblDatum;
    private TextBox txtMesto;
    private Button btnIzmeni;
}
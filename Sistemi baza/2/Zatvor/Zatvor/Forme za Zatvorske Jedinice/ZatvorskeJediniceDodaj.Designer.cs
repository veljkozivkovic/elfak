namespace Zatvor.Forme_za_Zatvorske_Jedinice;

partial class ZatvorskeJediniceDodaj
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
        lblNaziv = new Label();
        lblAdresa = new Label();
        gbxPodaci = new GroupBox();
        cbxTip = new ComboBox();
        numKapacitet = new NumericUpDown();
        txtPeriodZabraneDo = new TextBox();
        lblPeriodZabraneDo = new Label();
        txtPeriodZabraneOd = new TextBox();
        lblPeriodZabraneOd = new Label();
        lblTip = new Label();
        btnDodaj = new Button();
        txtAdresa = new TextBox();
        txtNaziv = new TextBox();
        lblKapacitet = new Label();
        gbxPodaci.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numKapacitet).BeginInit();
        SuspendLayout();
        // 
        // lblNaziv
        // 
        lblNaziv.AutoSize = true;
        lblNaziv.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblNaziv.Location = new Point(110, 63);
        lblNaziv.Margin = new Padding(4, 0, 4, 0);
        lblNaziv.Name = "lblNaziv";
        lblNaziv.Size = new Size(56, 23);
        lblNaziv.TabIndex = 0;
        lblNaziv.Text = "Naziv:";
        // 
        // lblAdresa
        // 
        lblAdresa.AutoSize = true;
        lblAdresa.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblAdresa.Location = new Point(100, 114);
        lblAdresa.Margin = new Padding(4, 0, 4, 0);
        lblAdresa.Name = "lblAdresa";
        lblAdresa.Size = new Size(66, 23);
        lblAdresa.TabIndex = 2;
        lblAdresa.Text = "Adresa:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(cbxTip);
        gbxPodaci.Controls.Add(numKapacitet);
        gbxPodaci.Controls.Add(txtPeriodZabraneDo);
        gbxPodaci.Controls.Add(lblPeriodZabraneDo);
        gbxPodaci.Controls.Add(txtPeriodZabraneOd);
        gbxPodaci.Controls.Add(lblPeriodZabraneOd);
        gbxPodaci.Controls.Add(lblTip);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtAdresa);
        gbxPodaci.Controls.Add(txtNaziv);
        gbxPodaci.Controls.Add(lblKapacitet);
        gbxPodaci.Controls.Add(lblNaziv);
        gbxPodaci.Controls.Add(lblAdresa);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(16, 19);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 463);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o zatvorskoj jedinici";
        // 
        // cbxTip
        // 
        cbxTip.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxTip.FormattingEnabled = true;
        cbxTip.Items.AddRange(new object[] { "Otvorena", "Poluotvorena", "Zatvorena", "Otvorena-Poluotvorena", "Otvorena-Zatvorena", "Poluotvorena-Zatvorena" });
        cbxTip.Location = new Point(186, 217);
        cbxTip.Name = "cbxTip";
        cbxTip.Size = new Size(201, 29);
        cbxTip.TabIndex = 7;
        cbxTip.SelectedValueChanged += cbxTip_SelectedValueChanged;
        // 
        // numKapacitet
        // 
        numKapacitet.Location = new Point(186, 165);
        numKapacitet.Maximum = new decimal(new int[] { -1530494977, 232830, 0, 0 });
        numKapacitet.Name = "numKapacitet";
        numKapacitet.Size = new Size(201, 29);
        numKapacitet.TabIndex = 5;
        // 
        // txtPeriodZabraneDo
        // 
        txtPeriodZabraneDo.Location = new Point(186, 327);
        txtPeriodZabraneDo.Margin = new Padding(4, 5, 4, 5);
        txtPeriodZabraneDo.MaxLength = 5;
        txtPeriodZabraneDo.Name = "txtPeriodZabraneDo";
        txtPeriodZabraneDo.Size = new Size(201, 29);
        txtPeriodZabraneDo.TabIndex = 11;
        // 
        // lblPeriodZabraneDo
        // 
        lblPeriodZabraneDo.AutoSize = true;
        lblPeriodZabraneDo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPeriodZabraneDo.Location = new Point(13, 329);
        lblPeriodZabraneDo.Margin = new Padding(4, 0, 4, 0);
        lblPeriodZabraneDo.Name = "lblPeriodZabraneDo";
        lblPeriodZabraneDo.Size = new Size(153, 23);
        lblPeriodZabraneDo.TabIndex = 10;
        lblPeriodZabraneDo.Text = "Period zabrane od:";
        // 
        // txtPeriodZabraneOd
        // 
        txtPeriodZabraneOd.Location = new Point(186, 272);
        txtPeriodZabraneOd.Margin = new Padding(4, 5, 4, 5);
        txtPeriodZabraneOd.MaxLength = 5;
        txtPeriodZabraneOd.Name = "txtPeriodZabraneOd";
        txtPeriodZabraneOd.Size = new Size(201, 29);
        txtPeriodZabraneOd.TabIndex = 9;
        // 
        // lblPeriodZabraneOd
        // 
        lblPeriodZabraneOd.AutoSize = true;
        lblPeriodZabraneOd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPeriodZabraneOd.Location = new Point(13, 274);
        lblPeriodZabraneOd.Margin = new Padding(4, 0, 4, 0);
        lblPeriodZabraneOd.Name = "lblPeriodZabraneOd";
        lblPeriodZabraneOd.Size = new Size(153, 23);
        lblPeriodZabraneOd.TabIndex = 8;
        lblPeriodZabraneOd.Text = "Period zabrane od:";
        // 
        // lblTip
        // 
        lblTip.AutoSize = true;
        lblTip.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTip.Location = new Point(129, 219);
        lblTip.Margin = new Padding(4, 0, 4, 0);
        lblTip.Name = "lblTip";
        lblTip.Size = new Size(37, 23);
        lblTip.TabIndex = 6;
        lblTip.Text = "Tip:";
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(242, 382);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 12;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtAdresa
        // 
        txtAdresa.Location = new Point(186, 112);
        txtAdresa.Margin = new Padding(4, 5, 4, 5);
        txtAdresa.Name = "txtAdresa";
        txtAdresa.Size = new Size(201, 29);
        txtAdresa.TabIndex = 3;
        // 
        // txtNaziv
        // 
        txtNaziv.Location = new Point(186, 61);
        txtNaziv.Margin = new Padding(4, 5, 4, 5);
        txtNaziv.Name = "txtNaziv";
        txtNaziv.Size = new Size(201, 29);
        txtNaziv.TabIndex = 1;
        // 
        // lblKapacitet
        // 
        lblKapacitet.AutoSize = true;
        lblKapacitet.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblKapacitet.Location = new Point(81, 166);
        lblKapacitet.Margin = new Padding(4, 0, 4, 0);
        lblKapacitet.Name = "lblKapacitet";
        lblKapacitet.Size = new Size(85, 23);
        lblKapacitet.TabIndex = 4;
        lblKapacitet.Text = "Kapacitet:";
        // 
        // ZatvorskeJediniceDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 492);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 539);
        MinimizeBox = false;
        MinimumSize = new Size(461, 539);
        Name = "ZatvorskeJediniceDodaj";
        Text = "DODAVANJE ZATVORSKE JEDINICE";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numKapacitet).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblNaziv;
    private System.Windows.Forms.Label lblAdresa;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtAdresa;
    private System.Windows.Forms.TextBox txtNaziv;
    private System.Windows.Forms.Label lblKapacitet;
    private System.Windows.Forms.Label lblTip;
    private TextBox txtPeriodZabraneDo;
    private Label lblPeriodZabraneDo;
    private TextBox txtPeriodZabraneOd;
    private Label lblPeriodZabraneOd;
    private ComboBox cbxTip;
    private NumericUpDown numKapacitet;
}
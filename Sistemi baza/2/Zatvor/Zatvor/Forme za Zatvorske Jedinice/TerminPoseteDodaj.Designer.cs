namespace Zatvor.Forme_za_Zatvorske_Jedinice;

partial class TerminPoseteDodaj
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
        lblDan = new Label();
        lblTerminOd = new Label();
        gbxPodaci = new GroupBox();
        cbxDan = new ComboBox();
        txtTerminDo = new TextBox();
        btnDodaj = new Button();
        txtTerminOd = new TextBox();
        lblTerminDo = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblDan
        // 
        lblDan.AutoSize = true;
        lblDan.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblDan.Location = new Point(121, 63);
        lblDan.Margin = new Padding(4, 0, 4, 0);
        lblDan.Name = "lblDan";
        lblDan.Size = new Size(45, 23);
        lblDan.TabIndex = 0;
        lblDan.Text = "Dan:";
        // 
        // lblTerminOd
        // 
        lblTerminOd.AutoSize = true;
        lblTerminOd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTerminOd.Location = new Point(76, 112);
        lblTerminOd.Margin = new Padding(4, 0, 4, 0);
        lblTerminOd.Name = "lblTerminOd";
        lblTerminOd.Size = new Size(90, 23);
        lblTerminOd.TabIndex = 2;
        lblTerminOd.Text = "Termin od:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(cbxDan);
        gbxPodaci.Controls.Add(txtTerminDo);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtTerminOd);
        gbxPodaci.Controls.Add(lblTerminDo);
        gbxPodaci.Controls.Add(lblDan);
        gbxPodaci.Controls.Add(lblTerminOd);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(15, 17);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 309);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o terminu";
        // 
        // cbxDan
        // 
        cbxDan.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxDan.FormattingEnabled = true;
        cbxDan.Items.AddRange(new object[] { "Ponedeljak", "Utorak", "Sreda", "Četvrtak", "Petak", "Subota", "Nedelja" });
        cbxDan.Location = new Point(186, 61);
        cbxDan.Name = "cbxDan";
        cbxDan.Size = new Size(201, 29);
        cbxDan.TabIndex = 1;
        // 
        // txtTerminDo
        // 
        txtTerminDo.Location = new Point(186, 164);
        txtTerminDo.Margin = new Padding(4, 5, 4, 5);
        txtTerminDo.MaxLength = 5;
        txtTerminDo.Name = "txtTerminDo";
        txtTerminDo.Size = new Size(201, 29);
        txtTerminDo.TabIndex = 5;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(242, 234);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 6;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtTerminOd
        // 
        txtTerminOd.Location = new Point(186, 112);
        txtTerminOd.Margin = new Padding(4, 5, 4, 5);
        txtTerminOd.MaxLength = 5;
        txtTerminOd.Name = "txtTerminOd";
        txtTerminOd.Size = new Size(201, 29);
        txtTerminOd.TabIndex = 3;
        // 
        // lblTerminDo
        // 
        lblTerminDo.AutoSize = true;
        lblTerminDo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTerminDo.Location = new Point(76, 166);
        lblTerminDo.Margin = new Padding(4, 0, 4, 0);
        lblTerminDo.Name = "lblTerminDo";
        lblTerminDo.Size = new Size(90, 23);
        lblTerminDo.TabIndex = 4;
        lblTerminDo.Text = "Termin do:";
        // 
        // TerminPoseteDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 338);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 385);
        MinimizeBox = false;
        MinimumSize = new Size(461, 385);
        Name = "TerminPoseteDodaj";
        Text = "DODAVANJE TERMINA ZA POSETU";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Label lblDan;
    private System.Windows.Forms.Label lblTerminOd;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtTerminOd;
    private System.Windows.Forms.Label lblTerminDo;
    private TextBox txtTerminDo;
    private ComboBox cbxDan;
}
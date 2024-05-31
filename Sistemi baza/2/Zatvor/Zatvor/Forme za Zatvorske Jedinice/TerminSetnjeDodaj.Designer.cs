namespace Zatvor.Forme_za_Zatvorske_Jedinice;

partial class TerminSetnjeDodaj
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
        lblTerminOd = new Label();
        gbxPodaci = new GroupBox();
        txtTerminDo = new TextBox();
        btnDodaj = new Button();
        txtTerminOd = new TextBox();
        lblTerminDo = new Label();
        gbxPodaci.SuspendLayout();
        SuspendLayout();
        // 
        // lblTerminOd
        // 
        lblTerminOd.AutoSize = true;
        lblTerminOd.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTerminOd.Location = new Point(76, 71);
        lblTerminOd.Margin = new Padding(4, 0, 4, 0);
        lblTerminOd.Name = "lblTerminOd";
        lblTerminOd.Size = new Size(90, 23);
        lblTerminOd.TabIndex = 0;
        lblTerminOd.Text = "Termin od:";
        // 
        // gbxPodaci
        // 
        gbxPodaci.Controls.Add(txtTerminDo);
        gbxPodaci.Controls.Add(btnDodaj);
        gbxPodaci.Controls.Add(txtTerminOd);
        gbxPodaci.Controls.Add(lblTerminDo);
        gbxPodaci.Controls.Add(lblTerminOd);
        gbxPodaci.Font = new Font("Segoe UI", 9.75F);
        gbxPodaci.Location = new Point(15, 17);
        gbxPodaci.Margin = new Padding(4, 5, 4, 5);
        gbxPodaci.Name = "gbxPodaci";
        gbxPodaci.Padding = new Padding(4, 5, 4, 5);
        gbxPodaci.Size = new Size(415, 243);
        gbxPodaci.TabIndex = 0;
        gbxPodaci.TabStop = false;
        gbxPodaci.Text = "Podaci o terminu";
        // 
        // txtTerminDo
        // 
        txtTerminDo.Location = new Point(186, 122);
        txtTerminDo.Margin = new Padding(4, 5, 4, 5);
        txtTerminDo.MaxLength = 5;
        txtTerminDo.Name = "txtTerminDo";
        txtTerminDo.Size = new Size(201, 29);
        txtTerminDo.TabIndex = 3;
        // 
        // btnDodaj
        // 
        btnDodaj.BackColor = Color.Transparent;
        btnDodaj.Font = new Font("Segoe UI", 9F);
        btnDodaj.Location = new Point(242, 172);
        btnDodaj.Margin = new Padding(4, 5, 4, 5);
        btnDodaj.Name = "btnDodaj";
        btnDodaj.Size = new Size(145, 56);
        btnDodaj.TabIndex = 4;
        btnDodaj.Text = "DODAJ";
        btnDodaj.UseVisualStyleBackColor = false;
        btnDodaj.Click += btnDodaj_Click;
        // 
        // txtTerminOd
        // 
        txtTerminOd.Location = new Point(186, 69);
        txtTerminOd.Margin = new Padding(4, 5, 4, 5);
        txtTerminOd.MaxLength = 5;
        txtTerminOd.Name = "txtTerminOd";
        txtTerminOd.Size = new Size(201, 29);
        txtTerminOd.TabIndex = 1;
        // 
        // lblTerminDo
        // 
        lblTerminDo.AutoSize = true;
        lblTerminDo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTerminDo.Location = new Point(76, 124);
        lblTerminDo.Margin = new Padding(4, 0, 4, 0);
        lblTerminDo.Name = "lblTerminDo";
        lblTerminDo.Size = new Size(90, 23);
        lblTerminDo.TabIndex = 2;
        lblTerminDo.Text = "Termin do:";
        // 
        // TerminSetnjeDodaj
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(443, 275);
        Controls.Add(gbxPodaci);
        Margin = new Padding(4, 5, 4, 5);
        MaximizeBox = false;
        MaximumSize = new Size(461, 322);
        MinimizeBox = false;
        MinimumSize = new Size(461, 322);
        Name = "TerminSetnjeDodaj";
        Text = "DODAVANJE TERMINA ZA POSETU";
        gbxPodaci.ResumeLayout(false);
        gbxPodaci.PerformLayout();
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Label lblTerminOd;
    private System.Windows.Forms.GroupBox gbxPodaci;
    private System.Windows.Forms.Button btnDodaj;
    private System.Windows.Forms.TextBox txtTerminOd;
    private System.Windows.Forms.Label lblTerminDo;
    private TextBox txtTerminDo;
}
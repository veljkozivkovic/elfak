namespace Zatvor.Forme_za_Zatvorske_Jedinice;

partial class TerminiSetnje
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
        listaTermina = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader3 = new ColumnHeader();
        columnHeader4 = new ColumnHeader();
        gbxTermini = new GroupBox();
        btnDodajTermin = new Button();
        btnIzmeniTermin = new Button();
        btnObrisiTermin = new Button();
        gbxLista.SuspendLayout();
        gbxTermini.SuspendLayout();
        SuspendLayout();
        // 
        // gbxLista
        // 
        gbxLista.Controls.Add(listaTermina);
        gbxLista.Location = new Point(14, 16);
        gbxLista.Margin = new Padding(3, 4, 3, 4);
        gbxLista.Name = "gbxLista";
        gbxLista.Padding = new Padding(3, 4, 3, 4);
        gbxLista.Size = new Size(329, 571);
        gbxLista.TabIndex = 0;
        gbxLista.TabStop = false;
        gbxLista.Text = "Lista termina";
        // 
        // listaTermina
        // 
        listaTermina.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader3, columnHeader4 });
        listaTermina.Dock = DockStyle.Fill;
        listaTermina.FullRowSelect = true;
        listaTermina.GridLines = true;
        listaTermina.Location = new Point(3, 24);
        listaTermina.Margin = new Padding(3, 4, 3, 4);
        listaTermina.Name = "listaTermina";
        listaTermina.Size = new Size(323, 543);
        listaTermina.TabIndex = 0;
        listaTermina.UseCompatibleStateImageBehavior = false;
        listaTermina.View = View.Details;
        // 
        // columnHeader1
        // 
        columnHeader1.Tag = "sa";
        columnHeader1.Text = "Id";
        columnHeader1.Width = 80;
        // 
        // columnHeader3
        // 
        columnHeader3.Text = "Od";
        columnHeader3.Width = 120;
        // 
        // columnHeader4
        // 
        columnHeader4.Text = "Do";
        columnHeader4.Width = 120;
        // 
        // gbxTermini
        // 
        gbxTermini.Controls.Add(btnDodajTermin);
        gbxTermini.Controls.Add(btnIzmeniTermin);
        gbxTermini.Controls.Add(btnObrisiTermin);
        gbxTermini.Location = new Point(370, 174);
        gbxTermini.Margin = new Padding(3, 4, 3, 4);
        gbxTermini.Name = "gbxTermini";
        gbxTermini.Padding = new Padding(3, 4, 3, 4);
        gbxTermini.Size = new Size(142, 287);
        gbxTermini.TabIndex = 1;
        gbxTermini.TabStop = false;
        gbxTermini.Text = "Termin";
        // 
        // btnDodajTermin
        // 
        btnDodajTermin.Location = new Point(9, 28);
        btnDodajTermin.Margin = new Padding(3, 4, 3, 4);
        btnDodajTermin.Name = "btnDodajTermin";
        btnDodajTermin.Size = new Size(125, 55);
        btnDodajTermin.TabIndex = 0;
        btnDodajTermin.Text = "Dodaj termin";
        btnDodajTermin.UseVisualStyleBackColor = true;
        btnDodajTermin.Click += btnDodajTermin_Click;
        // 
        // btnIzmeniTermin
        // 
        btnIzmeniTermin.Location = new Point(9, 215);
        btnIzmeniTermin.Margin = new Padding(3, 4, 3, 4);
        btnIzmeniTermin.Name = "btnIzmeniTermin";
        btnIzmeniTermin.Size = new Size(125, 55);
        btnIzmeniTermin.TabIndex = 2;
        btnIzmeniTermin.Text = "Izmeni termin";
        btnIzmeniTermin.UseVisualStyleBackColor = true;
        btnIzmeniTermin.Click += btnIzmeniTermin_Click;
        // 
        // btnObrisiTermin
        // 
        btnObrisiTermin.Location = new Point(9, 123);
        btnObrisiTermin.Margin = new Padding(3, 4, 3, 4);
        btnObrisiTermin.Name = "btnObrisiTermin";
        btnObrisiTermin.Size = new Size(125, 55);
        btnObrisiTermin.TabIndex = 1;
        btnObrisiTermin.Text = "Obriši termin";
        btnObrisiTermin.UseVisualStyleBackColor = true;
        btnObrisiTermin.Click += btnObrisiTermin_Click;
        // 
        // TerminiSetnje
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(532, 600);
        Controls.Add(gbxTermini);
        Controls.Add(gbxLista);
        Margin = new Padding(3, 4, 3, 4);
        MaximizeBox = false;
        MaximumSize = new Size(550, 647);
        MinimizeBox = false;
        MinimumSize = new Size(550, 647);
        Name = "TerminiSetnje";
        Text = "TERMINI ZA ŠETNJU";
        Load += TerminiPosete_Load;
        gbxLista.ResumeLayout(false);
        gbxTermini.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox gbxLista;
    private ListView listaTermina;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader3;
    private ColumnHeader columnHeader4;
    private GroupBox gbxTermini;
    private Button btnDodajTermin;
    private Button btnIzmeniTermin;
    private Button btnObrisiTermin;
}
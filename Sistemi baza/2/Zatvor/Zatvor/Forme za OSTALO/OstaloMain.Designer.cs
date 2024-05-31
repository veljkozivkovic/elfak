namespace Zatvor.Forme_za_OSTALO
{
    partial class OstaloMain
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
            btnPrestupi = new Button();
            btnFirme = new Button();
            btnAdvokati = new Button();
            SuspendLayout();
            // 
            // btnPrestupi
            // 
            btnPrestupi.Location = new Point(183, 306);
            btnPrestupi.Margin = new Padding(3, 4, 3, 4);
            btnPrestupi.Name = "btnPrestupi";
            btnPrestupi.Size = new Size(135, 65);
            btnPrestupi.TabIndex = 2;
            btnPrestupi.Text = "PRESTUPI";
            btnPrestupi.UseVisualStyleBackColor = true;
            btnPrestupi.Click += btnPrestupi_Click;
            // 
            // btnFirme
            // 
            btnFirme.Location = new Point(183, 204);
            btnFirme.Margin = new Padding(3, 4, 3, 4);
            btnFirme.Name = "btnFirme";
            btnFirme.Size = new Size(135, 65);
            btnFirme.TabIndex = 1;
            btnFirme.Text = "FIRME";
            btnFirme.UseVisualStyleBackColor = true;
            btnFirme.Click += btnFirme_Click;
            // 
            // btnAdvokati
            // 
            btnAdvokati.Location = new Point(183, 112);
            btnAdvokati.Margin = new Padding(3, 4, 3, 4);
            btnAdvokati.Name = "btnAdvokati";
            btnAdvokati.Size = new Size(135, 65);
            btnAdvokati.TabIndex = 0;
            btnAdvokati.Text = "ADVOKATI";
            btnAdvokati.UseVisualStyleBackColor = true;
            btnAdvokati.Click += btnAdvokati_Click;
            // 
            // OstaloMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 489);
            Controls.Add(btnAdvokati);
            Controls.Add(btnFirme);
            Controls.Add(btnPrestupi);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MaximumSize = new Size(507, 536);
            MinimizeBox = false;
            MinimumSize = new Size(507, 536);
            Name = "OstaloMain";
            Text = "OSTALO";
            ResumeLayout(false);
        }

        #endregion
        private Button btnPrestupi;
        private Button btnFirme;
        private Button btnAdvokati;
    }
}
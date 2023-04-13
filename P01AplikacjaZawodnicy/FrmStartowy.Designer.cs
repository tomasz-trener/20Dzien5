namespace P01AplikacjaZawodnicy
{
    partial class FrmStartowy
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
            this.lblSredniWzrost = new System.Windows.Forms.Label();
            this.lbDane = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbKraje = new System.Windows.Forms.ComboBox();
            this.btnSzczegoly = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUsunIPokaz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSredniWzrost
            // 
            this.lblSredniWzrost.AutoSize = true;
            this.lblSredniWzrost.Location = new System.Drawing.Point(193, 31);
            this.lblSredniWzrost.Name = "lblSredniWzrost";
            this.lblSredniWzrost.Size = new System.Drawing.Size(35, 13);
            this.lblSredniWzrost.TabIndex = 7;
            this.lblSredniWzrost.Text = "label2";
            // 
            // lbDane
            // 
            this.lbDane.FormattingEnabled = true;
            this.lbDane.Location = new System.Drawing.Point(11, 55);
            this.lbDane.Name = "lbDane";
            this.lbDane.Size = new System.Drawing.Size(176, 238);
            this.lbDane.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Podaj kraj";
            // 
            // cbKraje
            // 
            this.cbKraje.FormattingEnabled = true;
            this.cbKraje.Location = new System.Drawing.Point(11, 28);
            this.cbKraje.Name = "cbKraje";
            this.cbKraje.Size = new System.Drawing.Size(176, 21);
            this.cbKraje.TabIndex = 4;
            this.cbKraje.SelectedIndexChanged += new System.EventHandler(this.cbKraje_SelectedIndexChanged);
            // 
            // btnSzczegoly
            // 
            this.btnSzczegoly.Location = new System.Drawing.Point(196, 55);
            this.btnSzczegoly.Name = "btnSzczegoly";
            this.btnSzczegoly.Size = new System.Drawing.Size(91, 23);
            this.btnSzczegoly.TabIndex = 8;
            this.btnSzczegoly.Text = "Szczegóły";
            this.btnSzczegoly.UseVisualStyleBackColor = true;
            this.btnSzczegoly.Click += new System.EventHandler(this.btnSzczegoly_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Location = new System.Drawing.Point(196, 85);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(91, 23);
            this.btnUsun.TabIndex = 9;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(193, 143);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(91, 23);
            this.btnDodaj.TabIndex = 10;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUsunIPokaz
            // 
            this.btnUsunIPokaz.Location = new System.Drawing.Point(196, 114);
            this.btnUsunIPokaz.Name = "btnUsunIPokaz";
            this.btnUsunIPokaz.Size = new System.Drawing.Size(91, 23);
            this.btnUsunIPokaz.TabIndex = 11;
            this.btnUsunIPokaz.Text = "Usuń i pokaż";
            this.btnUsunIPokaz.UseVisualStyleBackColor = true;
            this.btnUsunIPokaz.Click += new System.EventHandler(this.btnUsunIPokaz_Click);
            // 
            // FrmStartowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 310);
            this.Controls.Add(this.btnUsunIPokaz);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnSzczegoly);
            this.Controls.Add(this.lblSredniWzrost);
            this.Controls.Add(this.lbDane);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKraje);
            this.Name = "FrmStartowy";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSredniWzrost;
        private System.Windows.Forms.ListBox lbDane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbKraje;
        private System.Windows.Forms.Button btnSzczegoly;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnUsunIPokaz;
    }
}


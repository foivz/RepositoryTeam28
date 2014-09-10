namespace Booker.Forme
{
    partial class frmUpravljanjeZanrovima
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
            this.txtZanr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDodajZanr = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.cmb = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtZanr
            // 
            this.txtZanr.Location = new System.Drawing.Point(109, 24);
            this.txtZanr.Name = "txtZanr";
            this.txtZanr.Size = new System.Drawing.Size(146, 20);
            this.txtZanr.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Naziv žanra";
            // 
            // btnDodajZanr
            // 
            this.btnDodajZanr.Location = new System.Drawing.Point(109, 65);
            this.btnDodajZanr.Name = "btnDodajZanr";
            this.btnDodajZanr.Size = new System.Drawing.Size(86, 27);
            this.btnDodajZanr.TabIndex = 2;
            this.btnDodajZanr.Text = "Dodaj žanr";
            this.btnDodajZanr.UseVisualStyleBackColor = true;
            this.btnDodajZanr.Click += new System.EventHandler(this.btnDodajZanr_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(314, 160);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtZanr);
            this.tabPage1.Controls.Add(this.btnDodajZanr);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(306, 134);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dodavanje žanrova";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnObrisi);
            this.tabPage2.Controls.Add(this.cmb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(306, 134);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Brisanje žanrova";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(105, 67);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(93, 27);
            this.btnObrisi.TabIndex = 3;
            this.btnObrisi.Text = "Obriši žanr";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // cmb
            // 
            this.cmb.FormattingEnabled = true;
            this.cmb.Location = new System.Drawing.Point(82, 29);
            this.cmb.Name = "cmb";
            this.cmb.Size = new System.Drawing.Size(143, 21);
            this.cmb.TabIndex = 2;
            // 
            // frmUpravljanjeZanrovima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 161);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmUpravljanjeZanrovima";
            this.Text = "Upravljanje žanrovima";
            this.Load += new System.EventHandler(this.frmDodajZanr_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtZanr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodajZanr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.ComboBox cmb;
    }
}
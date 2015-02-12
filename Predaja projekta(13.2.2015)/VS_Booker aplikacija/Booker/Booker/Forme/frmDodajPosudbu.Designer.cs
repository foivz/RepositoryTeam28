namespace Booker.Forme
{
    partial class frmDodajPosudbu
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
            this.cmbKnjige = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKorisnici = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chb15 = new System.Windows.Forms.CheckBox();
            this.chb30 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbKnjige
            // 
            this.cmbKnjige.FormattingEnabled = true;
            this.cmbKnjige.Location = new System.Drawing.Point(132, 22);
            this.cmbKnjige.Name = "cmbKnjige";
            this.cmbKnjige.Size = new System.Drawing.Size(194, 21);
            this.cmbKnjige.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Odaberi knjigu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Odaberi korisnika";
            // 
            // cmbKorisnici
            // 
            this.cmbKorisnici.FormattingEnabled = true;
            this.cmbKorisnici.Location = new System.Drawing.Point(132, 61);
            this.cmbKorisnici.Name = "cmbKorisnici";
            this.cmbKorisnici.Size = new System.Drawing.Size(121, 21);
            this.cmbKorisnici.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Dodaj posudbu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chb15
            // 
            this.chb15.AutoSize = true;
            this.chb15.Location = new System.Drawing.Point(62, 107);
            this.chb15.Name = "chb15";
            this.chb15.Size = new System.Drawing.Size(65, 17);
            this.chb15.TabIndex = 5;
            this.chb15.Text = "15 dana";
            this.chb15.UseVisualStyleBackColor = true;
            this.chb15.CheckedChanged += new System.EventHandler(this.chb15_CheckedChanged);
            // 
            // chb30
            // 
            this.chb30.AutoSize = true;
            this.chb30.Location = new System.Drawing.Point(157, 107);
            this.chb30.Name = "chb30";
            this.chb30.Size = new System.Drawing.Size(65, 17);
            this.chb30.TabIndex = 6;
            this.chb30.Text = "30 dana";
            this.chb30.UseVisualStyleBackColor = true;
            this.chb30.CheckedChanged += new System.EventHandler(this.chb30_CheckedChanged);
            // 
            // frmDodajPosudbu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 204);
            this.Controls.Add(this.chb30);
            this.Controls.Add(this.chb15);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKorisnici);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKnjige);
            this.Name = "frmDodajPosudbu";
            this.Text = "Dodaj posudbu";
            this.Load += new System.EventHandler(this.frmDodajPosudbu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbKnjige;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKorisnici;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chb15;
        private System.Windows.Forms.CheckBox chb30;
    }
}
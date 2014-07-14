namespace Booker.Forme
{
    partial class frmPostavke
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
            this.btnDodajZanr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDodajZanr
            // 
            this.btnDodajZanr.Location = new System.Drawing.Point(65, 31);
            this.btnDodajZanr.Name = "btnDodajZanr";
            this.btnDodajZanr.Size = new System.Drawing.Size(123, 55);
            this.btnDodajZanr.TabIndex = 0;
            this.btnDodajZanr.Text = "Upravljanje žanrovima";
            this.btnDodajZanr.UseVisualStyleBackColor = true;
            this.btnDodajZanr.Click += new System.EventHandler(this.btnDodajZanr_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(65, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "Upravljanje autorima";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(65, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 54);
            this.button2.TabIndex = 2;
            this.button2.Text = "Upravljanje izdavačima";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPostavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDodajZanr);
            this.Name = "frmPostavke";
            this.Text = "Postavke";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDodajZanr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
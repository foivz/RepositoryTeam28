namespace Booker.Forme
{
    partial class frmPregledPosudbi
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTrazi2 = new System.Windows.Forms.Button();
            this.txtTraziPosudba = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(596, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "Vrati knjigu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTrazi2
            // 
            this.btnTrazi2.Location = new System.Drawing.Point(330, 32);
            this.btnTrazi2.Name = "btnTrazi2";
            this.btnTrazi2.Size = new System.Drawing.Size(75, 23);
            this.btnTrazi2.TabIndex = 2;
            this.btnTrazi2.Text = "Traži";
            this.btnTrazi2.UseVisualStyleBackColor = true;
            this.btnTrazi2.Click += new System.EventHandler(this.btnTrazi2_Click);
            // 
            // txtTraziPosudba
            // 
            this.txtTraziPosudba.Location = new System.Drawing.Point(429, 34);
            this.txtTraziPosudba.Name = "txtTraziPosudba";
            this.txtTraziPosudba.Size = new System.Drawing.Size(151, 20);
            this.txtTraziPosudba.TabIndex = 3;
            // 
            // frmPregledPosudbi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 492);
            this.Controls.Add(this.txtTraziPosudba);
            this.Controls.Add(this.btnTrazi2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmPregledPosudbi";
            this.Text = "Pregled posudbi";
            this.Load += new System.EventHandler(this.frmPregledPosudbi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTrazi2;
        private System.Windows.Forms.TextBox txtTraziPosudba;
    }
}
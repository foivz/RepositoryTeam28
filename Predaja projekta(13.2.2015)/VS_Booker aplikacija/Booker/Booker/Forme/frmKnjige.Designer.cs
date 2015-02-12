namespace Booker.Forme
{
    partial class frmKnjige
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
            this.dgdKnjige = new System.Windows.Forms.DataGridView();
            this.dgdKomentari = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxKomentar = new System.Windows.Forms.TextBox();
            this.btnKomentiraj = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrazi = new System.Windows.Forms.TextBox();
            this.btnTrazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdKnjige)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdKomentari)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdKnjige
            // 
            this.dgdKnjige.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdKnjige.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgdKnjige.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdKnjige.Location = new System.Drawing.Point(12, 40);
            this.dgdKnjige.Name = "dgdKnjige";
            this.dgdKnjige.ReadOnly = true;
            this.dgdKnjige.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdKnjige.Size = new System.Drawing.Size(867, 359);
            this.dgdKnjige.TabIndex = 0;
            this.dgdKnjige.SelectionChanged += new System.EventHandler(this.dgdKnjige_SelectionChanged);
            // 
            // dgdKomentari
            // 
            this.dgdKomentari.AllowUserToAddRows = false;
            this.dgdKomentari.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdKomentari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdKomentari.Location = new System.Drawing.Point(12, 444);
            this.dgdKomentari.Name = "dgdKomentari";
            this.dgdKomentari.ReadOnly = true;
            this.dgdKomentari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdKomentari.Size = new System.Drawing.Size(561, 205);
            this.dgdKomentari.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Komentari";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Popis";
            // 
            // tbxKomentar
            // 
            this.tbxKomentar.Location = new System.Drawing.Point(627, 444);
            this.tbxKomentar.MaxLength = 100;
            this.tbxKomentar.Multiline = true;
            this.tbxKomentar.Name = "tbxKomentar";
            this.tbxKomentar.Size = new System.Drawing.Size(215, 131);
            this.tbxKomentar.TabIndex = 8;
            // 
            // btnKomentiraj
            // 
            this.btnKomentiraj.Location = new System.Drawing.Point(681, 594);
            this.btnKomentiraj.Name = "btnKomentiraj";
            this.btnKomentiraj.Size = new System.Drawing.Size(102, 43);
            this.btnKomentiraj.TabIndex = 9;
            this.btnKomentiraj.Text = "Komentiraj";
            this.btnKomentiraj.UseVisualStyleBackColor = true;
            this.btnKomentiraj.Click += new System.EventHandler(this.btnKomentiraj_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(624, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Napiši komentar";
            // 
            // txtTrazi
            // 
            this.txtTrazi.Location = new System.Drawing.Point(373, 13);
            this.txtTrazi.Name = "txtTrazi";
            this.txtTrazi.Size = new System.Drawing.Size(144, 20);
            this.txtTrazi.TabIndex = 11;
            // 
            // btnTrazi
            // 
            this.btnTrazi.Location = new System.Drawing.Point(263, 11);
            this.btnTrazi.Name = "btnTrazi";
            this.btnTrazi.Size = new System.Drawing.Size(93, 23);
            this.btnTrazi.TabIndex = 12;
            this.btnTrazi.Text = "Traži";
            this.btnTrazi.UseVisualStyleBackColor = true;
            this.btnTrazi.Click += new System.EventHandler(this.btnTrazi_Click);
            // 
            // frmKnjige
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 661);
            this.Controls.Add(this.btnTrazi);
            this.Controls.Add(this.txtTrazi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnKomentiraj);
            this.Controls.Add(this.tbxKomentar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgdKomentari);
            this.Controls.Add(this.dgdKnjige);
            this.Name = "frmKnjige";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Popis knjiga";
            this.Load += new System.EventHandler(this.frmKnjige_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgdKnjige)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdKomentari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdKnjige;
        private System.Windows.Forms.DataGridView dgdKomentari;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxKomentar;
        private System.Windows.Forms.Button btnKomentiraj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrazi;
        private System.Windows.Forms.Button btnTrazi;
    }
}
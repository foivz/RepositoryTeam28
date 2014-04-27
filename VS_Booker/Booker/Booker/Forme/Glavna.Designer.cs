namespace Booker.Forme
{
    partial class frmGlavna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGlavna));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knjigeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKnjigaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKnjiguToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posudbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledPosudbiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajPosudbuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izlazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPodaci = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.knjigeToolStripMenuItem,
            this.posudbeToolStripMenuItem,
            this.postavkeToolStripMenuItem,
            this.izlazToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(304, 729);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKorisnikaToolStripMenuItem,
            this.dodajKorisnikaToolStripMenuItem});
            this.korisniciToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("korisniciToolStripMenuItem.Image")));
            this.korisniciToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(291, 132);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // knjigeToolStripMenuItem
            // 
            this.knjigeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKnjigaToolStripMenuItem,
            this.dodajKnjiguToolStripMenuItem});
            this.knjigeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("knjigeToolStripMenuItem.Image")));
            this.knjigeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.knjigeToolStripMenuItem.Name = "knjigeToolStripMenuItem";
            this.knjigeToolStripMenuItem.Size = new System.Drawing.Size(291, 132);
            this.knjigeToolStripMenuItem.Text = "Knjige";
            // 
            // pregledKorisnikaToolStripMenuItem
            // 
            this.pregledKorisnikaToolStripMenuItem.Name = "pregledKorisnikaToolStripMenuItem";
            this.pregledKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(364, 52);
            this.pregledKorisnikaToolStripMenuItem.Text = "Pregled korisnika";
            this.pregledKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.pregledKorisnikaToolStripMenuItem_Click);
            // 
            // dodajKorisnikaToolStripMenuItem
            // 
            this.dodajKorisnikaToolStripMenuItem.Name = "dodajKorisnikaToolStripMenuItem";
            this.dodajKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(364, 52);
            this.dodajKorisnikaToolStripMenuItem.Text = "Dodaj korisnika";
            this.dodajKorisnikaToolStripMenuItem.Click += new System.EventHandler(this.dodajKorisnikaToolStripMenuItem_Click);
            // 
            // pregledKnjigaToolStripMenuItem
            // 
            this.pregledKnjigaToolStripMenuItem.Name = "pregledKnjigaToolStripMenuItem";
            this.pregledKnjigaToolStripMenuItem.Size = new System.Drawing.Size(320, 52);
            this.pregledKnjigaToolStripMenuItem.Text = "Pregled knjiga";
            this.pregledKnjigaToolStripMenuItem.Click += new System.EventHandler(this.pregledKnjigaToolStripMenuItem_Click);
            // 
            // dodajKnjiguToolStripMenuItem
            // 
            this.dodajKnjiguToolStripMenuItem.Name = "dodajKnjiguToolStripMenuItem";
            this.dodajKnjiguToolStripMenuItem.Size = new System.Drawing.Size(320, 52);
            this.dodajKnjiguToolStripMenuItem.Text = "Dodaj knjigu";
            // 
            // posudbeToolStripMenuItem
            // 
            this.posudbeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledPosudbiToolStripMenuItem,
            this.dodajPosudbuToolStripMenuItem});
            this.posudbeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("posudbeToolStripMenuItem.Image")));
            this.posudbeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.posudbeToolStripMenuItem.Name = "posudbeToolStripMenuItem";
            this.posudbeToolStripMenuItem.Size = new System.Drawing.Size(291, 132);
            this.posudbeToolStripMenuItem.Text = "Posudbe";
            // 
            // pregledPosudbiToolStripMenuItem
            // 
            this.pregledPosudbiToolStripMenuItem.Name = "pregledPosudbiToolStripMenuItem";
            this.pregledPosudbiToolStripMenuItem.Size = new System.Drawing.Size(355, 52);
            this.pregledPosudbiToolStripMenuItem.Text = "Pregled posudbi";
            // 
            // dodajPosudbuToolStripMenuItem
            // 
            this.dodajPosudbuToolStripMenuItem.Name = "dodajPosudbuToolStripMenuItem";
            this.dodajPosudbuToolStripMenuItem.Size = new System.Drawing.Size(355, 52);
            this.dodajPosudbuToolStripMenuItem.Text = "Dodaj posudbu";
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem});
            this.postavkeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("postavkeToolStripMenuItem.Image")));
            this.postavkeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            this.postavkeToolStripMenuItem.Size = new System.Drawing.Size(291, 132);
            this.postavkeToolStripMenuItem.Text = "Postavke";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(180, 52);
            this.profilToolStripMenuItem.Text = "Profil";
            // 
            // izlazToolStripMenuItem
            // 
            this.izlazToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("izlazToolStripMenuItem.Image")));
            this.izlazToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.izlazToolStripMenuItem.Name = "izlazToolStripMenuItem";
            this.izlazToolStripMenuItem.Size = new System.Drawing.Size(291, 132);
            this.izlazToolStripMenuItem.Text = "Izlaz";
            this.izlazToolStripMenuItem.Click += new System.EventHandler(this.izlazToolStripMenuItem_Click);
            // 
            // lblPodaci
            // 
            this.lblPodaci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPodaci.AutoSize = true;
            this.lblPodaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPodaci.Location = new System.Drawing.Point(306, 678);
            this.lblPodaci.Name = "lblPodaci";
            this.lblPodaci.Size = new System.Drawing.Size(60, 24);
            this.lblPodaci.TabIndex = 4;
            this.lblPodaci.Text = "label1";
            // 
            // lblTip
            // 
            this.lblTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTip.AutoSize = true;
            this.lblTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTip.Location = new System.Drawing.Point(307, 702);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(46, 18);
            this.lblTip.TabIndex = 5;
            this.lblTip.Text = "label2";
            // 
            // frmGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lblPodaci);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glavna";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKorisnikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem knjigeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledKnjigaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKnjiguToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posudbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledPosudbiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajPosudbuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izlazToolStripMenuItem;
        private System.Windows.Forms.Label lblPodaci;
        private System.Windows.Forms.Label lblTip;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booker.Forme
{
    public partial class frmGlavna : Form
    {
        string korIme;
        int tip;

        public frmGlavna(string korIme, int tip)
        {
            InitializeComponent();

            this.korIme = korIme;
            this.tip = tip;
            lblPodaci.Text = korIme;
            if (tip == 2)
            {
                lblTip.Text = "Administrator";
            }
            else
            {
                lblTip.Text = "Korisnik";
                korisniciToolStripMenuItem.Visible = false;
                dodajPosudbuToolStripMenuItem.Visible = false;
                postavkeToolStripMenuItem.Visible = false;
                dodavanjeKnjigaToolStripMenuItem.Visible = false;
                btnHelp.Visible = false;
            }
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Jeste li sigurni da želite izaći", "Izlaz", MessageBoxButtons.YesNo);
            if (d == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pregledKnjigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKnjige knjige = new frmKnjige();
            knjige.ShowDialog();
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici korisnici = new frmKorisnici();
            korisnici.ShowDialog();
        }

        private void postavkeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPostavke frmPostavke = new frmPostavke();
            frmPostavke.ShowDialog();

        }

        private void pregledKnjigaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmKnjige frmKnjige = new frmKnjige(korIme);
            frmKnjige.ShowDialog();
        }

        private void dodavanjeKnjigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKnjigu frmDodajKnjigu = new frmDodajKnjigu(korIme);
            frmDodajKnjigu.ShowDialog();
        }

        private void dodajPosudbuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajPosudbu frmDodajPosudbu = new frmDodajPosudbu(korIme);
            frmDodajPosudbu.ShowDialog();
        }

        private void pregledPosudbiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPregledPosudbi frmPregledPosudbi = new frmPregledPosudbi(korIme);
            frmPregledPosudbi.ShowDialog();
        }

        private void frmGlavna_Load(object sender, EventArgs e)
        {
            

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            Process.Start(path+"/Help/Help.html");
        }

    }

    
}


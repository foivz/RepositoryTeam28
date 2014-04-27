using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booker.Forme
{
    public partial class frmGlavna : Form
    {
        string ime, prezime, tip;

        public frmGlavna(string ime, string prezime, string tip)
        {
            InitializeComponent();

            this.ime = ime;
            this.prezime = prezime;
            this.tip = tip;
            lblPodaci.Text = ime + " " + prezime;
            if (tip == "0")
            {
                lblTip.Text = "Administrator";
            }
            else
            {
                lblTip.Text = "Korisnik";
                korisniciToolStripMenuItem.Visible = false;
                dodajPosudbuToolStripMenuItem.Visible = false;
                dodajKnjiguToolStripMenuItem.Visible = false;
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

        private void pregledKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici korisnici = new frmKorisnici();
            korisnici.ShowDialog();
        }

        private void dodajKorisnikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika dodajKorisnika = new frmDodajKorisnika();
            dodajKorisnika.ShowDialog();
        }

        private void pregledKnjigaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKnjige knjige = new frmKnjige();
            knjige.ShowDialog();
        }
    }
}


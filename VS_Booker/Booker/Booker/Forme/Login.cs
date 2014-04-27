using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda za provjeru logina. Ako je uspješan login, korisnika se redirecta na glavnu formu!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Pogriješili ste prilikom logiranja, molimo pokušajte ponovo!");
            }
            else
            {
                //TIPS, ctrl + k, ctrl + d autoformat
                string ime, prezime, tip;
                if (txtUsername.Text == "a")
                {
                    ime = "Admin";
                    prezime = "Admin";
                    tip = "0";
                    Statics.username = "ADMIN!";
                }
                else
                {
                    ime = "Korisnik";
                    prezime = "Korisnik";
                    tip = "1";
                    Statics.username = "KORISNIK!";
                }
                Forme.frmGlavna glavna = new Forme.frmGlavna(ime,prezime,tip);
                this.Hide();
                glavna.ShowDialog();
                Application.Exit();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

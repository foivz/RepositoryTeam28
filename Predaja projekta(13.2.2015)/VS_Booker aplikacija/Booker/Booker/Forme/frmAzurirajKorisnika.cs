using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Booker.Model;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Booker.Forme
{



    public partial class frmAzurirajKorisnika : Form
    {
        private BookerDBEntities dbEntities = new BookerDBEntities();

        public frmAzurirajKorisnika()
        {
            InitializeComponent();
        }

        private string username;
        private DataGridView dataGridView;
        public frmAzurirajKorisnika(string username, DataGridView dataGridView)
        {
            this.username = username;
            this.dataGridView = dataGridView;
            InitializeComponent();
        }

        private void frmAzurirajKorisnika_Load(object sender, EventArgs e)
        {
            korisnici korisnik = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
            tbxUserName.Text = username;
            tbxEmail.Text = korisnik.email;
            tbxPassword.Text = korisnik.lozinka;

            if (korisnik.pravaid_prava.Equals(2))
            {
                checkBox1.Checked = true;
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            int korisnikPravo = 1;

            if (tbxEmail.Text.Equals("") || tbxPassword.Text.Equals(""))
            {
                MessageBox.Show("Morate popuniti sva polja!");
            }
            else
            {
                if (checkBox1.Checked)
                {
                    korisnikPravo = 2;
                }

                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite ažurirati korisničke podatke?", "Potvrdi ažuriranje korisnika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    korisnici korisnik = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
                    korisnik.email = tbxEmail.Text;
                    korisnik.lozinka = tbxPassword.Text;
                    korisnik.pravaid_prava = korisnikPravo;
                    dbEntities.SaveChanges();

                    MessageBox.Show("Podaci o korisniku su uspješno ažurirani.");
                    this.Close();

                    //osvježavanje datagrida

                    List<User> users = new List<User>();
                    foreach (var item in dbEntities.korisnici)
                    {
                        string tipKorisnika = "";
                        if (item.pravaid_prava == 1)
                        {
                            tipKorisnika = "korisnik";
                        }
                        else
                        {
                            tipKorisnika = "administrator";
                        }

                        users.Add(new User { KorIme = item.kor_ime, Email = item.email, Lozinka = item.lozinka, TipKorisnika = tipKorisnika });
                    }

                    BindingSource bi = new BindingSource();
                    bi.DataSource = users;
                    dataGridView.DataSource = bi;
                    dataGridView.Columns[0].HeaderText = "Korisničko ime";
                    dataGridView.Columns[1].HeaderText = "Email adresa";
                    dataGridView.Columns[2].HeaderText = "Lozinka";
                    dataGridView.Columns[3].HeaderText = "Tip korisnika";

                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }



    }
}

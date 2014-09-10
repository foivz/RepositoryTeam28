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
    public partial class frmDodajKorisnika : Form
    {
        public frmDodajKorisnika()
        {
            InitializeComponent();
        }

        private BookerDBEntities dbEntities = new BookerDBEntities();

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            int korisnikPravo = 1;

            if (tbxUsername.Text.Equals("") || tbxEmail.Text.Equals("") || tbxLozinka.Text.Equals(""))
            {
                MessageBox.Show("Morate popuniti sva polja!");
            }
            else
            {
                if (!CheckUsernameFormat(tbxUsername.Text))
                {
                    MessageBox.Show("Korisničko ime mora sadržavati minimalno 5 znakova i od toga 3 slova.");
                }
                else
                {
                    if (!EmailIsValid(tbxEmail.Text))
                    {
                        MessageBox.Show("Email adresa je neispravnog formata!");
                    }
                    else
                    {
                        korisnici korIme = dbEntities.korisnici.Where(k => k.kor_ime.Equals(tbxUsername.Text)).SingleOrDefault();
                        if (korIme != null)
                        {
                            MessageBox.Show("Korisnik sa unesenim korisničkim imenom već postoji u bazi podataka!");
                        }
                        else
                        {
                            korisnici korEmail = dbEntities.korisnici.Where(k => k.email.Equals(tbxEmail.Text)).SingleOrDefault();
                            if (korEmail != null)
                            {
                                MessageBox.Show("Korisnik sa unesenom email adresom već postoji u bazi podataka!");
                            }
                            else
                            {
                                if (chbIsAdmin.Checked)
                                {
                                    korisnikPravo = 2;
                                }
                                korisnici korisnik = new korisnici { kor_ime = tbxUsername.Text, email = tbxEmail.Text, lozinka = tbxLozinka.Text, pravaid_prava = korisnikPravo };
                                dbEntities.korisnici.Add(korisnik);
                                dbEntities.SaveChanges();

                                MessageBox.Show("Korisnik je uspješno dodan u bazu podataka");

                                this.Close();

                            }

                        }
                    }
                }




            }

        }

        //metoda za provjeru formata email adrese
        public bool EmailIsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private bool CheckUsernameFormat(string username)
        {
            int brojSlova = Regex.Matches(username, @"[a-zA-Z]").Count;
            if (username.Length < 5)
            {
                return false;
            }
            else if (brojSlova < 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

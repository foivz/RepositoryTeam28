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

namespace Booker.Forme
{
    public partial class frmDodajPosudbu : Form
    {

        private BookerDBEntities dbEntities = new BookerDBEntities();
        private string username;

        public frmDodajPosudbu()
        {
            InitializeComponent();
        }

        public frmDodajPosudbu(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void frmDodajPosudbu_Load(object sender, EventArgs e)
        {
            BindCmbKnjige();
            BindCmbKorisnici();
        }

        private void BindCmbKnjige()
        {
            List<string> listaKnjiga = new List<string>();
            foreach (var item in dbEntities.knjiga)
            {
                if (item.kolicina > 0)
                {
                    listaKnjiga.Add(item.naslov);
                }

            }

            cmbKnjige.DataSource = listaKnjiga;
        }

        private void BindCmbKorisnici()
        {
            List<string> listaKorisnika = new List<string>();
            foreach (var item in dbEntities.korisnici)
            {
                if (item.pravaid_prava == 1)
                {
                    listaKorisnika.Add(item.kor_ime);
                }

            }
            cmbKorisnici.DataSource = listaKorisnika;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int brojDana = 0;
            if (cmbKnjige.Text.Equals("") || cmbKorisnici.Equals(""))
            {
                MessageBox.Show("Odaberiti knjigu i korisnika za koje želite dodati posudbi");
            }

            else
            {
                if (chb30.Checked == false && chb15.Checked == false)
                {
                    MessageBox.Show("Odaberite broj dana za posudbu");
                }
                else
                {
                    if (chb15.Checked)
                    {
                        brojDana = 15;
                    }
                    else if (chb30.Checked)
                    {
                        brojDana = 30;
                    }

                    DateTime datePosudba = DateTime.Now.Date;
                    DateTime datePovratak = datePosudba.AddDays(brojDana);

                    knjiga knjiga = dbEntities.knjiga.Where(k => k.naslov.Equals(cmbKnjige.Text)).SingleOrDefault();
                    knjiga.kolicina--;

                    int idKnjige = knjiga.id_knjiga;

                    korisnici korisnik = dbEntities.korisnici.Where(k => k.kor_ime.Equals(cmbKorisnici.Text)).SingleOrDefault();
                    int idKorisnik = korisnik.id_korisnici;

                    korisnici administrator = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
                    int idAdmin = administrator.id_korisnici;

                    posudba pos = dbEntities.posudba.Where(p => p.knjiga.naslov.Equals(cmbKnjige.Text) && p.korisnici1.kor_ime.Equals(cmbKorisnici.Text)).SingleOrDefault();

                    if (pos != null)
                    {
                        MessageBox.Show("Korisnik već ima tu knjigu.");
                    }
                    else
                    {
                        //korisniciid_korisnici označava admina koji je proveo posudbu knjige
                        //korisniciid_korisnici2 označava korisnika koji je posudio knjigu
                        dbEntities.posudba.Add(new posudba { datum_posudbe = datePosudba, datum_vracanja = datePovratak, knjigaid_knjiga = idKnjige, korisniciid_korisnici = idAdmin, korisniciid_korisnici2 = idKorisnik });

                        dbEntities.SaveChanges();

                        MessageBox.Show("Posudba je dodana.");
                        this.Close();
                    }



                }


            }
        }

        private void chb15_CheckedChanged(object sender, EventArgs e)
        {
            chb30.Checked = false;
        }

        private void chb30_CheckedChanged(object sender, EventArgs e)
        {
            chb15.Checked = false;
        }
    }
}

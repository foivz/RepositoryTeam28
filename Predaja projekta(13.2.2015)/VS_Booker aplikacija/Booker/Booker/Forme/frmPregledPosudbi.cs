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
    public partial class frmPregledPosudbi : Form
    {
        private BookerDBEntities dbEntities = new BookerDBEntities();
        private string username;
        private int vrstaKorisnika;

        public frmPregledPosudbi()
        {
            InitializeComponent();
        }

        public frmPregledPosudbi(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void frmPregledPosudbi_Load(object sender, EventArgs e)
        {

            korisnici kor = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
            if (kor.pravaid_prava.Equals(2))
            {
                button1.Visible = true;
                vrstaKorisnika = 1;
            }
            else
            {
                button1.Visible = false;
                vrstaKorisnika = 2;
            }

            BindGrid(vrstaKorisnika);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var collection = dataGridView1.SelectedRows;

            if (collection == null)
            {
                MessageBox.Show("Odaberite posudbu koju želite poništiti");
            }
            else
            {
                DataGridViewRow dgvr = null;
                foreach (var item in collection)
                {
                    dgvr = (DataGridViewRow)item;
                }

                string korisnik = dgvr.Cells[1].Value.ToString();
                string knjiga = dgvr.Cells[4].Value.ToString();

                knjiga knj = dbEntities.knjiga.Where(k => k.naslov.Equals(knjiga)).SingleOrDefault();
                knj.kolicina++;

                posudba pos = dbEntities.posudba.Where(p => p.knjiga.naslov.Equals(knjiga) && p.korisnici1.kor_ime.Equals(korisnik)).SingleOrDefault();
                dbEntities.posudba.Remove(pos);
                dbEntities.SaveChanges();

                MessageBox.Show("Sustav je zabilježio vraćanje knjige.");
                BindGrid(vrstaKorisnika);
            }
        }

        private void BindGrid(int vrsta)
        {
            List<DgdPosudba> listaPosudba = new List<DgdPosudba>();
            if (vrsta.Equals(1))
            {
                foreach (var item in dbEntities.posudba)
                {
                    if (txtTraziPosudba.Text.Equals(item.korisnici1.kor_ime, StringComparison.OrdinalIgnoreCase) || txtTraziPosudba.Text.Equals("", StringComparison.OrdinalIgnoreCase))
                    {
                        listaPosudba.Add(new DgdPosudba { Administrator = item.korisnici.kor_ime, Korisnik = item.korisnici1.kor_ime, DatumPosudbe = item.datum_posudbe, DatumVracanja = item.datum_vracanja, Knjiga = item.knjiga.naslov });

                    }
                }
            }
            else 
            {
                korisnici kor = dbEntities.korisnici.Where(k=>k.kor_ime.Equals(username)).SingleOrDefault();
                int idKorisnika = kor.id_korisnici;


                foreach (var item in dbEntities.posudba)
                {
                    if (item.korisniciid_korisnici2.Equals(idKorisnika))
                    {
                        if (txtTraziPosudba.Text.Equals(item.korisnici1.kor_ime, StringComparison.OrdinalIgnoreCase) || txtTraziPosudba.Text.Equals("", StringComparison.OrdinalIgnoreCase))
                        {
                            listaPosudba.Add(new DgdPosudba { Administrator = item.korisnici.kor_ime, Korisnik = item.korisnici1.kor_ime, DatumPosudbe = item.datum_posudbe, DatumVracanja = item.datum_vracanja, Knjiga = item.knjiga.naslov });

                        }
                    }
                }
            }
            

           

            BindingSource bi = new BindingSource();
            bi.DataSource = listaPosudba;
            dataGridView1.DataSource = bi;
            dataGridView1.Columns[0].HeaderText = "Administrator";
            dataGridView1.Columns[1].HeaderText = "Korisnik";
            dataGridView1.Columns[2].HeaderText = "Datum posudbe";
            dataGridView1.Columns[3].HeaderText = "Datum povratka";
            dataGridView1.Columns[4].HeaderText = "Knjiga";
        }

        private void btnTrazi2_Click(object sender, EventArgs e)
        {
            BindGrid(vrstaKorisnika);
        }

        
    }
}

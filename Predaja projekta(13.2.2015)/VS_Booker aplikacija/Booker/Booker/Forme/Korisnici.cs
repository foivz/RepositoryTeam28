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
    public partial class frmKorisnici : Form
    {
        public frmKorisnici()
        {
            InitializeComponent();
            BindGrid();
        }

        private BookerDBEntities dbEntities = new BookerDBEntities();

        private void button3_Click(object sender, EventArgs e)
        {
            frmDodajKorisnika dodajKorisnika = new frmDodajKorisnika();
            dodajKorisnika.ShowDialog();
            BindGrid();
        }

        private void BindGrid()
        {
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
            dataGridView1.DataSource = bi;
            dataGridView1.Columns[0].HeaderText = "Korisničko ime";
            dataGridView1.Columns[2].HeaderText = "Email adresa";
            dataGridView1.Columns[1].HeaderText = "Lozinka";
            dataGridView1.Columns[3].HeaderText = "Tip korisnika";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var collection = dataGridView1.SelectedRows;

            if (collection == null)
            {
                MessageBox.Show("Odaberite korisnika kojeg želite obrisati");
            }
            else
            {
                DataGridViewRow dgvr = null;
                foreach (var item in collection)
                {
                    dgvr = (DataGridViewRow)item;
                }

                string username = dgvr.Cells[0].Value.ToString();

                DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabranog korisnika?", "Potvrda brisanja korisnika", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    korisnici korisnik = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
                    dbEntities.korisnici.Remove(korisnik);
                    dbEntities.SaveChanges();

                    BindGrid();

                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var collection = dataGridView1.SelectedRows;

            if (collection == null)
            {
                MessageBox.Show("Odaberite korisnika kojeg želite obrisati");
            }
            else
            {
                DataGridViewRow dgvr = null;
                foreach (var item in collection)
                {
                    dgvr = (DataGridViewRow)item;
                }

                string username = dgvr.Cells[0].Value.ToString();

                frmAzurirajKorisnika frmAzurirajKorisnika = new frmAzurirajKorisnika(username, dataGridView1);
                frmAzurirajKorisnika.ShowDialog();
            }


        }

    }
}

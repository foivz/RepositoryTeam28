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
    public partial class frmUpravljanjeZanrovima : Form
    {
        private BookerDBEntities dbEntities = new BookerDBEntities();

        public frmUpravljanjeZanrovima()
        {
            InitializeComponent();
        }

        private void btnDodajZanr_Click(object sender, EventArgs e)
        {
            String nazivZanra = txtZanr.Text;
            if (nazivZanra.Equals(""))
            {
                MessageBox.Show("Molimo unesite naziv žanra.");
            }
            else
            {

                vrsta vrsta = dbEntities.vrsta.Where(v => v.naziv.Equals(nazivZanra)).SingleOrDefault();
                if (vrsta != null)
                {
                    MessageBox.Show("Uneseni žanr već postoji u bazi podataka.");
                }
                else {
                    dbEntities.vrsta.Add(new vrsta { naziv = nazivZanra });
                    dbEntities.SaveChanges();


                    txtZanr.Text = "";
                    MessageBox.Show("Žanr je uspješno dodan u bazu podataka");

                    List<string> listaZanrova = new List<string>();
                    foreach (var item in dbEntities.vrsta)
                    {
                        listaZanrova.Add(item.naziv);
                    }
                    cmb.DataSource = listaZanrova;

                }
            }
           
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {

            string zanr = cmb.Text;
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da želite obrisati odabrani žanr", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dbEntities.vrsta.Remove(dbEntities.vrsta.Where(b => b.naziv.Equals(zanr)).SingleOrDefault());
                dbEntities.SaveChanges();

                List<string> listaZanrova = new List<string>();
                foreach (var item in dbEntities.vrsta)
                {
                    listaZanrova.Add(item.naziv);
                }

                cmb.DataSource = listaZanrova;


            }
        }

        private void frmDodajZanr_Load(object sender, EventArgs e)
        {
            List<string> listaZanrova = new List<string>();
            foreach (var item in dbEntities.vrsta)
            {
                listaZanrova.Add(item.naziv);
            }
            cmb.DataSource = listaZanrova;
        }

   
    }
}

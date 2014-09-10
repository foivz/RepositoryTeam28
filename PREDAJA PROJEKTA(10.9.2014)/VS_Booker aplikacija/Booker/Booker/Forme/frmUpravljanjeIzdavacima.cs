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
    public partial class frmUpravljanjeIzdavacima : Form
    {
        private BookerDBEntities dbEntities = new BookerDBEntities();

        public frmUpravljanjeIzdavacima()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Unesite ime izdavača");
            }
            else
            {

                izdavac izd = dbEntities.izdavac.Where(i=>i.naziv.Equals(textBox1.Text)).SingleOrDefault();
                if (izd != null)
                {
                    MessageBox.Show("Izdavač s tim imenom već postoji u bazi podataka");
                }
                else
                {
                    dbEntities.izdavac.Add(new izdavac { naziv = textBox1.Text });
                    dbEntities.SaveChanges();

                    MessageBox.Show("Izdavač je uspješno unesen u bazu podataka");

                    textBox1.Text = "";

                    List<CmbItemAutor> listaIzdavaca = new List<CmbItemAutor>();
                    foreach (var item in dbEntities.izdavac)
                    {
                        listaIzdavaca.Add(new CmbItemAutor { Naziv = item.naziv, Value = item.id_izdavac });
                    }

                    cmb.DataSource = listaIzdavaca;
                    cmb.ValueMember = "Value";
                    cmb.DisplayMember = "Naziv";
                }


               


            }
        }

        private void frmUpravljanjeIzdavacima_Load(object sender, EventArgs e)
        {
            List<CmbItemAutor> listaIzdavaca = new List<CmbItemAutor>();
            foreach (var item in dbEntities.izdavac)
            {
                listaIzdavaca.Add(new CmbItemAutor { Naziv = item.naziv, Value = item.id_izdavac });
            }

            cmb.DataSource = listaIzdavaca;
            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Naziv";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idIzdavaca = (int)cmb.SelectedValue;

            dbEntities.izdavac.Remove(dbEntities.izdavac.Where(b => b.id_izdavac.Equals(idIzdavaca)).SingleOrDefault());
            dbEntities.SaveChanges();

            MessageBox.Show("Izdavač je uspješno obrisan");


            List<CmbItemAutor> listaIzdavaca = new List<CmbItemAutor>();
            foreach (var item in dbEntities.izdavac)
            {
                listaIzdavaca.Add(new CmbItemAutor { Naziv = item.naziv, Value = item.id_izdavac });
            }

            cmb.DataSource = listaIzdavaca;
            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Naziv";

        }
    }
}

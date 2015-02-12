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
using System.Text.RegularExpressions;

namespace Booker.Forme
{
    public partial class frmUpravljanjeAutorima : Form
    {
        private BookerDBEntities dbEntities = new BookerDBEntities();
        public int SelectedValue;
        public frmUpravljanjeAutorima()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Unesite ime i prezime autora kojeg želite dodati");
            }
            else
            {
                bool imeIspravno = Regex.IsMatch(textBox1.Text, @"^[a-zA-ZščćžđŠČĆŽĐ]+$");
                bool prezimeIspravno = Regex.IsMatch(textBox2.Text, @"^[a-zA-ZščćžđŠĆČŽĐ]+$");

                if (imeIspravno == false || prezimeIspravno == false)
                {
                    MessageBox.Show("Pogrešan unos. Molimo koristite samo slova.");
                }
                else
                {

                    autor autor = dbEntities.autor.Where(a => a.ime.Equals(textBox1.Text) && a.prezime.Equals(textBox2.Text)).SingleOrDefault();
                    if (autor != null)
                    {
                        MessageBox.Show("Autor sa navedenim podacima već postoji u bazi podataka");
                    }
                    else
                    {
                        dbEntities.autor.Add(new autor { ime = textBox1.Text, prezime = textBox2.Text });
                        dbEntities.SaveChanges();

                        MessageBox.Show("Autor je uspješno dodan u bazu podataka");

                        textBox1.Text = "";
                        textBox2.Text = "";

                        List<CmbItemAutor> listaAutora = new List<CmbItemAutor>();
                        foreach (var item in dbEntities.autor)
                        {
                            string naziv = item.ime + " " + item.prezime;
                            listaAutora.Add(new CmbItemAutor { Naziv = naziv, Value = item.id_autor });
                        }

                        cmb.DataSource = listaAutora;
                        cmb.ValueMember = "Value";
                        cmb.DisplayMember = "Naziv";
                    }
                }



            
            }
           
        }

        private void frmUpravljanjeAutorima_Load(object sender, EventArgs e)
        {
            List<CmbItemAutor> listaAutora = new List<CmbItemAutor>();
            foreach (var item in dbEntities.autor)
            {
                string naziv = item.ime + " " + item.prezime;
                listaAutora.Add(new CmbItemAutor { Naziv = naziv, Value = item.id_autor });
            }

            cmb.DataSource = listaAutora;
            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Naziv";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idAutora = (int)cmb.SelectedValue;
           
            dbEntities.autor.Remove(dbEntities.autor.Where(b => b.id_autor.Equals(idAutora)).SingleOrDefault());
            dbEntities.SaveChanges();

            MessageBox.Show("Autor je uspješno obrisan");


            List<CmbItemAutor> listaAutora = new List<CmbItemAutor>();
            foreach (var item in dbEntities.autor)
            {
                string naziv = item.ime + " " + item.prezime;
                listaAutora.Add(new CmbItemAutor { Naziv = naziv, Value = item.id_autor });
            }

            cmb.DataSource = listaAutora;
            cmb.ValueMember = "Value";
            cmb.DisplayMember = "Naziv";
         
        }
    }
}

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
    public partial class frmKnjige : Form
    {

        private BookerDBEntities dbEntities = new BookerDBEntities();
        private string username = "";


        public frmKnjige()
        {
            InitializeComponent();
        }

        public frmKnjige(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void frmKnjige_Load(object sender, EventArgs e)
        {
            dgdKnjige.AllowUserToAddRows = false;
            dgdKnjige.AllowUserToAddRows = false;
            BindGridListaKnjiga();
        }


        private void BindGridListaKnjiga()
        {
            
            List<CmbItemPopisKnjiga> listaKnjiga = new List<CmbItemPopisKnjiga>();
            
            string vrstak="";
            string autor = "";
            string dostupno = "";
            int brojac=0;
            
            foreach (var item in dbEntities.knjiga)
            {   
                //Autor
                foreach (var itemAK in dbEntities.autori_knjiga)
                {
                    if (item.id_knjiga == itemAK.knjigaid_knjiga)
                    {
                        foreach (var itemA in dbEntities.autor)
                        {
                            if (itemAK.autorid_autor == itemA.id_autor)
                            {
                                autor += itemA.ime;
                                autor += " " + itemA.prezime+" ";
                            }
                        }
                    }
                }
                //Vrsta
                foreach (var itemKV in dbEntities.knjiga_vrsta)
                {
                    if (itemKV.knjigaid_knjiga == item.id_knjiga)
                    {
                        foreach (var itemV in dbEntities.vrsta)
                        {
                            if (itemKV.vrstaid_vrsta == itemV.id_vrsta)
                            {
                                vrstak+=itemV.naziv+" ";
                            }
                        }
                    }
                }
                //Dostupnost
                foreach (var itemP in dbEntities.posudba)
                {
                    if (itemP.knjigaid_knjiga == item.id_knjiga)
                    {
                        brojac++;
                    }
                }

                if (item.kolicina > brojac)
                {
                    dostupno = "Da";
                }
                else
                {
                    dostupno = "Ne";
                }

                listaKnjiga.Add(new CmbItemPopisKnjiga { Id=item.id_knjiga.ToString(), Naslov=item.naslov, ISBN=item.isbn, Autor=autor, Opis=item.tema, Vrsta=vrstak, Godina_izdanja=item.godina_izdanja, Dostupna=dostupno });
                vrstak = "";
                autor = "";
                brojac = 0;
                
            }
            
            BindingSource bi = new BindingSource();
            bi.DataSource = listaKnjiga;
            dgdKnjige.DataSource = bi;
            
            dgdKnjige.Columns[2].Visible = false;

        }

        private void BindGridListaKomentara(int idKnjige)
        {
            List<DgdKomentar> listaKomentara = new List<DgdKomentar>();

            foreach (var item in dbEntities.komentari.Where(k => k.knjigaid_knjiga.Equals(idKnjige)))
            {
                listaKomentara.Add(new DgdKomentar { Korisnik = item.korisnici.kor_ime, Komentar = item.komentar });
            }


            BindingSource bi = new BindingSource();
            bi.DataSource = listaKomentara;
            dgdKomentari.DataSource = bi;
            dgdKomentari.Columns[0].HeaderText = "Korisnik";
            dgdKomentari.Columns[1].HeaderText = "Komentar";

            dgdKomentari.Columns[1].Width = 410;
        }


        private void btnKomentiraj_Click(object sender, EventArgs e)
        {
            if (tbxKomentar.Text.Equals(""))
            {
                MessageBox.Show("Molimo unesite komentar na knjigu.");
            }
            else
            {
                var collection = dgdKnjige.SelectedRows;

                if (collection == null)
                {
                    MessageBox.Show("Odaberite knjigu koju želite komentirati");
                }
                else
                {
                    DataGridViewRow dgvr = null;
                    foreach (var item in collection)
                    {
                        dgvr = (DataGridViewRow)item;
                    }

                    string isbn = dgvr.Cells[2].Value.ToString();

                    knjiga knj = dbEntities.knjiga.Where(k => k.isbn.Equals(isbn)).SingleOrDefault();
                    int idKnjige = knj.id_knjiga;

                    korisnici kor = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
                    int idKorisnika = kor.id_korisnici;

                    dbEntities.komentari.Add(new komentari { knjigaid_knjiga = idKnjige, korisniciid_korisnici = idKorisnika, komentar = tbxKomentar.Text });
                    dbEntities.SaveChanges();

                    BindGridListaKomentara(idKnjige);

                }
            }
        }

        private void dgdKnjige_SelectionChanged(object sender, EventArgs e)
        {
            var collection = dgdKnjige.SelectedRows;

            if (collection != null)
            {

                int idKnjige;
                DataGridViewRow dgvr = null;
                foreach (var item in collection)
                {
                    dgvr = (DataGridViewRow)item;
                }

                if (dgvr == null)
                {
                    dgvr = dgdKnjige.Rows[0];
                   
                }

                string isbn = dgvr.Cells[2].Value.ToString();

                knjiga knj = dbEntities.knjiga.Where(k => k.isbn.Equals(isbn)).SingleOrDefault();
                idKnjige = knj.id_knjiga;


                BindGridListaKomentara(idKnjige);

            }

        }

        private void btnTrazi_Click(object sender, EventArgs e)
        {
            List<CmbItemPopisKnjiga> listaKnjiga = new List<CmbItemPopisKnjiga>();

            string vrstak = "";
            string autor = "";
            string dostupno = "";
            int brojac = 0;

            foreach (var item in dbEntities.knjiga)
            {
                //Autor
                foreach (var itemAK in dbEntities.autori_knjiga)
                {
                    if (item.id_knjiga == itemAK.knjigaid_knjiga)
                    {
                        foreach (var itemA in dbEntities.autor)
                        {
                            if (itemAK.autorid_autor == itemA.id_autor)
                            {
                                autor += itemA.ime;
                                autor += " " + itemA.prezime + " ";
                            }
                        }
                    }
                }
                //Vrsta
                foreach (var itemKV in dbEntities.knjiga_vrsta)
                {
                    if (itemKV.knjigaid_knjiga == item.id_knjiga)
                    {
                        foreach (var itemV in dbEntities.vrsta)
                        {
                            if (itemKV.vrstaid_vrsta == itemV.id_vrsta)
                            {
                                vrstak += itemV.naziv + " ";
                            }
                        }
                    }
                }
                //Dostupnost
                foreach (var itemP in dbEntities.posudba)
                {
                    if (itemP.knjigaid_knjiga == item.id_knjiga)
                    {
                        brojac++;
                    }
                }

                if (item.kolicina > brojac)
                {
                    dostupno = "Da";
                }
                else
                {
                    dostupno = "Ne";
                }
                string traziAutor = txtTrazi.Text + " ";
                string traziVrstu = txtTrazi.Text + " ";
                if (txtTrazi.Text.Equals(item.naslov, StringComparison.OrdinalIgnoreCase) || txtTrazi.Text.Equals(item.id_knjiga.ToString(), StringComparison.OrdinalIgnoreCase) || traziAutor.Equals(autor, StringComparison.OrdinalIgnoreCase) || traziVrstu.Equals(vrstak, StringComparison.OrdinalIgnoreCase) || txtTrazi.Text.Equals(item.godina_izdanja, StringComparison.OrdinalIgnoreCase) || txtTrazi.Text == "")
                {

                    listaKnjiga.Add(new CmbItemPopisKnjiga { Id = item.id_knjiga.ToString(), Naslov = item.naslov, ISBN = item.isbn, Autor = autor, Opis = item.tema, Vrsta = vrstak, Godina_izdanja = item.godina_izdanja, Dostupna = dostupno });

                }
                vrstak = "";
                autor = "";
                brojac = 0;

            }

            BindingSource bi = new BindingSource();
            bi.DataSource = listaKnjiga;
            dgdKnjige.DataSource = bi;

            dgdKnjige.Columns[2].Visible = false;
        }


    }
}

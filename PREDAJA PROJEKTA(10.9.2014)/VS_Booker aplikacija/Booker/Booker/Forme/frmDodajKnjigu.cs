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
    public partial class frmDodajKnjigu : Form
    {
        private BookerDBEntities dbEntities = new BookerDBEntities();
        private int brojacCmbZanrovi = 1;
        private int brojacCmbAutori = 1;
        private int brojAutoraUbazi;
        private int brojZanrovaUbazi;

        private string username = "";
        

        public frmDodajKnjigu()
        {
            InitializeComponent();
            
        }

        public frmDodajKnjigu(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void frmDodajKnjigu_Load(object sender, EventArgs e)
        {
            //broj autora u bazi
            brojAutoraUbazi = dbEntities.autor.Count();
            //broj žanrova u bazi
            brojZanrovaUbazi = dbEntities.vrsta.Count();

            frmDodajKnjigu frmDodajKnjigu = new frmDodajKnjigu();


            List<string> listaZanrova = new List<string>();
            foreach (var item in dbEntities.vrsta)
            {
                listaZanrova.Add(item.naziv);
            }

            cmbZanr1.DataSource = listaZanrova;
            cmbZanr2.DataSource = listaZanrova.ToList();
            cmbZanr3.DataSource = listaZanrova.ToList();
            cmbZanr4.DataSource = listaZanrova.ToList();
            cmbZanr5.DataSource = listaZanrova.ToList();


            List<CmbItemAutor> listaAutora = new List<CmbItemAutor>();
            foreach (var item in dbEntities.autor)
            {
                string naziv = item.ime + " " + item.prezime;
                listaAutora.Add(new CmbItemAutor { Naziv = naziv, Value = item.id_autor });
            }

            cmbAutor1.DataSource = listaAutora;
            cmbAutor1.ValueMember = "Value";
            cmbAutor1.DisplayMember = "Naziv";

            cmbAutor2.DataSource = listaAutora.ToList();
            cmbAutor2.ValueMember = "Value";
            cmbAutor2.DisplayMember = "Naziv";

            cmbAutor3.DataSource = listaAutora.ToList();
            cmbAutor3.ValueMember = "Value";
            cmbAutor3.DisplayMember = "Naziv";

            cmbAutor4.DataSource = listaAutora.ToList();
            cmbAutor4.ValueMember = "Value";
            cmbAutor4.DisplayMember = "Naziv";

            cmbAutor5.DataSource = listaAutora.ToList();
            cmbAutor5.ValueMember = "Value";
            cmbAutor5.DisplayMember = "Naziv";


            //bind na combo box za izdavača
            List<string> listaIzdavaca = new List<string>();
            foreach (var item in dbEntities.izdavac)
            {
                listaIzdavaca.Add(item.naziv);
            }

            cmbIzdavac.DataSource = listaIzdavaca;

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            string isbn = tbxISBN.Text;
            string naslov = tbxNaslov.Text;
            string godina = tbxGodina.Text;
            string izdanje = tbxIzdanje.Text;
            string kolicina = tbxKolicina.Text;
            string tema = tbxTema.Text;

            string zanr = cmbZanr1.Text;
            string izdavac = cmbIzdavac.Text;
            string autor = cmbAutor1.Text;


            //provjera jesu lis va polja popunjena
            if (isbn.Equals("") || naslov.Equals("") || godina.Equals("") || izdanje.Equals("") || kolicina.Equals("") || tema.Equals("") || zanr.Equals("") || izdavac.Equals("") || autor.Equals(""))
            {
                MessageBox.Show("Sva polja moraju biti popunjena");
            }
            else
            {
                Match validISBN = Regex.Match(isbn, @"^(97(8|9))?\d{9}(\d|X)$");
                if (!validISBN.Success)
                {
                    MessageBox.Show("Uneseni ISBN nije ispravnog formata");
                }
                else
                {
                    knjiga knj = dbEntities.knjiga.Where(k => k.isbn.Equals(isbn)).SingleOrDefault();

                    if (knj != null)
                    {
                        MessageBox.Show("Knjiga s unesenim ISBN brojem već postoji u bazi podataka.");
                    }
                    else
                    {
                        Match validYear = Regex.Match(godina, @"^\d{4}$");
                        if (!validYear.Success)
                        {
                            MessageBox.Show("Unesena godina nije ispravnog formata");
                        }
                        else
                        {
                            if (!CheckIfNumber(izdanje) || !CheckIfNumber(kolicina))
                            {
                                MessageBox.Show("Uneseno izdanje i/ili kolicina nisu ispravnog formata");
                            }
                            else
                            {

                                knjiga book = dbEntities.knjiga.Where(k=>k.naslov.Equals(naslov)).SingleOrDefault();

                                if (book != null)
                                {
                                    MessageBox.Show("Knjiga s unesenim naslovom već postoji u bazi podataka");
                                }
                                else
                                {
                                    //svi combo boxevi od autora -> odabrane vrijednosti se stavljaju u listu
                                    List<string> pomListaCmbAutori = new List<string>();
                                    foreach (Control C in this.Controls.OfType<ComboBox>())
                                    {
                                        if (C.Visible && C.Name.Contains("cmbAutor"))
                                        {
                                            pomListaCmbAutori.Add(C.Text);
                                        }
                                    }

                                    //svi combo boxevi od zanrova -> odabrane vrijednosti se stavljaju u listu
                                    List<string> pomListaCmbZanrovi = new List<string>();
                                    foreach (Control C in this.Controls.OfType<ComboBox>())
                                    {
                                        if (C.Visible && C.Name.Contains("cmbZanr"))
                                        {
                                            pomListaCmbZanrovi.Add(C.Text);
                                        }

                                    }


                                    //provjerava se jesu li vrijednosti odabrane u combo boxecima za zanr i autore različite
                                    bool cmbZanroviDuplicate = CheckListForDuplicate(pomListaCmbZanrovi);
                                    bool cmbAutoriDuplicate = CheckListForDuplicate(pomListaCmbAutori);

                                    if (cmbZanroviDuplicate)
                                    {
                                        MessageBox.Show("Unesite različite žanrove");
                                    }
                                    else if (cmbAutoriDuplicate)
                                    {
                                        MessageBox.Show("Unesite različite autore");
                                    }
                                    else
                                    {
                                        izdavac izd = dbEntities.izdavac.Where(i => i.naziv.Equals(izdavac)).SingleOrDefault();
                                        int idIzdavac = izd.id_izdavac;

                                        korisnici kor = dbEntities.korisnici.Where(k => k.kor_ime.Equals(username)).SingleOrDefault();
                                        int idAdministratora = kor.id_korisnici;

                                        knjiga knji = new knjiga { isbn = isbn, naslov = naslov, godina_izdanja = godina, tema = tema, izdanje = Convert.ToInt32(izdanje), kolicina = Convert.ToInt32(kolicina), izdavacid_izdavac = idIzdavac, korisniciid_korisnici = idAdministratora };

                                        dbEntities.knjiga.Add(knji);
                                        dbEntities.SaveChanges();

                                        int idKnjiga = knji.id_knjiga;

                                        foreach (var item in pomListaCmbAutori)
                                        {
                                            string[] polje = item.Split(' ');
                                            string imeAutora = polje[0];
                                            string prezimeAutora = polje[1];

                                            autor aut = dbEntities.autor.Where(v => v.ime.Equals(imeAutora) && v.prezime.Equals(prezimeAutora)).SingleOrDefault();
                                            int idAutor = aut.id_autor;

                                            DateTime date = DateTime.Now;

                                            dbEntities.autori_knjiga.Add(new autori_knjiga { autorid_autor = idAutor, knjigaid_knjiga = idKnjiga, datum_upisa = date });
                                            dbEntities.SaveChanges();

                                        }

                                        foreach (var item in pomListaCmbZanrovi)
                                        {
                                            vrsta vst = dbEntities.vrsta.Where(v => v.naziv.Equals(item)).SingleOrDefault();
                                            int idVrsta = vst.id_vrsta;

                                            dbEntities.knjiga_vrsta.Add(new knjiga_vrsta { vrstaid_vrsta = idVrsta, knjigaid_knjiga = idKnjiga });
                                            dbEntities.SaveChanges();
                                        }

                                        MessageBox.Show("Knjiga je uspješno dodana u bazu podataka");
                                        //this.Close();


                                    }
                                }
                            }
                        }








                    }




                }
            }

        }

        private bool CheckIfNumber(string value)
        {
            try
            {
                int myInt = Int32.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }



        private void removeZanr_Click(object sender, EventArgs e)
        {
            if (brojacCmbZanrovi != 1)
            {

                if (brojacCmbZanrovi == 2)
                {
                    cmbZanr2.Visible = false;
                    cmbZanr3.Visible = false;
                    cmbZanr4.Visible = false;
                    cmbZanr5.Visible = false;
                }
                else if (brojacCmbZanrovi == 3)
                {
                    cmbZanr3.Visible = false;
                    cmbZanr4.Visible = false;
                    cmbZanr5.Visible = false;
                }
                else if (brojacCmbZanrovi == 4)
                {
                    cmbZanr4.Visible = false;
                    cmbZanr5.Visible = false;
                }
                else if (brojacCmbZanrovi == 5)
                {
                    cmbZanr5.Visible = false;
                }
                brojacCmbZanrovi--;
            }
        }


        private void addZanr_Click(object sender, EventArgs e)
        {
            if (brojZanrovaUbazi < 5)
            {
                if (brojacCmbZanrovi < brojZanrovaUbazi)
                {
                    brojacCmbZanrovi++;
                    if (brojacCmbZanrovi == 2)
                    {
                        cmbZanr2.Visible = true;
                    }
                    else if (brojacCmbZanrovi == 3)
                    {
                        cmbZanr3.Visible = true;
                    }
                    else if (brojacCmbZanrovi == 4)
                    {
                        cmbZanr4.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Nema više žanrova u bazi");
                }
            }
            else
            {
                if (brojacCmbZanrovi == 5)
                {
                    MessageBox.Show("Maksimalan broj žanrova može biti 5");
                }
                else
                {
                    brojacCmbZanrovi++;
                    if (brojacCmbZanrovi == 2)
                    {
                        cmbZanr2.Visible = true;
                    }
                    else if (brojacCmbZanrovi == 3)
                    {
                        cmbZanr3.Visible = true;
                    }
                    else if (brojacCmbZanrovi == 4)
                    {
                        cmbZanr4.Visible = true;
                    }
                    else if (brojacCmbZanrovi == 5)
                    {
                        cmbZanr5.Visible = true;
                    }
                }
            }
        }

        private void addAutor_Click(object sender, EventArgs e)
        {
            if (brojAutoraUbazi < 5)
            {
                if (brojacCmbAutori < brojAutoraUbazi)
                {
                    brojacCmbAutori++;
                    if (brojacCmbAutori == 2)
                    {
                        cmbAutor2.Visible = true;
                    }
                    else if (brojacCmbAutori == 3)
                    {
                        cmbAutor3.Visible = true;
                    }
                    else if (brojacCmbAutori == 4)
                    {
                        cmbAutor4.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Nema više žanrova u bazi");
                }
            }
            else
            {
                if (brojacCmbAutori == 5)
                {
                    MessageBox.Show("Maksimalan broj autora može biti 5");
                }
                else
                {
                    brojacCmbAutori++;
                    if (brojacCmbAutori == 2)
                    {
                        cmbAutor2.Visible = true;
                    }
                    else if (brojacCmbAutori == 3)
                    {
                        cmbAutor3.Visible = true;
                    }
                    else if (brojacCmbAutori == 4)
                    {
                        cmbAutor4.Visible = true;
                    }
                    else if (brojacCmbAutori == 5)
                    {
                        cmbAutor5.Visible = true;
                    }
                }
            }
        }

        private void removeAutor_Click(object sender, EventArgs e)
        {
            if (brojacCmbAutori != 1)
            {

                if (brojacCmbAutori == 2)
                {
                    cmbAutor2.Visible = false;
                    cmbAutor3.Visible = false;
                    cmbAutor4.Visible = false;
                    cmbAutor5.Visible = false;
                }
                else if (brojacCmbAutori == 3)
                {
                    cmbAutor3.Visible = false;
                    cmbAutor4.Visible = false;
                    cmbAutor5.Visible = false;
                }
                else if (brojacCmbAutori == 4)
                {
                    cmbAutor4.Visible = false;
                    cmbAutor5.Visible = false;
                }
                else if (brojacCmbAutori == 5)
                {
                    cmbAutor5.Visible = false;
                }
                brojacCmbAutori--;
            }
        }


        //metoda koja provjerava nalazi li se u listi 2 ista stringa
        private bool CheckListForDuplicate(List<string> lista)
        {
            return lista.GroupBy(n => n).Any(c => c.Count() > 1); ;
        }

       
    }
}

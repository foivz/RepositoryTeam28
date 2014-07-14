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
using System.Net;

namespace Booker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private BookerDBEntities dbEntities = new BookerDBEntities();
        private List<knjiga> listaKnjigaKojimaSeBliziRok = new List<knjiga>();
        private List<knjiga> listaKnjigaKojimaJeRokIstekao = new List<knjiga>();

        /// <summary>
        /// Metoda za provjeru logina. Ako je uspješan login, korisnika se redirecta na glavnu formu!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == string.Empty || txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Pogriješili ste prilikom logiranja, molimo pokušajte ponovo!");
            }
            else
            {
                string inputIme = txtUsername.Text;
                string inputLozinika = txtPassword.Text;


                string korIme;
                int tip;

                korisnici kor = null;


                kor = dbEntities.korisnici.Where(k => k.kor_ime.Equals(inputIme) && k.lozinka.Equals(inputLozinika)).SingleOrDefault();

                if (kor != null)
                {
                    korIme = inputIme;
                    tip = kor.pravaid_prava;

                    Forme.frmGlavna glavna = new Forme.frmGlavna(korIme, tip);
                    this.Hide();

                    bool provjera = ProvjeriPosudbu(korIme);
                    if (provjera == true)
                    {

                        if (listaKnjigaKojimaJeRokIstekao != null)
                        {
                            PosaljiEmail(kor, listaKnjigaKojimaJeRokIstekao, 2);
                        }
                        else if (listaKnjigaKojimaSeBliziRok != null)
                        {
                            PosaljiEmail(kor, listaKnjigaKojimaSeBliziRok, 1);
                        }
                    }

                    glavna.ShowDialog();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Pogriješili ste prilikom logiranja, molimo pokušajte ponovo!");
                }

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }


        //vraća "1" ukoliko nije potrebna nikakva obavijest
        //vraća "2" ukoliko se rok bliži kraju
        //vraća "3" ukoliko je rok istekao
        private bool ProvjeriPosudbu(string username)
        {
            var SvePosudbeZaKorisnika = dbEntities.posudba.Where(p => p.korisnici1.kor_ime.Equals(username));
            if (SvePosudbeZaKorisnika == null)
            {
                return false;
            }
            else
            {

                const double rokZaObavijest = 259200000.0;//3 dana izražena u milisekundama
                DateTime trenutniDatum = DateTime.Now.Date;
                foreach (var item in SvePosudbeZaKorisnika)
                {

                    TimeSpan preostaloVrijeme = trenutniDatum.Subtract(item.datum_vracanja);

                    double preostaloVrijemeMillisec = preostaloVrijeme.TotalMilliseconds;
                    bool positiveValue = preostaloVrijemeMillisec > 0;

                    if (positiveValue == false)
                    {
                        listaKnjigaKojimaJeRokIstekao.Add(item.knjiga);

                    }
                    else if (preostaloVrijemeMillisec <= rokZaObavijest)
                    {
                        listaKnjigaKojimaSeBliziRok.Add(item.knjiga);

                    }
                }
            }

            if (listaKnjigaKojimaJeRokIstekao != null || listaKnjigaKojimaSeBliziRok != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        //vrstaObavijesti == 1 -> šalje se mail da se rok bliži kraju
        //vrstaObavijesti == 2 -> šalje se mail da je rok istekao
        private void PosaljiEmail(korisnici korisnik, List<knjiga> listaKnjiga, int vrstaObavijesti) {
            string msgSubject = "Knjižnica - obavijest za knjige";
            string msgBody = "";
            string popisKnjiga = "";
            foreach (var item in listaKnjiga)
	        {
                var posudba = dbEntities.posudba.Where(p=>p.knjiga.naslov.Equals(item.naslov) && p.korisnici1.kor_ime.Equals(korisnik.kor_ime)).SingleOrDefault();


		        popisKnjiga += "Naslov knjige: " + item.naslov + "  Datum vraćanja: " + posudba.datum_vracanja + "\n";
	        }

            if (vrstaObavijesti == 1)
            {
                msgBody = " Poštovani korisnik/-ica " + korisnik.kor_ime + " Rok za knjgu/e koje ste posudili kod nas u knjižnici će uskoro isteći i molimo Vas da to imate na umu\n" +
                          " Niže možete pročitati za koje knjige Vam se bliži rok i kada ih morate vratiti\n"+
                             popisKnjiga + " .\n" + "Lijep pozdrav, \n knjiznica@gmail.com" ;
            }

            else if (vrstaObavijesti == 2)
            {
                msgBody = " Poštovani korisnik/-ica " + korisnik.kor_ime + "Rok za knjgu/e koje ste posudili kod nas u knjižnici je istekao." +
                         " Niže možete pročitati za koje knjige Vam je rok istekao te kada je bio krajnji rok za vraćenje pojedine knjige\n" +
                            popisKnjiga + " .\n" + " Molimo Vas da navedene knjige vratite u najkraćem mogućem roku ili ćemo protiv Vas morati"+
                            "postupiti po našem pravilniku.  " + "\n Lijep pozdrav, \n knjiznica@gmail.com";
            }
            
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                  "bookeraplikacija@gmail.com", "aplikacijapi");
                MailMessage msg = new MailMessage();
                msg.To.Add(korisnik.email);
                msg.From = new MailAddress("knjiznica@gmail.com");
                msg.Subject = msgSubject;
                msg.Body = msgBody;
                client.Send(msg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    
        
        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

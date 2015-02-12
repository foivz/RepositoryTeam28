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




                korisnici kor = dbEntities.korisnici.Where(k => k.kor_ime.Equals(inputIme) && k.lozinka.Equals(inputLozinika)).SingleOrDefault();


                if (kor != null)
                {
                    korIme = inputIme;
                    tip = kor.pravaid_prava;

                    Forme.frmGlavna glavna = new Forme.frmGlavna(korIme, tip);
                    this.Hide();



                    foreach (var item in dbEntities.korisnici.Where(x => x.pravaid_prava == 1))  
                    {
                        bool provjera = ProvjeriPosudbu(item.id_korisnici); 
                        if (provjera == true)                               
                        {                                                  
                                                                         


                            if (listaKnjigaKojimaJeRokIstekao.Count != 0) 
                            {                                              
                                PosaljiEmail(item, listaKnjigaKojimaJeRokIstekao, 2); 
                               



                            }
                            if (listaKnjigaKojimaSeBliziRok.Count != 0) 
                            {
                                PosaljiEmail(item, listaKnjigaKojimaSeBliziRok, 1);
                                
                            }
                        }

                        listaKnjigaKojimaJeRokIstekao = new List<knjiga>();  
                        listaKnjigaKojimaSeBliziRok = new List<knjiga>(); 
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
        private bool ProvjeriPosudbu(int ID) 
        {
          
            // tu je bila promjena (username)


            var SvePosudbeZaKorisnika = dbEntities.posudba.Where(p => p.korisniciid_korisnici2 == ID);
           

            if (SvePosudbeZaKorisnika == null) 
            {
                return false;
            }
            else
            {

                const double rokZaObavijest = 259200000.0;
                DateTime trenutniDatum = DateTime.Now.Date; 


               




                foreach (var item in SvePosudbeZaKorisnika) // ulazimo u listu gdje svaki item(korisnika) provjeravamo
                {

                    DateTime danVracanjaPrijeIsteka3Dana = item.datum_vracanja.AddDays(-3);
                    


                    TimeSpan preostaloVrijeme = trenutniDatum.Subtract(item.datum_vracanja); 

                    double preostaloVrijemeMillisec = preostaloVrijeme.TotalMilliseconds; 
                    bool positiveValue = preostaloVrijemeMillisec > 0; 
                                                                       
                                                                   
                                                                  
                   

                    if (positiveValue == true) 
                    {
                        listaKnjigaKojimaJeRokIstekao.Add(item.knjiga);

                    }
                    else if (trenutniDatum > danVracanjaPrijeIsteka3Dana && trenutniDatum < item.datum_vracanja )
                     


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

       
        private void PosaljiEmail(korisnici korisnik, List<knjiga> listaKnjiga, int vrstaObavijesti) {
            string msgSubject = "Knjižnica - obavijest za knjige";
            string msgBody = "";
            string popisKnjiga = "";
            foreach (var item in listaKnjiga)
	        {
                knjiga book = dbEntities.knjiga.Where(x => x.naslov.Equals(item.naslov)).FirstOrDefault();
                var posudba = dbEntities.posudba.Where(p=>p.knjigaid_knjiga == book.id_knjiga && p.korisniciid_korisnici2 == korisnik.id_korisnici ).SingleOrDefault();


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
                SmtpClient client = new SmtpClient("smtp.live.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(
                  "vu.ky@hotmail.com", "valerija");
                MailMessage msg = new MailMessage();
                msg.To.Add(korisnik.email);
                msg.From = new MailAddress("knjiznica@gmail.com");
                msg.Subject = msgSubject;
                msg.Body = msgBody;
                client.Send(msg);

                client.Dispose();
                msg.Dispose();
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

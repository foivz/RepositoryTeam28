using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booker.Forme
{
    public partial class frmDodajKorisnika : Form
    {
        public frmDodajKorisnika()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uspješno dodan korisnik!");
            this.Close();
        }
    }
}

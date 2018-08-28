using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



// fil for å registrere bruker til admin tabellen i databasen
namespace eksamen2018wf
{
    public partial class registrerbruker : Form
    {

       
        public registrerbruker()
        {
            InitializeComponent();
        }


        // kanppen man trykker på for å registrere
        private void btnregistrerbruker_Click(object sender, EventArgs e)
        {
            database db = new database();
            // for å sammenligne brukernavnet i txtbrukernavn med brukernavnet i databasen
            int i = db.antallRader("Select * from admin WHERE brukernavn = '"+ txtbrukernavn.Text +"';");
     
    
      
            // hvis brukernavnet ikke finnes fra førav kjøres en spørring som inserter brukernavnet med et passord som er Hashet med HASHA1
            if (i == 0)
            {
                db.Kjorsporring("INSERT INTO admin (brukernavn, passord) VALUES ('" + txtbrukernavn.Text + "', '" + HashSHA1(txtpassord.Text) + "');");
                label1.Text = "Bruker er registrert";

            }
            else
            // hvis brukernavnet finnes fra før av får man ut feilmelding
            {
                label1.Text = "Bruker finnes fra før av";
            }

        }

        // metoden for å HASHE passordet til databasen slik at passordet ikke blir liggende i klartekst for DB administrator.
        // https://stackoverflow.com/questions/17292366/hashing-with-sha1-algorithm-in-c-sharp
        public static string HashSHA1(string value)
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var inputBytes = Encoding.ASCII.GetBytes(value);
                var hash = sha1.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        
        // tar brukeren tilbake til logginn formet
        private void btnlogginn_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            logginn fm = new logginn();
            fm.Show();
        }
       
        private void registrerbruker_Load(object sender, EventArgs e)
        {

        }
    }
}

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


// kode for å logg inn i til selve administratorpanelet med brukernavn og passord som er lagret i databasen
namespace eksamen2018wf
{
    public partial class logginn : Form
    {
        // Setter opp en kobling til databasen og definerer at variabelen i = 0
        MySqlConnection con = new MySqlConnection("Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG");
        int i;
        public logginn()
        {
            InitializeComponent();

        }

        // hele tilkobling til databasen, som sier at den skal selecte alt fra databasen og sjekke om det finnes et brukernavn og passord som
        // er det samme som brukernavn.text og passord.text sin teks. t1 og t2 er tekstboksene til brukernavn og passord i logginn filen.
        // vi sjekker her det hashete passordet som er lagret i databasen. Brukeren logger inn med sitt vanlige passord. Dette passordet blir lagret i databasen
        // på en måte slik at det ikke ligger i klartekst for personer som har tilgang til databasen. Dette gjøes med HashSHA1.
        // programmet sjekker og legger inn passord som er hashet
        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " select * from admin WHERE brukernavn='" + brukernavn.Text + "' and passord='" + HashSHA1(passord.Text) + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32 (dt.Rows.Count.ToString());
            // hvis kombinasjonene ikke finnes fra før av får man ut en feilmelding
            if(i == 0) {
                label3.Text = "Feil brukernavn eller passord";

            }
            // hvis brukernavnet og passordet finnes fra før av og stemmer blir man tatt videre til selve adminpanelet 
            else {
                this.Hide();
                adminpanel fm = new adminpanel(brukernavn.Text);
                
                fm.Show();
               
             
            }
            

            con.Close();

        }
        // Her legget vi brukernavnet man har logget inn med i en string slik at vi kan bruke dette brukernavnet i resten av applikasjonene til diverse ting
        public static class LoginInfo
        {
            public static string brukernavn;
        }

        // metoden for å HASHE passordet til databasen slik at passordet ikke blir liggende i klartekst for DB administrator.
       // https://stackoverflow.com/questions/17292366/hashing-with-sha1-algorithm-in-c-sharp
        public string HashSHA1(string value)
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
        // knapp som tar brukeren til registrere formen for å registrere bruker.
        private void registrerbruker_Click(object sender, EventArgs e)
        {
            this.Hide();
            registrerbruker fm = new registrerbruker();
            fm.Show();
        }
        // tar med brukernavnet som ble registrert tilbake til logginn formen og legger det i brukernavn tekstfeltet
              public string ID
        {
            get { return brukernavn.Text; }
        }

       
        private void button1_TextChanged(object sender, EventArgs e)
        {

            

            
        }
       
        private void logginn_Load(object sender, EventArgs e)
        {

        }
    }
}
